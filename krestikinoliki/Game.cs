using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace krestikinoliki
{
    public partial class Game : Form
    {
        private Form1 frm;


        char aiPlayer = '0';
        char huPlayer = 'X';
        

        TicTacToe.TicTacToe game;
        
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            
            Game game = new Game(frm);
           game.Show();
        }
        public Game(Form1 f)
        {
            InitializeComponent();
            frm = f;
            game = new TicTacToe.TicTacToe();
            Helper.Print_Mas(dataGridView1, frm.n, frm.m);

            if ((frm.b == true) && (frm.d == true))
            {
                textBox1.Text = frm.a;
                textBox2.Text = "Comp";
                game.NewGame(frm.n, frm.m, frm.q, 1);
            }
            else if ((frm.c == true) && (frm.d == true))
            {
                textBox1.Text = "Comp";
                textBox2.Text = frm.a;
                aiPlayer = 'X';
                huPlayer = '0';
                game.NewGame(frm.n, frm.m, frm.q, 0);
                game.game.field[1, 1] = aiPlayer;
                dataGridView1[1, 1].Value = aiPlayer;
            }
            else if ((frm.b == true) && (frm.f == true))
            {
                textBox2.Text = frm.nickname2;
                textBox1.Text = frm.a;
            }
            else if ((frm.c == true) && (frm.f == true))
            {
                textBox1.Text = frm.nickname2;
                textBox2.Text = frm.a;
               
            }

            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
        int i=0;
        char player1;
        char player2;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (frm.f==true )
            { if (frm.b == true)
                { 
                 player1 = 'X';
                 player2 = 'O';
                }
                if (frm.c == true)
                {
                     player1 = 'O';
                     player2 = 'X';
                }
            
            if (i % 2 == 0)
            {
                    
                    dataGridView1.CurrentCell.Value = player1;
                i++;
            }
            else
            {
                   
                    dataGridView1.CurrentCell.Value = player2;
                i++;
            }
                
            }
        
            if (frm.d == true)
            { 
                if (dataGridView1.CurrentCell.Value.ToString().Equals(" "))
                {
                dataGridView1.CurrentCell.Value = huPlayer;
               
                TicTacToe.Loc loc = new TicTacToe.Loc(dataGridView1.CurrentCell.RowIndex, dataGridView1.CurrentCell.ColumnIndex);
                loc = game.NextRound(loc);
                if (loc.X == 0 && loc.Y == -1)
                {
                    MessageBox.Show("Игрок победил");
                    return;
                }


                dataGridView1[loc.Y, loc.X].Value = aiPlayer;

                if (game.CheckWin(aiPlayer))
                {
                    MessageBox.Show("Компьютер победил");
                    return;
                }
            }
            }
            }

        public bool CheckDraw()
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    if ((string)dataGridView1[i, j].Value == " ")
                        return false;

            return true;
        }



        }
        
    }

