using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class GameTTT : InterfaceTTT
    {
        public int Result => throw new NotImplementedException();

        public string Name
        {
            get
            {
                return "Isakhin";
            }
        }

        public Game game;
        private char huPlayer;
        private char aiPlayer;

        public void NewGame(int L, int W, int KW, int type)
        {
            game = new Game();

            if (type == 0)
            {
                huPlayer = '0';
                aiPlayer = 'X';
            }
            else
            {
                huPlayer = 'X';
                aiPlayer = '0';
            }
            game.NewGame(W, L, KW, huPlayer, aiPlayer);
        }

        public Loc NextRound(Loc L)
        {
            game.field[L.X, L.Y] = huPlayer;
            if (CheckWin(huPlayer))
                return new Loc(0, -1);
            Move move = game.MiniMax(game.field, aiPlayer);
            game.field[move.cell.x, move.cell.y] = aiPlayer;
            /*if (CheckWin(aiPlayer))
                return new Loc(-1, 0);*/
            return new Loc(move.cell.x, move.cell.y);
        }

        public bool CheckWin(char player)
        {
            return game.CheckWin(game.field, player, game.length);
        }

        public bool CheckWin(char player, char[,] field, int length)
        {
            return game.CheckWin(field, player, length);
        }
    }
}
