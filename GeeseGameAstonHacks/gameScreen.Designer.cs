
namespace GeeseGameAstonHacks
{
    partial class GameScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.resumeButton = new System.Windows.Forms.Button();
            this.menuButton = new System.Windows.Forms.Button();
            this.pauseLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.livesLabel = new System.Windows.Forms.Label();
            this.geeseTimer = new System.Windows.Forms.Timer(this.components);
            this.timeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 15;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // resumeButton
            // 
            this.resumeButton.BackColor = System.Drawing.Color.DarkGray;
            this.resumeButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.resumeButton.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.resumeButton.ForeColor = System.Drawing.Color.Black;
            this.resumeButton.Location = new System.Drawing.Point(781, 457);
            this.resumeButton.Margin = new System.Windows.Forms.Padding(4);
            this.resumeButton.Name = "resumeButton";
            this.resumeButton.Size = new System.Drawing.Size(126, 48);
            this.resumeButton.TabIndex = 8;
            this.resumeButton.Text = "resume game";
            this.resumeButton.UseVisualStyleBackColor = false;
            this.resumeButton.Click += new System.EventHandler(this.resumeButton_Click);
            // 
            // menuButton
            // 
            this.menuButton.BackColor = System.Drawing.Color.DarkGray;
            this.menuButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.menuButton.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuButton.ForeColor = System.Drawing.Color.Black;
            this.menuButton.Location = new System.Drawing.Point(781, 403);
            this.menuButton.Margin = new System.Windows.Forms.Padding(4);
            this.menuButton.Name = "menuButton";
            this.menuButton.Size = new System.Drawing.Size(126, 48);
            this.menuButton.TabIndex = 7;
            this.menuButton.Text = "return to menu";
            this.menuButton.UseVisualStyleBackColor = false;
            this.menuButton.Click += new System.EventHandler(this.menuButton_Click);
            // 
            // pauseLabel
            // 
            this.pauseLabel.BackColor = System.Drawing.Color.Transparent;
            this.pauseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.pauseLabel.ForeColor = System.Drawing.Color.Firebrick;
            this.pauseLabel.Location = new System.Drawing.Point(653, 339);
            this.pauseLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.pauseLabel.Name = "pauseLabel";
            this.pauseLabel.Size = new System.Drawing.Size(389, 60);
            this.pauseLabel.TabIndex = 6;
            this.pauseLabel.Text = "Game Paused";
            this.pauseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(0, 820);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1695, 25);
            this.label1.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.GreenYellow;
            this.label3.Location = new System.Drawing.Point(3, 810);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1692, 10);
            this.label3.TabIndex = 11;
            // 
            // livesLabel
            // 
            this.livesLabel.BackColor = System.Drawing.Color.Transparent;
            this.livesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.livesLabel.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.livesLabel.Location = new System.Drawing.Point(3, 0);
            this.livesLabel.Name = "livesLabel";
            this.livesLabel.Size = new System.Drawing.Size(199, 59);
            this.livesLabel.TabIndex = 12;
            this.livesLabel.Text = "label2";
            this.livesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // geeseTimer
            // 
            this.geeseTimer.Interval = 1000;
            this.geeseTimer.Tick += new System.EventHandler(this.geeseTimer_Tick);
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.BackColor = System.Drawing.Color.Transparent;
            this.timeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLabel.Location = new System.Drawing.Point(1574, 0);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(67, 25);
            this.timeLabel.TabIndex = 13;
            this.timeLabel.Text = "Time: ";
            this.timeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GeeseGameAstonHacks.Properties.Resources.static_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.livesLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.resumeButton);
            this.Controls.Add(this.menuButton);
            this.Controls.Add(this.pauseLabel);
            this.DoubleBuffered = true;
            this.Name = "GameScreen";
            this.Size = new System.Drawing.Size(1695, 845);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameScreen_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GameScreen_KeyUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.GameScreen_PreviewKeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Button resumeButton;
        private System.Windows.Forms.Button menuButton;
        private System.Windows.Forms.Label pauseLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label livesLabel;
        private System.Windows.Forms.Timer geeseTimer;
        private System.Windows.Forms.Label timeLabel;
    }
}
