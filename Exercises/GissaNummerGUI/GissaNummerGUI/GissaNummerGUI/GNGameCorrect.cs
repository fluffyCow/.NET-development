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
    /// Windows displayed when the user is correct.
    /// Asks the user to save the result to the highscore
    /// </summary>
    public partial class GNGameCorrect : Form
    {
        //Reference to start window
        public Form RefToFormStart { get; set; }

        //The current score
        private int numberOfGuesses;

        /// <summary>
        /// Initialize the window telling the user was correct
        /// </summary>
        /// <param name="guess">The number of guesses before correct</param>
        public GNGameCorrect(int guess)
        {
            InitializeComponent();

            numberOfGuesses = guess;
            lblHeading.Text = "Makalöst! Du gissade rätt efter " + numberOfGuesses + " försök!";

        }

        /// <summary>
        /// Save the name and scor into the high score file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            //Only save if there is something in the textbox
            if (!String.IsNullOrEmpty(tbxName.Text)) { 
            Score score = new Score() { Name = tbxName.Text, Guess = numberOfGuesses };

                //User want to exit, save the highscore
                HighScore hs = new HighScore();

                //Since the Scoreboard need an array list save the score to a list first
                ArrayList scoreBoard = new ArrayList {score};

                //Try to save the current highscore.
                //Let the user know if the save was successful or not
                if (!hs.SaveScore(scoreBoard))
                {
                    lblHeading.Text = "Något gick fel när listan sparades. Kontakta din systemadministratör";
                }
                else
                {
                    //Hide the textbox and save button so the user cannot save multiple times
                    tbxName.Hide();
                    btnSave.Hide();
                    lblName.Hide();
                    lblHeading.Text = "Ditt resultat sparades. Vill du spela igen?";

                    //Visa föregående fönster
                    RefToFormStart.Show();

                    //Stäng nuvarande fönster
                    //                    this.Visible = false;
                    this.Close();
                }
            } else
            {
                lblHeading.Text = "Du måste skriva ditt namn för att det ska sparas!";
            }
        }

    }
}
