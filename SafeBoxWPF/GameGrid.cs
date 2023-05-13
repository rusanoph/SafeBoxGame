using System;

namespace SafeBoxWPF
{
    public class GameGrid
    {
        private readonly int[,] grid;
        private Random randomRow = new Random();
        private Random randomColumn = new Random();
        public int Rows { get; }
        public int Columns { get; }
        public int PositiveTileCount { get; set; }
        public int Steps = 0;

        public int this[int r, int c]
        {
            get => grid[r, c];
            set => grid[r, c] = value;
        }

        public GameGrid(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            grid = new int[rows, columns];
            PositiveTileCount = 0;
        }

        private void InvertCell(int row, int column)
        {
            grid[row, column] = (grid[row, column] + 1) % 2;

            if (grid[row, column] == 1)
                PositiveTileCount++;
            else
                PositiveTileCount--;
        }

        public void InvertPosition(int row, int column)
        {
            if (0 <= row && row < Rows && 0 <= column && column < Columns)
            {
                for (int c = 0; c < Columns; c++)
                    InvertCell(row, c);

                for (int r = 0; r < Rows; r++)
                    InvertCell(r, column);

                InvertCell(row, column);
                Steps++;
            }
        }

        public void GenerateSampleGameGrid(int shuffleDegree)
        {
            for (int i = 0; i < shuffleDegree; i++)
                InvertPosition(randomRow.Next(Rows), randomColumn.Next(Columns));
            Steps = 0;
        }


    }
}
