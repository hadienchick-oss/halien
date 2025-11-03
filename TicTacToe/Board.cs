using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public class Board
    {

        // Lớp Bàn Cờ
        private Panel chessBoard;
        public Panel ChessBoard
        {
            get => chessBoard;
            set => chessBoard = value;
        }

        // Lớp Player 
        private List<Player> player;
        public List<Player> Player
        {
            get => player;
            set => player = value;
        }

        // Current player
        private int currentPlayer;
        public int CurrentPlayer 
        { 
            get => currentPlayer; 
            set => currentPlayer = value; 
        }

        // Bàn cờ
        public Board(Panel chessBoard)
        {
            this.ChessBoard = chessBoard;
            this.Player = new List<Player>()
            {
                new Player("P11",Image.FromFile(Application.StartupPath + "\\Resources\\x1.png")),
                new Player("P22",Image.FromFile(Application.StartupPath + "\\Resources\\o1.jpg")),
            };
            CurrentPlayer = 0;
        }

        public void drawChessBoard()  // Hàm vẽ ra bàn cờ
        {
            Button oldBtn = new Button()
            {
                Width = 0,
                Location = new Point(0, 0)
            };
            for (int i = 0; i < 11; i++)  // Tạo nút trên bàn cờ n(trục x)
            {
                for (int j = 0; j < 11; j++) // Tạo nút trên bàn cờ m(trục y)
                {
                    Button btn = new Button() //Tọa nút mới
                    {
                        Width = cache.Chess_Width,
                        Height = cache.Chess_Height,
                        Location = new Point(oldBtn.Location.X + oldBtn.Width, oldBtn.Location.Y),
                        BackgroundImageLayout= ImageLayout.Stretch,// stretch image
                    };


                    //Sự kiện nút
                    btn.Click += btn_Click;

                    ChessBoard.Controls.Add(btn); // Thêm nút vào bàn cờ
                    oldBtn = btn; // gán nút vừa tạo thành nút old để tiếp tục tạo nút mới cho vòng lập sau
                }
                //tạo hết 1 hàng thì reset lại xuống phía dưới bên trái
                oldBtn.Location = new Point(0, oldBtn.Location.Y + cache.Chess_Height);// x=0, y= độ location nút cũ + height
                oldBtn.Width = 0;
                oldBtn.Height = 0;
            }
        }

        //Click
        void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.BackgroundImage == null)
            {
                btn.BackgroundImage = Player[CurrentPlayer].Mark;
                CurrentPlayer = CurrentPlayer == 1 ? 0 : 1;
            }
        }
       
    }
}
