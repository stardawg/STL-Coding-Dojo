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
            int initColumnLength = _splitboard[0].Length;
            foreach (var row in _splitboard)
            {
                if (row.Length != initColumnLength)
                    throw new InitializationException();
            }
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
                        if(neighborCount < 2 || neighborCount == 4)
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
            int leftAlive = Convert.ToInt32(IsCellToLeftAlive(currBoardState, lineIndex, cellIndex));
            int rightAlive = Convert.ToInt32(IsCellToRightAlive(currBoardState, lineIndex, cellIndex));
            int aboveAlive = Convert.ToInt32(IsCellToAboveAlive(currBoardState, lineIndex, cellIndex));
            int belowAlive = Convert.ToInt32(IsCellToBelowAlive(currBoardState, lineIndex, cellIndex));
         
            return leftAlive + rightAlive + aboveAlive + belowAlive;
        }
        private bool IsCellToLeftAlive(char[][] currBoardState, int lineIndex, int cellIndex)
        {
            return IsNeighborCellValid(currBoardState, lineIndex, cellIndex-1);
        }

        private bool IsCellToRightAlive(char[][] currBoardState, int lineIndex, int cellIndex)
        {
            return IsNeighborCellValid(currBoardState, lineIndex, cellIndex + 1);
        }

        private bool IsCellToAboveAlive(char[][] currBoardState, int lineIndex, int cellIndex)
        {
            return IsNeighborCellValid(currBoardState, lineIndex-1, cellIndex );
        }

        private bool IsCellToBelowAlive(char[][] currBoardState, int lineIndex, int cellIndex)
        {
            return IsNeighborCellValid(currBoardState, lineIndex+1, cellIndex);
        }

        private bool IsNeighborCellValid(char[][] currBoardState, int lineIndex, int cellIndex)
        {
            if (IsCellValid(lineIndex, cellIndex))
            {
                return (currBoardState[lineIndex][cellIndex] == '*');
            }
            else
            {
                return false;
            }
        }
        private bool IsCellValid(int lineIndex, int cellIndex)
        {
            if (cellIndex >= 0 
                && lineIndex >= 0
                && Size.Width > cellIndex
                && Size.Height > lineIndex
                )
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
