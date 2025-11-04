using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    namespace TicTacToe
    {
        public class GameController
        {
            private int[,] gameState;
            private int boardSize;
            private List<Player> players;
            private int currentPlayer;
         
            private PictureBox mark;

            public GameController(int[,] gameState, int boardSize, List<Player> players, int currentPlayer,PictureBox mark)
            {
                this.gameState = gameState;
                this.boardSize = boardSize;
                this.players = players;
           
                this.currentPlayer = currentPlayer;
                this.mark = mark;
            }


            //----------Sự Kiện btn Click-----------------
            public void btnClick(object sender, EventArgs e)
            {
                Button btn = sender as Button;
                if (btn.BackgroundImage != null) return;
                btn.BackgroundImage = players[currentPlayer].Mark;
                mark.BackgroundImage = players[currentPlayer == 1 ? 0 : 1].Mark;


                if (btn.Tag is Point point)
                {
                    int row = point.X;
                    int col = point.Y;

                    gameState[row, col] = currentPlayer + 1;

                    GameRule rule = new GameRule(gameState, boardSize);
                    if (rule.CheckWin(row, col))
                    {
                        MessageBox.Show($"Người chơi {players[currentPlayer].Name} thắng!");

                        // Khóa bàn cờ
                        //foreach (Control ctrl in chessBoard.Controls)
                        //{
                        //    if (ctrl is Button b)
                        //        b.Enabled = false;
                        //}
                    }

                    currentPlayer = currentPlayer == 1 ? 0 : 1;
                }
            }
            //------Có thể cmt------
            //public int CurrentPlayer => currentPlayer;
        }
    }

}
