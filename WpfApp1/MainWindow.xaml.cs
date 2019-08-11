
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
        #region click events
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (mGameEnded)
            {
                newGame();
                return;
            }

            var button = (Button)sender;

            var colomn = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            var index = colomn + (row * 3);
            if (mResults[index] != MarkType.Free)
                return;

            if (mPlayer1turn)
                mResults[index] = MarkType.Cross;
            else
                mResults[index] = MarkType.Nought;

            button.Content = mPlayer1turn ? "X" : "O";

            if (!mPlayer1turn)
                button.Foreground = Brushes.Red;
            // changes value on each click
            mPlayer1turn ^= true;
            #endregion

            #region winner rows
            // check if there is a winner on row 0
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[1] & mResults[2]) == mResults[0])
            {
                // game end
                mGameEnded = true;

                Button0_0.Background = Button1_0.Background = Button2_0.Background = Brushes.Green;
            }

            // check if there is a winner on row 1
            if (mResults[3] != MarkType.Free && (mResults[3] & mResults[4] & mResults[5]) == mResults[3])
            {
                // game end
                mGameEnded = true;

                Button0_1.Background = Button1_1.Background = Button2_1.Background = Brushes.Green;
            }

            // check if there is a winner on row 2
            if (mResults[6] != MarkType.Free && (mResults[6] & mResults[7] & mResults[8]) == mResults[6])
            {
                // game end
                mGameEnded = true;

                Button0_2.Background = Button1_2.Background = Button2_2.Background = Brushes.Green;
            }
            #endregion

            #region winner colomn
            // check if there is a winner on col 0
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[3] & mResults[6]) == mResults[0])
            {
                // game end
                mGameEnded = true;

                Button0_0.Background = Button0_1.Background = Button0_2.Background = Brushes.Green;
            }

            // check if there is a winner on col 1
            if (mResults[1] != MarkType.Free && (mResults[1] & mResults[4] & mResults[7]) == mResults[1])
            {
                // game end
                mGameEnded = true;

                Button1_0.Background = Button1_1.Background = Button1_2.Background = Brushes.Green;
            }

            // check if there is a winner on col 2
            if (mResults[2] != MarkType.Free && (mResults[2] & mResults[5] & mResults[8]) == mResults[2])
            {
                // game end
                mGameEnded = true;

                Button2_0.Background = Button2_1.Background = Button2_2.Background = Brushes.Green;
            }

            #endregion

            #region winner diagonal

            // check if there is a winner on diag top left bottom right
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[4] & mResults[8]) == mResults[0])
            {
                // game end
                mGameEnded = true;

                Button0_0.Background = Button1_1.Background = Button2_2.Background = Brushes.Green;
            }

            // check if there is a winner on diag top right to bottom left
            if (mResults[2] != MarkType.Free && (mResults[2] & mResults[4] & mResults[6]) == mResults[2])
            {
                // game end
                mGameEnded = true;

                Button2_0.Background = Button1_1.Background = Button0_2.Background = Brushes.Green;
            }
            #endregion


            #region draw
            if (!mResults.Any(result => result == MarkType.Free))
            {
                mGameEnded = true;
                //turn all orange
                Container.Children.Cast<Button>().ToList().ForEach(buttons =>
                {
                    buttons.Background = Brushes.Orange;
                });
                #endregion
            }
        }
    }
}
