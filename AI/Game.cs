using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public struct Cell
    {
        public int x;
        public int y;
    }

    public struct Move
    {
        public Cell cell;
        public int score;
    }

    public class Game
    {
        public char[,] field;

        char aiPlayer;
        char huPlayer;

        public int width;
        public int height;
        public int length;

        public void NewGame(int height, int width, int length, char player, char ai)
        {
            field = new char[height, width];
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    field[i, j] = '-';
            this.width = width;
            this.height = height;
            aiPlayer = ai;
            huPlayer = player;
            this.length = length;
        }

        ArrayList GetEmptyCellsIndexes(char[,] field)
        {
            ArrayList idx = new ArrayList();

            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    if (field[i, j] != '0' && field[i, j] != 'X')
                        idx.Add(new Cell { x = i, y = j });

            return idx;
        }

        public bool CheckWin(char[,] field, char player, int length)
        {
            for (int col = 0; col < width - length + 1; col++)
                for (int row = 0; row < height - length + 1; row++)
                    if (CheckDiagonal(field, player, length, col, row) || CheckLanes(field, player, length, col, row))
                        return true;

            return false;
        }

        bool CheckDiagonal(char[,] block, char player, int length, int offsetX, int offsetY)
        {
            bool toRight = true, toLeft = true;

            for(int i = 0; i < length; i++)
            {
                toRight &= (block[i + offsetY, i + offsetX] == player);
                toLeft &= (block[i + offsetY, length - i - 1 + offsetX] == player);
            }

            if (toRight || toLeft)
                return true;
            return false;
        }

        bool CheckLanes(char[,] block, char player, int length, int offsetX, int offsetY)
        {
            bool cols, rows;

            //for(int i = offsetY; i < length + offsetY; i++)
            //{
            //    cols = true;
            //    rows = true;

            //    for(int j = offsetX; j < length + offsetX; j++)
            //    {
            //        rows &= (block[i,j] == player);
            //        cols &= (block[j,i] == player);
            //    }

            //    if (cols || rows)
            //        return true;
            //}

            for (int i = offsetY; i < length + offsetY; i++)
            {
                //cols = true;
                rows = true;

                for (int j = offsetX; j < length + offsetX; j++)
                {
                    rows &= (block[i, j] == player);
                    //cols &= (block[j, i] == player);
                }

                if (rows)
                    return true;
            }

            for (int j = offsetX; j < length + offsetX; j++)
            {
                cols = true;
                //rows = true;

                for (int i = offsetY; i < length + offsetY; i++)
                {
                    //rows &= (block[i, j] == player);
                    cols &= (block[i,j] == player);
                }

                if (cols)
                    return true;
            }

            return false;
        }

        public Move MiniMax(char[,] newField, char player)
        {
            // Доступные клетки
            ArrayList availSpots = GetEmptyCellsIndexes(newField);

            // Проверка на терминальное состояние (победа / поражение / ничья)
            if (CheckWin(newField, huPlayer, length))
                return new Move { score = -10 };
            else if (CheckWin(newField, aiPlayer, length))
                return new Move { score = 10 };
            else if (availSpots.Count == 0)
                return new Move { score = 0 };

            // Массив для хранения всех объектов
            ArrayList moves = new ArrayList();
            
            // Цикл по доступным клеткам
            for (int i = 0; i < availSpots.Count; i++)
            {
                Cell cell = (Cell)availSpots[i];

                Move move;
                move.cell.x = cell.x;
                move.cell.y = cell.y;
                //move.index = newField[cell.x, cell.y];
                
                // Совершить ход за текущего игрока
                newField[cell.x, cell.y] = player;

                // Получить очки, заработанные после вызова минимакса от противника текущего игрока
                int result;
                if (player == aiPlayer)
                    result = MiniMax(newField, huPlayer).score;
                else
                    result = MiniMax(newField, aiPlayer).score;
                move.score = result;

                // Очистить клетку
                newField[cell.x, cell.y] = /*move.index*/'-';

                // Положить объект в массив
                moves.Add(move);
            }

            // Если это ход ИИ, пройти циклом по ходам и выбрать ход с наибольшим количеством очков
            int bestMove = -1;
            if (player == aiPlayer)
            {
                int bestScore = -10000;

                for (int i = 0; i < moves.Count; i++)
                {
                    Move temp = (Move)moves[i];
                    if (temp.score > bestScore)
                    {
                        bestScore = temp.score;
                        bestMove = i;
                    }
                }
            }

            else
            {
                int bestScore = 10000;

                for (int i = 0; i < moves.Count; i++)
                {
                    Move temp = (Move)moves[i];
                    if (temp.score < bestScore)
                    {
                        bestScore = temp.score;
                        bestMove = i;
                    }
                }
            }

            return (Move)moves[bestMove];
        }
    }
}
