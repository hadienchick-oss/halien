using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            drawChessBoard();
        }
        void drawChessBoard()
        {
            Button oldBtn = new Button()
            {
                Width = 0,
                Location = new Point(0, 0)
            };
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    Button btn = new Button()
                    {
                        Width = cache.Chess_Width,
                        Height = cache.Chess_Height,
                        Location = new Point(oldBtn.Location.X + oldBtn.Width, oldBtn.Location.Y)
                    };
                    pnlBoard.Controls.Add(btn);
                    oldBtn = btn;
                }
                oldBtn.Location = new Point(0, oldBtn.Location.Y+cache.Chess_Height);
                oldBtn.Width = 0;
                oldBtn.Height = 0;
            }
        }
    }
}
