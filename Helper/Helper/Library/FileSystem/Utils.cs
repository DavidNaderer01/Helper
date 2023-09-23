using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper.Library.FileSystem
{
    public static class Utils
    {
        public static char[,] Split(this string[] content)
        {
            if (content.Any(x => x.Length != content[0].Length))
                throw new Exception("wrong Argument");
            char[,] solution = new char[content.Length, content[0].Length];

            for(int i = 0; i < content.Length; i++)
            {
                for(int j = 0; j < content[i].Length; j++)
                {
                    solution[i, j] = content[i][j];
                }
            }

            return solution;
        }
    }
}
