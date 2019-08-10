
using System;
using System.Windows;


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

        private void newGame()
        {
            throw new NotImplementedException();
        }
    }
}
