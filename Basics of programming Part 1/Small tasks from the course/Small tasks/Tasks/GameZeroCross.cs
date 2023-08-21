using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Small_tasks.Tasks
{
    internal class GameZeroCross
    {
        public enum Mark
        {
            Empty,
            Cross,
            Circle
        }

        public enum GameResult
        {
            CrossWin,
            CircleWin,
            Draw
        }

        public static void Main()
        {
            StartGame("XXX OO. ...");
            StartGame("OXO XO. .XO");
            StartGame("OXO XOX OX.");
            StartGame("XOX OXO OXO");
            StartGame("... ... ...");
            StartGame("XXX OOO ...");
            StartGame("XOO XOO XX.");
            StartGame(".O. XO. XOX");
        }

        private static void StartGame(string description)
        {
            Console.WriteLine(description.Replace(" ", Environment.NewLine));
            Console.WriteLine(GetGameResult(CreateFromString(description)));
            Console.WriteLine();
        }

        private static Mark[,] CreateFromString(string str)
        {
            var field = str.Split(' ');
            var ans = new Mark[3, 3];
            for (int x = 0; x < field.Length; x++)
                for (var y = 0; y < field.Length; y++)
                    ans[x, y] = field[x][y] == 'X' ? Mark.Cross : (field[x][y] == 'O' ? Mark.Circle : Mark.Empty);
            return ans;
        }
        public static GameResult GetGameResult(Mark[,] field)
        {
            if ((HasWinSequence(field, Mark.Cross)) && (!HasWinSequence(field, Mark.Circle)))
                return GameResult.CrossWin;
            else if (!(HasWinSequence(field, Mark.Cross)) && (HasWinSequence(field, Mark.Circle)))
                return GameResult.CircleWin;
            else
                return GameResult.Draw;
        }

        public static bool HasWinSequence(Mark[,] field, Mark mark)
        {
            bool win = false;
            int[,] winStratagies = new int[8, 4] { { 0, 0, 1, 0 }, { 0, 1, 1, 0 }, { 0, 2, 1, 0 }, { 0, 0, 0, 1 }, { 1, 0, 0, 1 }, { 2, 0, 0, 1 }, { 0, 0, 1, 1 }, { 0, 2, 1, -1 } };

            for (int i = 0; i < 8; i++)
            {
                if (field[winStratagies[i, 0], winStratagies[i, 1]] == mark)
                {
                    bool winStrat = true;
                    for (int j = 1; j < 3; j++)
                    {
                        if (field[winStratagies[i, 0] + j * winStratagies[i, 2], winStratagies[i, 1] + j * winStratagies[i, 3]] == mark)
                            winStrat = winStrat & true;
                        else
                            winStrat = winStrat & false;
                    }
                    win = win | winStrat;
                }
            }
            return win;
        }
    }
}
