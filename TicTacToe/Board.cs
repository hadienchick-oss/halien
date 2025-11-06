using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToe.TicTacToe;

namespace TicTacToe
{
    public class Board
    {

        // Lớp Bàn Cờ
        public Panel chessBoard;
        public Panel ChessBoard
        {
            get => chessBoard;
            set => chessBoard = value;
        }

        // List Player 
        private List<Player> player;
        public List<Player> Player
        {
            get => player;
            set => player = value;
        }

        // player hiện tại 
        public int currentPlayer;
        public int CurrentPlayer 
        { 
            get => currentPlayer; 
            set => currentPlayer = value; 
        }
        public PictureBox PlayerMark { get => playerMark; set => playerMark = value; }

        private PictureBox playerMark;


        // Bàn cờ 
        public Board(Panel chessBoard, PictureBox mark)
        {
            this.playerMark = mark;
            this.ChessBoard = chessBoard;
            this.Player = new List<Player>()
            {
                new Player("X",Image.FromFile(Application.StartupPath + "\\Resources\\x1.png")),
                new Player("0",Image.FromFile(Application.StartupPath + "\\Resources\\o1.jpg")),
            };
            CurrentPlayer = 0;
        }

        //-----để bật tắt AI--------
        public static bool Bot = false;
        


        // ----------------Hàm Vẽ Bàn Cờ----------------
        //_______________________________________________
        public void drawChessBoard()
        {   
            //---------Ma trận lưu vị trí btn---------------
            int[,] gameState = new int[cache.SizeChess, cache.SizeChess];
            ChessBoard.Controls.Clear();
            PlayerMark.BackgroundImage = Player[0].Mark;
          

            GameController controller = new GameController(gameState, Player, CurrentPlayer, PlayerMark,chessBoard, this);//Nut
           
            
            Button oldBtn = new Button()
            {
                Width = 0,
                Location = new Point(0, 0)
            };
            for (int i = 0; i < cache.SizeChess; i++)  // Tạo nút trên bàn cờ n(trục x)
            {
                for (int j = 0; j < cache.SizeChess; j++) // Tạo nút trên bàn cờ m(trục y)
                {
                    Button btn = new Button() //Tọa nút mới
                    {
                        Width = cache.Chess_Width,
                        Height = cache.Chess_Height,
                        Location = new Point(oldBtn.Location.X + oldBtn.Width, oldBtn.Location.Y),
                        BackgroundImageLayout= ImageLayout.Stretch,// ảnh 
                        Tag = new Point(i, j) //  Gán tọa độ để xử lý khi click

                    };
                    //Sự kiện nút
                    btn.Click += controller.btnClick;
                    
                    ChessBoard.Controls.Add(btn); // Thêm nút vào bàn cờ
                    oldBtn = btn; // gán nút vừa tạo thành nút old để tiếp tục tạo nút mới cho vòng lập sau
                }
                //tạo hết 1 hàng thì reset lại xuống phía dưới bên trái
                oldBtn.Location = new Point(0, oldBtn.Location.Y + cache.Chess_Height);// x=0, y= độ location nút cũ + height
                oldBtn.Width = 0;
                oldBtn.Height = 0;

            }
        }
        
    }
}
