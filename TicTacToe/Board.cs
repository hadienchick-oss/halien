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
        private Panel chessBoard;
        // List Player 
        private List<Player> player;
        // player hiện tại 
        private int currentPlayer;
        // ảnh đánh dấu đến lượt người nào đánh
        private PictureBox playerMark;
        //Nút
        private GameController controller;
        private HistoryManager historyManager;

        public Panel ChessBoard { get => chessBoard; set => chessBoard = value; }
        public List<Player> Player { get => player; set => player = value; }
        public int CurrentPlayer { get => currentPlayer; set => currentPlayer = value; }
        public PictureBox PlayerMark { get => playerMark; set => playerMark = value; }
        public GameController Controller { get => controller; set => controller = value; }
        public HistoryManager HistoryManager { get => historyManager; set => historyManager = value; }





        // Bàn cờ 
        public Board(Panel chessBoard, PictureBox mark)
        {
            this.PlayerMark = mark;
            this.ChessBoard = chessBoard;
            this.Player = new List<Player>()
            {
                new Player("X",Image.FromFile(Application.StartupPath + "\\Resources\\x1.png")),
                new Player("0",Image.FromFile(Application.StartupPath + "\\Resources\\o1.jpg")),
            };
            CurrentPlayer = 0;
            Controller = new GameController( Player, CurrentPlayer, PlayerMark, ChessBoard, this);
            HistoryManager = new HistoryManager(cache.GameState);
           
        }

        //-----để bật tắt AI--------
        public static bool Bot = false;

      

        // ----------------Hàm Vẽ Bàn Cờ----------------
        //_______________________________________________
        public void drawChessBoard()
        {
            int[,] empty = new int[cache.SizeChess, cache.SizeChess];
            drawChessBoard(empty);               // dùng overload có state
            CurrentPlayer = 0;                   // bắt đầu lại lượt X
        }
        public void drawChessBoard(int[,]state)
        {

            //---------Ma trận lưu vị trí btn---------------

            cache.GameState = new int[cache.SizeChess,cache.SizeChess];
            
            ChessBoard.Controls.Clear();
            PlayerMark.BackgroundImage = Player[0].Mark;
          

            Button oldBtn = new Button()
            {
                Width = 0,
                Location = new Point(0, 0)
            };
            for (int i = 0; i < cache.SizeChess; i++)  // Tạo nút trên bàn cờ n(trục x)
            {
                for (int j = 0; j < cache.SizeChess; j++) // Tạo nút trên bàn cờ m(trục y)
                {
                    cache.GameState[i, j] = state[i,j];
                    Button btn = new Button() //Tọa nút mới
                    {
                        Width = cache.Chess_Width,
                        Height = cache.Chess_Height,
                        Location = new Point(oldBtn.Location.X + oldBtn.Width, oldBtn.Location.Y),
                        BackgroundImageLayout= ImageLayout.Stretch,// ảnh 
                        Tag = new Point(i, j) //  Gán tọa độ để xử lý khi click
                      
                    };
                    //Sự kiện nút
                    // === KHÔI PHỤC HÌNH ẢNH TỪ gameState ===
                    if (cache.GameState[i, j] == 1)
                        btn.BackgroundImage = Player[0].Mark;
                    else if (cache.GameState[i, j] == 2)
                        btn.BackgroundImage = Player[1].Mark;

                    btn.Click += Controller.btnClick;
                    ChessBoard.Controls.Add(btn);
                    oldBtn = btn; // gán nút vừa tạo thành nút old để tiếp tục tạo nút mới cho vòng lập sau
                }
                //tạo hết 1 hàng thì reset lại xuống phía dưới bên trái
                oldBtn.Location = new Point(0, oldBtn.Location.Y + cache.Chess_Height);// x=0, y= độ location nút cũ + height
                oldBtn.Width = 0;
                oldBtn.Height = 0;

            }
        }
        

        //=================test
        
    }
}
