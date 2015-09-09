namespace Chess.Source.Common
{
    using System;

    public struct Position
    {
        public Position(int row, char col)
            : this()
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; private set; }
        public char Col { get; private set; }

        public static Position FromChessCoordinates(int chessRow, char chessCol)
        {
            var newPosition = new Position(chessRow, chessCol);
            Position.CheckIfPositionIsValid(newPosition);
            return newPosition;
        }

        public static void CheckIfPositionIsValid(Position position)
        {
            if (position.Row < GlobalConstants.MinimumRowOnBoard || position.Row > GlobalConstants.MaximumRowOnBoard)
            {
                throw new IndexOutOfRangeException("Selected row position on the board is not valid!");
            }

            if (position.Col < GlobalConstants.MinimumColOnBoard || position.Col > GlobalConstants.MaximumColOnBoard)
            {
                throw new IndexOutOfRangeException("Selected column position on the board is not valid!");
            }
        }
    }
}
