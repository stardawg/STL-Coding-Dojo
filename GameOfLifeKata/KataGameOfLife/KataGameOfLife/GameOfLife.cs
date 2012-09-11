using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KataGameOfLife
{
    class GameOfLife
    {
        public Size Size { get; private set; }
        public string Board { get; private set; }

        private char[][] _splitboard;

        public void Load(string board)
        {
            Board = board;

            _splitboard = Board
                .Split(new[] { Environment.NewLine }, StringSplitOptions.None)
                .Select(line => line.Trim().ToCharArray())
                .ToArray();

            Size = new Size(_splitboard.Length, _splitboard[0].Length);
        }

        public void RunGeneration()
        {
            var _oldSplitBoard = _splitboard.Select(s => s.ToArray()).ToArray();

            for (int lineIndex = 0; lineIndex < _oldSplitBoard.Length; lineIndex++)
            {
                var line = _oldSplitBoard[lineIndex];
                for(int cellIndex=0; cellIndex < line.Length; cellIndex++)
                {
                    if (_oldSplitBoard[lineIndex][cellIndex] == '*')
                    {
                        int neighborCount = GetNeighborCount(_oldSplitBoard, lineIndex,cellIndex);
                        if(neighborCount<2)
                        {
                            KillCell(lineIndex, cellIndex);
                        }
                        
                    }
                }
            }
            RebuildBoard();
        }

        private void KillCell(int lineIndex, int cellIndex)
        {
            _splitboard[lineIndex][cellIndex] = '.';
        }

        private int GetNeighborCount(char[][] currBoardState, int lineIndex, int cellIndex)
        {
            return Convert.ToInt32(IsCellToLeftAlive(currBoardState, lineIndex, cellIndex)) +
                        Convert.ToInt32(IsCellToRightAlive(currBoardState, lineIndex, cellIndex)) +
                        Convert.ToInt32(IsCellToAboveAlive(currBoardState, lineIndex, cellIndex)) +
                        Convert.ToInt32(IsCellToBelowAlive(currBoardState, lineIndex, cellIndex));

        }
        private bool IsCellToLeftAlive(char[][] currBoardState, int lineIndex, int cellIndex)
        {
            return IsCellValidAndAlive(currBoardState, lineIndex, cellIndex-1);
        }



        private bool IsCellToRightAlive(char[][] currBoardState, int lineIndex, int cellIndex)
        {
            return IsCellValidAndAlive(currBoardState, lineIndex, cellIndex + 1);
        }

        private bool IsCellToAboveAlive(char[][] currBoardState, int lineIndex, int cellIndex)
        {
            return IsCellValidAndAlive(currBoardState, lineIndex-1, cellIndex );
        }

        private bool IsCellToBelowAlive(char[][] currBoardState, int lineIndex, int cellIndex)
        {
            return IsCellValidAndAlive(currBoardState, lineIndex+1, cellIndex - 1);
        }

        private bool IsCellValidAndAlive(char[][] currBoardState, int lineIndex, int cellIndex)
        {
            if (IsValidNeighbor(lineIndex, cellIndex - 1))
            {
                return (currBoardState[lineIndex][cellIndex - 1] == '*');
            }
            else
            {
                return false;
            }
        }
        private bool IsValidNeighbor(int x, int y)
        {
            if (y > 0 
                && x > 0
                && Size.Height > y
                && Size.Width > x)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void RebuildBoard()
        {
            Board = string.Join(Environment.NewLine, _splitboard.Select(line => new string(line)));
        }
    }
}
