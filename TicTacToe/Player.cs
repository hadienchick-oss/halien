using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public class Player
    {

        // Ten player
        private string name;
        // image Player
        private Image mark;
        private int[,] gameState;
        private Panel chessBoard;


        public string Name { get => name; set => name = value; }
        public Image Mark { get => mark; set => mark = value; }

        public Player(string name, Image mark) 
        {
            this.Name = name;
            this.Mark = mark;
        }
     
        public Player(int[,] gameState, Panel chessBoard)
        {
            this.gameState = gameState;
            this.chessBoard = chessBoard;
        }

        // -----------A.I----Caro------------------
        //==========================================
        public static void BotPlay(int[,]gameState,Panel chessBoard)
        {
            Random rand = new Random();

            while (true)
            {
                int row = rand.Next(cache.SizeChess);
                int col = rand.Next(cache.SizeChess);

                if (gameState[row, col] == 0)
                {
                    foreach (Control ctrl in chessBoard.Controls)
                    {
                        if (ctrl is Button btn && btn.Tag is Point p && p.X == row && p.Y == col)
                        {
                            btn.PerformClick(); // giả lập click để bot đánh
                            return;
                        }
                    }
                }
            }
        }
    }
}
