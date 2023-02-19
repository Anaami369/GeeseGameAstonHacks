using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using System.Timers;
using System.Media;

namespace GeeseGameAstonHacks
{
    public partial class GameScreen : UserControl
    {
        #region global variables
        Boolean leftArrowDown, rightArrowDown, escKeyDown, spaceDown, gamePaused;
        bool jumpingUp = false;
        bool jumpingDown = false;
        bool ifGeese = false;
        bool movePoop = false;
        bool ifPoop = false;
        bool ifEgg = false;
        bool moveEgg = false;

        int gap = 0;
        int playerSpeed = 3;
        int stumpSpeed = 10;
        int playerSize = 100;
        int geeseSpeed = 15;

        int shortStumpHeight = 100;
        int midStumpHeight = 150;
        int tallStumpHeight = 200;
        int stumpWidth = 100;

        int geeseHeight = 50;
        int geeseWidth = 150;
        int poopSpeed = 10;
        int poopScreenSpeed = 15;
        int poopSize = 10;

        int eggInterval = 15;
        int eggHeight = 30;
        int eggWidth = 50;

        int lives = 5;
        int count = 0;
        int time = 60;
        int score = 0;

        Human human;

        List<Stump> smallStump = new List<Stump>();
        List<Stump> midStump = new List<Stump>();
        List<Stump> largeStump = new List<Stump>();

        List<Honk> geese = new List<Honk>();

        List<Poop> poop = new List<Poop>();

        List<Egg> badEgg = new List<Egg>();


        SoundPlayer honk = new SoundPlayer(Properties.Resources.honk_sound);
        SoundPlayer pop = new SoundPlayer(Properties.Resources.pop);

        System.Timers.Timer myTimer = new System.Timers.Timer();

        SolidBrush boxBrush = new SolidBrush(Color.White);

        private Random randNum = new Random();
        #endregion

        public GameScreen()
        {
            InitializeComponent();
            onStart();
        }

        private void geeseTimer_Tick(object sender, EventArgs e)
        {
            time--;
            eggInterval--;

            timeLabel.Text = "Time: " + time;

            if (time == 0)
            {
                ifGeese = true;
                geeseFormalities();
                ifPoop = true;
                time = 60;
            }

            if (eggInterval == 0)
            {
                ifEgg = true;
                moveEgg = true;
                makeEgg();
            }

        }

        public void makeEgg()
        {
            if (ifEgg == true)
            {
                Egg newEgg = new Egg(1100, 410, eggHeight, eggWidth);
                badEgg.Add(newEgg);
                ifEgg = false;
            }
        }

        public void geeseFormalities()
        {
            makeGeese();
        }

        public void makeGeese()
        {
            honk.Play();
            Honk newGeese = new Honk(0, 0, geeseHeight, geeseWidth, geeseSpeed);
            geese.Add(newGeese);
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

            #region move hero and stumps
            if (leftArrowDown)
            {

                if (human.x <= 100)
                {
                    foreach (Stump b in smallStump)
                    {
                        b.Move("left");
                    }
                }
                else
                {
                    human.Move("left");

                    foreach (Stump b in smallStump)
                    {
                        b.Move("left");
                    }
                }

                if (movePoop == true)
                {
                    foreach (Poop b in poop)
                    {
                        b.Move("left", poopScreenSpeed);
                    }
                }

                if (moveEgg == true)
                {

                    foreach (Egg b in badEgg.ToList())
                    {
                        b.Move("left", stumpSpeed);

                        if (b.x < 0)
                        {
                            badEgg.Remove(b);
                            moveEgg = false;
                        }
                    }
                }
            }

            if (rightArrowDown)
            {
                if (human.x >= 500)
                {
                    foreach (Stump b in smallStump)
                    {
                        b.Move("right");
                    }
                }
                else
                {
                    human.Move("right");

                    foreach (Stump b in smallStump)
                    {
                        b.Move("right");
                    }
                }

                if (movePoop == true)
                {
                    foreach (Poop b in poop)
                    {
                        b.Move("right", poopScreenSpeed);
                    }
                }

                if (moveEgg == true)
                {

                    foreach (Egg b in badEgg.ToList())
                    {
                        b.Move("right", stumpSpeed);
                    }
                }
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

                if (human.y >= 556)
                {
                    jumpingUp = false;
                    jumpingDown = false;
                }
            }
            #endregion

            #region make a new stump
            int randGap = randNum.Next(500, 800);
            gap = randGap;

            if (smallStump.Count > 0 && (1550 - smallStump[smallStump.Count - 1].x) > gap)
            {
                makeSmallStump();
            }
            #endregion

            #region collision check with stump
            Rectangle humanRec = new Rectangle(human.x, human.y, human.speed, human.playerSize);

            for (int i = 0; i < count; i++)
            {
                Rectangle smallStumpRec = new Rectangle(smallStump[i].x, smallStump[i].y, smallStump[i].height, smallStump[i].width);

                if (humanRec.IntersectsWith(smallStumpRec))
                {
                    lives--;
                    livesLabel.Text = "";
                    livesLabel.Text = "Lives: " + lives;

                    if (lives == 0)
                    {
                        OnEnd();
                    }

                    onStart();
                }
            }

            if (poop.Count > 0)
            {
                for (int i = 0; i < poop.Count; i++)
                {
                    Rectangle poopRec = new Rectangle(poop[i].x, poop[i].y, poop[i].size, poop[i].size);

                    if (humanRec.IntersectsWith(poopRec))
                    {
                        lives--;
                        livesLabel.Text = "";
                        livesLabel.Text = "Lives: " + lives;

                        if (lives == 0)
                        {
                            OnEnd();
                        }

                        onStart();
                    }
                }
            }

            if (badEgg.Count > 0)
            {
                for (int i = 0; i < badEgg.Count; i++)
                {
                    Rectangle poopRec = new Rectangle(badEgg[i].x, badEgg[i].y, badEgg[i].height, badEgg[i].width);

                    if (humanRec.IntersectsWith(poopRec))
                    {
                        score++;
                        scoreLabel.Text = "";
                        scoreLabel.Text = "Score: " + score;

                        foreach (Egg b in badEgg.ToList())
                        {
                            badEgg.Remove(b);
                            eggInterval = 15;
                        }

                        if (score == 22)
                        {
                            OnWin();
                        }
                    }
                }
            }

            #endregion

            #region move geese and poop
            if (ifGeese == true)
            {
                honk.Play();
                foreach (Honk b in geese.ToList())
                {
                    b.GeeseMove(playerSpeed);

                    if (b.x > 1695)
                    {
                        geese.Remove(b);
                        ifGeese = false;
                    }

                    if (b.x > 850 && b.x < 1695)
                    {
                        int poopPlace = randNum.Next(300, 1650);

                        {
                            if (ifPoop == true)
                            {
                                Poop newPoop = new Poop(poopPlace, geeseHeight, poopSize, Color.DarkGreen);
                                poop.Add(newPoop);

                                movePoop = true;

                                ifPoop = false;
                            }
                        }
                    }
                }
            }


            foreach (Poop b in poop.ToList())
            {
                b.Move(poopSpeed);

                if (b.y > 845)
                {
                    poop.Remove(b);
                }

                if (b.y > 845)
                {
                    movePoop = false;
                }
            }
            #endregion

            Refresh();
        }

        public void makeSmallStump()
        {
            Stump smallNew = new Stump(1100 + gap, 590, shortStumpHeight, stumpWidth, stumpSpeed);
            smallStump.Add(smallNew);

            count++;
        }

        public void makeMidStump()
        {
            Stump MediumNew = new Stump(1100 + gap, 540, midStumpHeight, stumpWidth, stumpSpeed);
            midStump.Add(MediumNew);
        }

        public void makeTallStump()
        {
            Stump LargeNew = new Stump(1100 + gap, 490, tallStumpHeight, stumpWidth, stumpSpeed);
            largeStump.Add(LargeNew);
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
            geeseTimer.Enabled = true;

            human = new Human(100, 556, playerSpeed, playerSize);

            livesLabel.Text = "Lives: " + lives;
            scoreLabel.Text = "Score: " + score;

            makeSmallStump();
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

            LoseScreen gos = new LoseScreen();
            f.Controls.Add(gos);

            gos.Location = new Point(0, 0);

            gos.Focus();
        }

        public void OnWin()
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            WinScreen gos = new WinScreen();
            f.Controls.Add(gos);

            gos.Location = new Point(0, 0);

            gos.Focus();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            #region draw hero character
            e.Graphics.DrawImage(Properties.Resources.player, human.x, human.y, playerSize, playerSize);
            #endregion

            #region draw geese
            foreach (Honk b in geese)
            {
                e.Graphics.DrawImage(Properties.Resources.angry_goose, b.x, b.y, geeseHeight, geeseWidth);
            }

            #endregion

            #region draw eggs

            foreach (Egg b in badEgg)
            {
                e.Graphics.DrawImage(Properties.Resources.bad_egg, b.x, b.y, eggHeight, eggWidth);
                pop.Play();
            }

            #endregion

            foreach (Poop b in poop)
            {
                boxBrush.Color = b.color;
                e.Graphics.FillRectangle(boxBrush, b.x, b.y, b.size, b.size);
            }
            #region draw poop

            #endregion

            #region draw stumps
            foreach (Stump b in smallStump)
            {
                e.Graphics.DrawImage(Properties.Resources.treeStumpShort, b.x, b.y, stumpWidth, shortStumpHeight);
            }

            foreach (Stump b in midStump)
            {
                e.Graphics.DrawImage(Properties.Resources.treeStumpTall, b.x, b.y, stumpWidth, midStumpHeight);
            }

            foreach (Stump b in largeStump)
            {
                e.Graphics.DrawImage(Properties.Resources.treeStumpTaller, b.x, b.y, stumpWidth, tallStumpHeight);
            }

            #endregion
        }
    }
}
