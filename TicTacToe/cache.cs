using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TicTacToe
{
    public class cache
    {
        public static int[,] GameState;
        public static int Chess_Width = 30;
        public static int Chess_Height = 30;
        public static int SizeChess = 15;
        public static string Save = DateTime.Now.ToString("ss-mm-HH-dd-MM");
        public static int SaveNum = 0;
        public static string HistoryFolder = "history";
    }
}
