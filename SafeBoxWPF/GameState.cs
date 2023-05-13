namespace SafeBoxWPF
{
    public class GameState
    {
        public GameGrid GameGrid { get; set; }
        public int GameSize { get; set; }
        public bool GameOver { get; set; }

        public GameState(int gameSize)
        {
            GameGrid = new GameGrid(gameSize, gameSize);

            do
            {
                GameGrid.GenerateSampleGameGrid(50);
            } while (IsGameOver());

            GameOver = false;
        }

        public bool IsGameOver()
        {
            return GameGrid.PositiveTileCount == 0 || GameGrid.PositiveTileCount == GameGrid.Columns * GameGrid.Rows;
        }
    }   
}
