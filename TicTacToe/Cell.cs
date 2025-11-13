using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

      

        private void btnRedo_Click(object sender, EventArgs e)
        {
            if (Board.Bot == false)
            {
                ChessBoard.Controller.Redo();
            }
            else 
            { 
                ChessBoard.Controller.Redo();
                ChessBoard.Controller.Redo();
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {

            if (Board.Bot == false)
            {
                ChessBoard.Controller.Undo();
            }
            else
            {
                ChessBoard.Controller.Undo();
                ChessBoard.Controller.Undo();
            }

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ChessBoard.HistoryManager.Openfile();
            ChessBoard.drawChessBoard(cache.GameState) ;
            foreach (Control ctrl in ChessBoard.ChessBoard.Controls)
            {
                if (ctrl is Button b)
                    b.Enabled = false;
            }
        }



    }
}
