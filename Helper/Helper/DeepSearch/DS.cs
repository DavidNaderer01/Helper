using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public class DeepSearch
    {
        private char[][] _input = File.ReadLines("file.txt").Select(x => x.ToCharArray()).ToArray();
        private bool[,] _alreadyVisit;
        private Stack<(int, int)> visited = new();
        private (int, int) _end;

        public DeepSearch()
        {
            _alreadyVisit = new bool[_input.LongLength, _input[0].Length];
            GetLetter('S', 'a', true);
            _alreadyVisit[0, 0] = true;
            _end = GetLetter('E', 'z', false);
            FindLetter('E');
        }

        private (int, int) GetLetter(char letter, char replace, bool push)
        {
            for (int i = 0; i < _input.LongLength; i++)
            {
                for (int j = 0; j < _input[0].Length; j++)
                {
                    if (_input[i][j] == letter)
                    {
                        if (push)
                            visited.Push((i, j));
                        _input[i][j] = replace;
                        return (i, j);
                    }
                }
            }

            return new();
        }

        private void FindLetter(char letter)
        {
            var current = visited.Peek();

            if (current != _end)
            {
                ChangeWay();
                FindLetter(letter);
            }
            else
            {
                Console.WriteLine(visited.Count);
            }

            return;
        }

        private void ChangeWay()
        {
            var neig = GetNeig();
            var current = (-1, -1);

            for (int i = 0; i < neig.Count; i++)
            {
                if (IsValidNeigbour(neig[i]))
                {
                    current = visited.Peek();
                    _alreadyVisit[current.Item1, current.Item2] = true;
                    visited.Push(neig[i]);
                    return;
                }
            }
            visited.Pop();
            current = visited.Peek();
            _alreadyVisit[current.Item1, current.Item2] = false;
        }

        private bool IsValidNeigbour((int, int) next)
        {
            var current = visited.Peek();

            if (next.Item1 < 0 | next.Item2 < 0 | next.Item1 >= _input.Length | next.Item2 >= _input[0].Length)
                return false;

            return Math.Abs(_input[current.Item1][current.Item2] - _input[next.Item1][next.Item2]) <= 1 & !_alreadyVisit[next.Item1, next.Item2];
        }

        private List<(int, int)> GetNeig()
        {
            var current = visited.Peek();

            return new()
            {
                new(current.Item1 - 1, current.Item2),
                new(current.Item1 + 1, current.Item2),
                new(current.Item1, current.Item2 - 1),
                new(current.Item1, current.Item2 + 1)
            };
        }
    }
}
