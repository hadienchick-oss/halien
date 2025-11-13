using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    namespace TicTacToe
    {
        public class GameController
        {


            private LinkedList<int[,]> history = new LinkedList<int[,]>();
            private LinkedListNode<int[,]> currentNode;
            private int[,] currentState;

            private int currentPlayer;
            private List<Player> players;
            private PictureBox mark;
            private Panel chessBoard;
            private Board board;
            public GameController( List<Player> players, int currentPlayer,PictureBox mark,Panel chessBoard, Board board)
            {
           
                this.players = players;
                this.currentPlayer = currentPlayer;
                this.mark = mark;
                this.chessBoard = chessBoard;
                this.board = board;


                // Khởi tạo lịch sử với trạng thái ban đầu (trống)
                int[,] initialState = new int[cache.SizeChess, cache.SizeChess];
                history.AddFirst(initialState);
                currentNode = history.First;
            }
          
         
            //----------Sự Kiện btn Click-----------------
            public void btnClick(object sender, EventArgs e)
            {
                Button btn = sender as Button;
                if (btn.BackgroundImage != null) return;
              

                if (btn.Tag is Point point)
                {
                    int row = point.X;
                    int col = point.Y;
                    // === LƯU TRẠNG THÁI HIỆN TẠI VÀO UNDO TRƯỚC KHI ĐÁNH ===
                    int[,] stateBeforeMove = CloneMatrix(cache.GameState);
                    // === 2. XÓA TẤT CẢ REDO PHÍA SAU ===
                    while (currentNode.Next != null)
                    {
                        history.Remove(currentNode.Next);
                    }

                    // Đánh nước đi
                    cache.GameState[row, col] = currentPlayer + 1;
                    btn.BackgroundImage = players[currentPlayer].Mark;
                    mark.BackgroundImage = players[currentPlayer == 1 ? 0 : 1].Mark;


                    // === 4. THÊM TRẠNG THÁI MỚI VÀO LỊCH SỬ ===
                    int[,] stateAfterMove = CloneMatrix(cache.GameState);
                    currentNode = history.AddAfter(currentNode, stateAfterMove);


                    GameRule rule = new GameRule(cache.GameState, cache.SizeChess);
                    if (rule.CheckWin(row, col))
                    {

                        HistoryManager.SaveGame(cache.GameState);//Luu---
                        MessageBox.Show($"Người chơi {players[currentPlayer].Name} thắng!");//Hien Thong Bao Thang
                        // Khóa bàn cờ
                        foreach (Control ctrl in chessBoard.Controls)
                        {
                            if (ctrl is Button b)
                                b.Enabled = false;
                        }


                        board.drawChessBoard();
                        // Reset game

                    }
                    else
                        currentPlayer = currentPlayer == 1 ? 0 : 1;
                    
                }
                bool bot = Board.Bot;
                if (bot && currentPlayer == 1) // giả sử bot là người chơi thứ 2
                {
                    Player.BotPlay(cache.GameState, chessBoard);
                }

            }
            //------Có thể cmt------
            //public int CurrentPlayer => currentPlayer;


           
            // === HOÀN THIỆN HÀM UNDO, REDO ===


            public void Undo()
            {
                if (currentNode.Previous != null)
                {
                    // Quay lại trạng thái trước đó
                    currentNode = currentNode.Previous;
                    cache.GameState = CloneMatrix(currentNode.Value);

                    // Đổi lượt người chơi (người vừa đánh → người trước đó)
                    currentPlayer = currentPlayer == 1 ? 0 : 1;

                    // Vẽ lại bàn cờ và cập nhật dấu lượt
                    board.drawChessBoard(cache.GameState);
                    mark.BackgroundImage = players[currentPlayer].Mark;
                }
            }

            public void Redo()
            {
                if (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                    cache.GameState = CloneMatrix(currentNode.Value);
                    currentPlayer = (cache.GameState.Cast<int>().Any(x => x != 0)) ? (currentPlayer == 1 ? 0 : 1) : 0;

                    // Tính lại currentPlayer chính xác hơn (tùy chọn)
                    // Hoặc lưu cả currentPlayer vào history (xem phiên bản nâng cao)

                    board.drawChessBoard(cache.GameState);
                    mark.BackgroundImage = players[currentPlayer == 1 ? 0 : 1].Mark;
                }
            }

            public int[,] CloneMatrix(int[,] source)
            {
                int rows = source.GetLength(0);
                int cols = source.GetLength(1);
                int[,] clone = new int[rows, cols];

                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < cols; j++)
                        clone[i, j] = source[i, j];

                return clone;
            }


        }
    }

}
