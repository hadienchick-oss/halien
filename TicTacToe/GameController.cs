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
            private List<Player> players;
            private int currentPlayer;
            private PictureBox mark;
            private Panel chessBoard;
            private Board board;
            public GameController(int[,] gameState, List<Player> players, int currentPlayer,PictureBox mark,Panel chessBoard, Board board)
            {
                this.gameState = gameState;
                this.players = players;
                this.currentPlayer = currentPlayer;
                this.mark = mark;
                this.chessBoard = chessBoard;
                this.board = board;
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

                    GameRule rule = new GameRule(gameState, cache.SizeChess);
                    if (rule.CheckWin(row, col))
                    {
                        MessageBox.Show($"Người chơi {players[currentPlayer].Name} thắng!");
                        board.drawChessBoard();

                    }else
                        currentPlayer = currentPlayer == 1 ? 0 : 1;
                    
                }
                bool bot = Board.Bot;
                if (bot && currentPlayer == 1) // giả sử bot là người chơi thứ 2
                {
                    BotPlay();
                }

            }
            //------Có thể cmt------
            //public int CurrentPlayer => currentPlayer;

         

            public void BotPlay()
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

}
