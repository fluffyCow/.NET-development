namespace GissaNummerGUI
{
    partial class GNGameWithGUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblHeading = new System.Windows.Forms.Label();
            this.lblGuessHeading = new System.Windows.Forms.Label();
            this.lblPlay = new System.Windows.Forms.Label();
            this.btnYes = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            this.lblPrintScoreList = new System.Windows.Forms.Label();
            this.rtxtScore = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.Location = new System.Drawing.Point(39, 34);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(293, 25);
            this.lblHeading.TabIndex = 0;
            this.lblHeading.Text = "Välkommen till Gissa Numret!";
            // 
            // lblGuessHeading
            // 
            this.lblGuessHeading.AutoSize = true;
            this.lblGuessHeading.Location = new System.Drawing.Point(42, 121);
            this.lblGuessHeading.Name = "lblGuessHeading";
            this.lblGuessHeading.Size = new System.Drawing.Size(146, 13);
            this.lblGuessHeading.TabIndex = 1;
            this.lblGuessHeading.Text = "Här ser du tidigare gissningar:";
            // 
            // lblPlay
            // 
            this.lblPlay.AutoSize = true;
            this.lblPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlay.Location = new System.Drawing.Point(123, 410);
            this.lblPlay.Name = "lblPlay";
            this.lblPlay.Size = new System.Drawing.Size(122, 24);
            this.lblPlay.TabIndex = 2;
            this.lblPlay.Text = "Vill du spela?";
            // 
            // btnYes
            // 
            this.btnYes.Location = new System.Drawing.Point(70, 485);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(76, 36);
            this.btnYes.TabIndex = 0;
            this.btnYes.Text = "Ja";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // btnNo
            // 
            this.btnNo.Location = new System.Drawing.Point(209, 487);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(81, 33);
            this.btnNo.TabIndex = 4;
            this.btnNo.Text = "Nej";
            this.btnNo.UseVisualStyleBackColor = true;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // lblPrintScoreList
            // 
            this.lblPrintScoreList.AutoSize = true;
            this.lblPrintScoreList.Location = new System.Drawing.Point(31, 163);
            this.lblPrintScoreList.Name = "lblPrintScoreList";
            this.lblPrintScoreList.Size = new System.Drawing.Size(0, 13);
            this.lblPrintScoreList.TabIndex = 5;
            this.lblPrintScoreList.Visible = false;
            // 
            // rtxtScore
            // 
            this.rtxtScore.Location = new System.Drawing.Point(24, 154);
            this.rtxtScore.Name = "rtxtScore";
            this.rtxtScore.ReadOnly = true;
            this.rtxtScore.Size = new System.Drawing.Size(308, 253);
            this.rtxtScore.TabIndex = 6;
            this.rtxtScore.Text = "";
            // 
            // GNGameWithGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 573);
            this.Controls.Add(this.rtxtScore);
            this.Controls.Add(this.lblPrintScoreList);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.lblPlay);
            this.Controls.Add(this.lblGuessHeading);
            this.Controls.Add(this.lblHeading);
            this.Name = "GNGameWithGUI";
            this.Text = "Gissa Numret";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.Label lblGuessHeading;
        private System.Windows.Forms.Label lblPlay;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.Label lblPrintScoreList;
        private System.Windows.Forms.RichTextBox rtxtScore;
    }
}

