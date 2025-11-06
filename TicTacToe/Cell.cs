using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToe.TicTacToe;

namespace TicTacToe
{
    public partial class Cell : Form
    {

        Board ChessBoard;
        public Cell()
        {
            InitializeComponent();
            ChessBoard= new Board(pnlBoard,ptbPlayer);
            ChessBoard.drawChessBoard();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChessBoard.drawChessBoard();
        }


        
        private void aIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ChessBoard.drawChessBoard();
            
          
        }


        

        private void botToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Board.Bot = true;
            ChessBoard.drawChessBoard();
        }

        private void pToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Board.Bot = false;
            ChessBoard.drawChessBoard();
        }
    }
}
