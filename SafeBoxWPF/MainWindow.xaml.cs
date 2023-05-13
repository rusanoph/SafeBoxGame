using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace SafeBoxWPF
{
    public partial class MainWindow : Window
    {
        private readonly ImageSource[] tileImages = new ImageSource[]
        {
            new BitmapImage(new Uri("Assets/BlackTile.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/WhiteTile.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/ActiveTile.png", UriKind.Relative))
        };

        private Image[,] imageControls;
        private int N = 2;
        private GameState gameState;
        private int maxDifficult = 15;
        private int minDifficult = 3;
        private bool gameStart = false;

        public MainWindow()
        {
            InitializeComponent();

        }

        private Image[,] SetupGameCanvas(GameGrid grid)
        {
            Image[,] imageControls = new Image[grid.Rows, grid.Columns];
            int cellSize = (int)(GameCanvas.Width / N);

            for (int r = 0; r < grid.Rows; r++)
            {
                for (int c = 0; c < grid.Columns; c++)
                {
                    Image imageControl = new Image { Width = cellSize, Height = cellSize };

                    Canvas.SetTop(imageControl, r * cellSize);
                    Canvas.SetLeft(imageControl, c * cellSize);
                    GameCanvas.Children.Add(imageControl);
                    imageControls[r, c] = imageControl;
                }
            }

            return imageControls;
        }

        private Position GetMouseCell()
        {
            Point mousePoint = Mouse.GetPosition(GameCanvas);

            int row = (int)Math.Floor(mousePoint.Y / GameCanvas.Height * N);
            int column = (int)Math.Floor(mousePoint.X / GameCanvas.Width * N);

            return new Position(row, column);
        }

        private void ChangePositionState()
        {
            Position cell = GetMouseCell();
            StepsText.Text = $"Steps: {gameState.GameGrid.Steps}";
            gameState.GameGrid.InvertPosition(cell.Row, cell.Column);

            if (gameState.IsGameOver())
                gameState.GameOver = true;
            else
                gameState.GameOver = false;
        }

        private void DrawGrid(GameGrid grid)
        {
            for (int r = 0; r < grid.Rows; r++)
            {
                for (int c = 0; c < grid.Columns; c++)
                {
                    Position mousePosition = GetMouseCell();
                    if (mousePosition.Row == r && mousePosition.Column == c)
                    {
                        imageControls[r, c].Source = tileImages[2];
                        continue;
                    }

                    int id = grid[r, c];
                    imageControls[r, c].Source = tileImages[id];
                }
            }
        }

        private void Draw(GameState gameState)
        {
            DrawGrid(gameState.GameGrid);
            StepsText.Text = $"Steps: {gameState.GameGrid.Steps}";
        }

        private async Task GameLoop()
        {
            Draw(gameState);

            while (!gameState.GameOver && !backToMenu)
            {
                await Task.Delay(50);
                Draw(gameState);

                if (Mouse.LeftButton == MouseButtonState.Pressed) {
                    ChangePositionState();
                    await Task.Delay(150);
                }
            }

            Draw(gameState);


            if (gameStart)
            {
                GameOverMenu.Visibility = Visibility.Visible;
                FinalStepsText.Text = $"In {gameState.GameGrid.Steps} steps";
            }
        }

        private async void Play_Click(object sender, RoutedEventArgs e)
        {
            GameCanvas.Children.Clear();

            gameStart = true;
            backToMenu = false;
            gameState = new GameState(N);
            imageControls = SetupGameCanvas(gameState.GameGrid);

            MainMenu.Visibility = Visibility.Hidden;

            await GameLoop();
        }

        private void Difficult_Click(object sender, RoutedEventArgs e)
        {
            N = (N + 1) % (maxDifficult + 1);

            if (N == 0)
                N = minDifficult;

            DifficultButton.Content = $"Difficult: {N}x{N}";
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private bool backToMenu = false;
        private void BackToMenu_Click(object sender, RoutedEventArgs e)
        {
            backToMenu = true;
            gameStart = false;
            gameState = new GameState(N);
            GameCanvas.Children.Clear();
            DifficultButton.Content = $"Difficult: {N}x{N}";
            MainMenu.Visibility = Visibility.Visible;
        }

        private void PlayAgain_Click(object sender, RoutedEventArgs e)
        {
            backToMenu = false;
            gameStart = true;
            gameState = new GameState(N);
            GameOverMenu.Visibility = Visibility.Hidden;
            MainMenu.Visibility = Visibility.Visible;

        }

    }
}
