using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public class HistoryManager
    {
        private int[,] GameState;

        public HistoryManager(int[,] GameState)
        {
            this.GameState = GameState;
        }


     
        public static void SaveGame(int[,] GameState)
        {
            string fileName = $"{cache.SaveNum++}__{cache.Save}.txt";
            string fullPath = Path.Combine(cache.HistoryFolder, fileName);
            using (StreamWriter writer = new StreamWriter(fullPath))
            {
                for (int i = 0; i < cache.SizeChess; i++)
                {
                    string line = "";
                    for (int j = 0; j < cache.SizeChess; j++)
                    {
                        line += GameState[i, j] + " ";
                    }
                    writer.WriteLine(line.Trim());
                }
            }
        }


        public void Openfile()
        {
            OpenFileDialog ofdOpen = new OpenFileDialog();
            ofdOpen.InitialDirectory = Path.Combine(Application.StartupPath, cache.HistoryFolder);
            ofdOpen.Filter = "Text Files (*.txt)|*.txt";
            ofdOpen.FilterIndex = 3;
            if (ofdOpen.ShowDialog() == DialogResult.OK)
            {
                DocTapTin(ofdOpen.FileName);
            }
        }
        public void DocTapTin(string tentaptin)
        {
            string[] lines = File.ReadAllLines(tentaptin);
            cache.GameState = new int[cache.SizeChess, cache.SizeChess];

            for (int i = 0; i < cache.SizeChess; i++)
            {
                string[] values = lines[i].Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < cache.SizeChess; j++)
                {
                    cache.GameState[i, j] = int.Parse(values[j]);
                }
            }
        }
    }
}
