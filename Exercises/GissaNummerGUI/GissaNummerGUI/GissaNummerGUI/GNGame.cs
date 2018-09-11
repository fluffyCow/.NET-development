using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GissaNummerGUI
{
    /// <summary>
    /// The actual game.
    /// Asks the user to guess until the guess is correct
    /// </summary>
    public partial class GNGame : Form
    {
        //Reference to start window
        public Form RefToFormStart { get; set;}

        //This is called to reload the highscore from the start form
        public event EventHandler PerformHighScoreUpdate;

        private int numberOfGuesses=0;
        private int numberToGuess;

        //Create a score board holding the name and result of all rounds
        private ArrayList scoreBoard = new ArrayList();           

        /// <summary>
        /// Creates a new game
        /// Needs a reference to the main game so an update of the highscore can be triggered
        /// @todo, see if this can be solved using an event instead
        /// </summary>
        /// <param name="startForm">GNGameWithGui this reference</param>
        public GNGame()
        {
            InitializeComponent();

            //Reset the number of guesses and the number to guess
            ResetGame();
        }

        /// <summary>
        /// Reset the game and start over
        /// </summary>
        private void ResetGame()
        {
            //Create random number 1 to 100
            Random random = new Random();
            numberToGuess = random.Next(1, 11);

            lblHeading.Text = "Jag tänker på ett tal mellan 1 och 100. Gissa vilket det är:";
            txtNumberGuess.Text = null;
            numberOfGuesses =0;
        }

        private void GNGame_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// is the guess correct?
        /// </summary>
        /// <param name="guess">the number the user has guessed</param>
        /// <returns>returns 0 if equal, 1 if bigger -1 if smaller</returns>
        private int CheckGuess(int guess)
        {
            if (guess == numberToGuess)
            {
                return 0;
            }
            return guess > numberToGuess ? 1 : -1;
        }

        /// <summary>
        /// When the button is clicked see if the guess is correct
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuess_Click(object sender, EventArgs e)
        {
            
            //Try to parse the textbox to a number
            if (Int32.TryParse(txtNumberGuess.Text, out int guess))
            {
                //Increase the amount of guesses
                numberOfGuesses++;

                //If the guesses number is too high
                if (CheckGuess(guess) > 0)
                {
                    lblHeading.Text = "Nope, talet är lägre än din gissning. Försök igen!";
                }
                //If it's too low
                else if (CheckGuess(guess) < 0)
                {
                    lblHeading.Text = "Nope, talet är högre än din gissning. Försök igen!";
                }
                //If it's correct, open a new windows telling the number is correct and save the result to the highscore
                else
                {
                    //Nytt object för nästa spelfönster
                    GNGameCorrect newGame = new GNGameCorrect(numberOfGuesses);
                    //Koppla ihop nuvarande fönster med det nya fönstret
                    newGame.RefToFormStart = this;
                    //Göm nuvarande fönster
                    this.Visible = false;
                    //Visa nästa fönster
                    newGame.Show();

                    //Starta nytt spel
                    ResetGame();
                } 

            } else
            {
                lblHeading.Text = "Alltså, det är bättre om du anger ett tal istället. 1-100";
            }

            //Clear the textbox from the old guess
            txtNumberGuess.Text = null;
        }
        

        /// <summary>
        /// Exit the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            //           Application.Exit();

            InvokeHighScoreUpdate();

            //Visa föregående fönster
            RefToFormStart.Show();
     //       mainGame.LoadHighScore();
            
            //Stäng fönstret
            this.Close();
        }

        /// <summary>
        /// Restart the game with a new number and score to zero
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRestart_Click(object sender, EventArgs e)
        {
            ResetGame();
        }

        
        /// <summary>
        /// Call this to update the score board in the start form
        /// </summary>
        private void InvokeHighScoreUpdate()
        {
            EventHandler handler = this.PerformHighScoreUpdate;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
    }
}

 