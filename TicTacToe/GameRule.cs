using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    
    public class GameRule
    {
        private int[,] gameState;
        private int boardSize;

        public GameRule(int[,] gameState, int boardSize)
        {
            this.gameState = gameState;
            this.boardSize = boardSize;
        }




        //------------Kiểm Tra Thắng----------------
        //------------------------------------------
        public bool CheckWin(int row, int col)
        {
            int player = gameState[row, col];
            if (player == 0) return false;

            return CountConsecutive(row, col, 0, 1, player) + CountConsecutive(row, col, 0, -1, player) >= 4 // ngang
                || CountConsecutive(row, col, 1, 0, player) + CountConsecutive(row, col, -1, 0, player) >= 4 // dọc
                || CountConsecutive(row, col, 1, 1, player) + CountConsecutive(row, col, -1, -1, player) >= 4 // chéo chính
                || CountConsecutive(row, col, 1, -1, player) + CountConsecutive(row, col, -1, 1, player) >= 4; // chéo phụ
        }

        private int CountConsecutive(int row, int col, int dRow, int dCol, int player)
        {
            int count = 0;
            int i = row + dRow;
            int j = col + dCol;

            while (i >= 0 && i < boardSize && j >= 0 && j < boardSize && gameState[i, j] == player)
            {
                count++;
                i += dRow;
                j += dCol;
            }

            return count;
        }
    }
}
