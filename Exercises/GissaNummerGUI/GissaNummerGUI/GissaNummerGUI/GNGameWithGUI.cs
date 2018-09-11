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
    /// The main class for the game.
    /// Here is the welcome screen and score board
    /// </summary>
    public partial class GNGameWithGUI : Form
    {


        public GNGameWithGUI()
        {
            InitializeComponent();
            LoadHighScore();
        }

        public void LoadHighScore() { 
            //Read the existing high score from file
            HighScore scoreList = new HighScore();
            ArrayList printList = scoreList.PrintScore();

            //Reset the textbox
            rtxtScore.Text = null;

            ///If there are any previous results in the high score file. Show them
            if (printList.Count > 0)
            {

                lblPrintScoreList.Text = "Namn   tResultat\n";

                foreach (Score s in printList)
                {
                    {
                        //lblPrintScoreList.Text += s.Name + "\t\t" + s.Guess + "\n";
                        rtxtScore.Text += s.Name + "\t\t\t\t" + s.Guess + "\n";
                    }
                }
                //If there are no previous result
            }
            else
            {
                //Hide the score box
                rtxtScore.Hide();
                lblPrintScoreList.Text = "Du verkar vara första spelaren, bli först med att hamna i high score!\n";
            }

            //Return the string containing the UI
            lblPrintScoreList.Visible = true;
        }

        /// <summary>
        /// Exit the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNo_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Start a new game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnYes_Click(object sender, EventArgs e)
        {
            //Nytt object för nästa spelfönster
            GNGame newGame = new GNGame();

            //Create an event handler that listens to PerformHighScoreUpdate in the game (called when exiting the game)
            newGame.PerformHighScoreUpdate += new EventHandler(newGame_PerformHighScoreUpdate);

            //Koppla ihop nuvarande fönster med det nya fönstret
            newGame.RefToFormStart = this;
            //Göm nuvarande fönster
            this.Visible = false;
            //Visa nästa fönster
            newGame.Show();
        }

        /// <summary>
        /// Test to reload the highscore when returning to the main window
        /// Triggered by event in the GNGame class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newGame_PerformHighScoreUpdate(object sender, EventArgs e)
        {
            rtxtScore.Text = null;
            LoadHighScore();
        }
    }
}
