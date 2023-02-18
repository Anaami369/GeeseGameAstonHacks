using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeeseGameAstonHacks
{
    public partial class GameScreen : UserControl
    {
        #region global variables
        Boolean leftArrowDown, rightArrowDown, escKeyDown, spaceDown, gamePaused;
        bool jumpingUp = false;
        bool jumpingDown = false;

        int gap = 0;
        int playerSpeed = 5;
        int playerSize = 100;

        Human human;
        Stumps smallStump;
        Stumps midStump;
        Stumps largeStump;

        Image player = Properties.Resources.player;

        #endregion

        public GameScreen()
        {
            InitializeComponent();
            onStart();
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            //player 1 button releases
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Escape:
                    escKeyDown = false;
                    break;
                case Keys.Space:
                    spaceDown = false;
                    break;

                default:
                    break;
            }
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Escape:
                    escKeyDown = true;
                    break;
                case Keys.Space:
                    spaceDown = true;
                    break;

                default:
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            pauseScreenEnabled();

            #region move hero
            if (leftArrowDown)
            {
                human.Move("left");
            }
            if (rightArrowDown)
            {
                human.Move("right");
            }
            if (spaceDown)
            {
                jumpingUp = true;
            }

            if (jumpingUp)
            {
                human.Move("up");

                if (human.y <= 203)
                {
                    jumpingUp = false;
                    jumpingDown = true;
                }
            }

            if (jumpingDown)
            {
                human.Move("down");

                if (human.y >= 525)
                {
                    jumpingUp = false;
                    jumpingDown = false;
                }
            }
            #endregion

            Random randNum = new Random();
            int randGap = randNum.Next(314, 670);
            int randStump = randNum.Next(1, 3);



            Refresh();
        }

        private void resumeButton_Click(object sender, EventArgs e)
        {
            gameTimer.Enabled = true;
            pauseLabel.Visible = false;
            resumeButton.Enabled = false;
            resumeButton.Visible = false;
            menuButton.Enabled = false;
            menuButton.Visible = false;
            gamePaused = false;
            this.Focus();
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            gamePaused = false;
            OnEnd();
        }

        public void onStart()
        {
            pauseLabel.Visible = false;
            gameTimer.Enabled = true;
            menuButton.Enabled = false;
            menuButton.Visible = false;
            resumeButton.Enabled = false;
            resumeButton.Visible = false;

            leftArrowDown = false;
            rightArrowDown = false;
            escKeyDown = false;
            spaceDown = false;

            gameTimer.Enabled = true;

            human = new Human(this.Width / 2 - playerSize / 2, 525, playerSpeed, playerSize);
        }

        public void pauseScreenEnabled()
        {
            if (escKeyDown)
            {
                gamePaused = true;
            }
            if (gamePaused)
            {
                pauseLabel.Visible = true;
                gameTimer.Enabled = false;
                menuButton.Enabled = true;
                menuButton.Visible = true;
                resumeButton.Enabled = true;
                resumeButton.Visible = true;
            }
            else
            {
                gameTimer.Enabled = true;
            }

        }

        public void OnEnd()
        {
            gameTimer.Stop();

            Form f = this.FindForm();
            f.Controls.Remove(this);

            HomePage gos = new HomePage();
            f.Controls.Add(gos);

            gos.Location = new Point(0, 0);

            gos.Focus();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            #region draw hero character
            e.Graphics.DrawImage(player, human.x, human.y, playerSize, playerSize);
            #endregion
        }
    }
}
