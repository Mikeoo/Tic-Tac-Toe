
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region private variables
        /// <summary>
        /// Holds the current value of the cells
        /// </summary>
        private MarkType[] mResults;

        /// <summary>
        /// True if player1 turn(x) false if player2 turn (0)
        /// </summary>
        private bool mPlayer1turn;

        /// <summary>
        /// If game has ended true, false if not
        /// </summary>
        private bool mGameEnded;
        private Brush brushes;
        #endregion
        #region default constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            newGame();
        }
        #endregion default constructor defa

        #region startgame
        private void newGame()
        {
            // reserve 9cells in array for res
            mResults = new MarkType[9];

            for (var i = 0; i < mResults.Length; i++)
            {
                mResults[i] = MarkType.Free;

                mPlayer1turn = true;

                Container.Children.Cast<Button>().ToList().ForEach(button =>
                {
                    button.Content = string.Empty;
                    button.Background = Brushes.White;
                    button.Foreground = Brushes.Blue;

                });
                // game has ended
                mGameEnded = false;
            }
        }
        #endregion
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
