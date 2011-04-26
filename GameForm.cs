using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace OperatorGame
{
    public partial class GameForm : Form
    {
        private readonly Gamepad gamepad;
        private readonly Timer roundTimer;
        private readonly Random random = new Random();
        private readonly IDictionary<string, Func<Gamepad, bool>> operations = new Dictionary<string, Func<Gamepad, bool>>
            {
                {"Spit tube out", g => g.GetNumberedButton(6)},
                {"Rotate down", g => g.GetNumberedButton(7)},
                {"Rotate up", g => g.GetNumberedButton(5)},
                {"Score", g => g.GetNumberedButton(9)},
                {"Cancel pickup", g => g.GetNumberedButton(0)},
                {"Pickup position", g => g.GetNumberedButton(0)},
                {"Arm to bottom", g => !g.GetNumberedButton(4) && g.GetNumberedButton(1)},
                {"Arm to middle", g => !g.GetNumberedButton(4) && g.GetNumberedButton(2)},
                {"Arm to top", g => !g.GetNumberedButton(4) && g.GetNumberedButton(3)},
                {"Arm to bottom (circle)", g => g.GetNumberedButton(4) && g.GetNumberedButton(1)},
                {"Arm to middle (circle)", g => g.GetNumberedButton(4) && g.GetNumberedButton(2)},
                {"Arm to top (circle)", g => g.GetNumberedButton(4) && g.GetNumberedButton(3)},
            };

        private string currentOperation;
        private Stopwatch roundStopwatch;

        public GameForm(Guid gamepadID)
        {
            this.InitializeComponent();

            this.gamepad = new Gamepad(gamepadID, this.Handle);
            this.operationLabel.Size = this.ClientSize;
            this.roundTimer = new Timer();
            this.roundTimer.Interval = 10;
            this.roundTimer.Tick += this.TimerTick;
            this.roundTimer.Start();

            this.StartRound();
            this.NextOperation();

        }

        private void DoneButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            this.Text =
                string.Format(
                    "{0:00}:{1:00}:{2:00}.{3:00}",
                    this.roundStopwatch.Elapsed.Hours,
                    this.roundStopwatch.Elapsed.Minutes,
                    this.roundStopwatch.Elapsed.Seconds,
                    this.roundStopwatch.Elapsed.Milliseconds);

            this.gamepad.Poll();
            if (!this.gamepad.HasButtonStateChanged || !this.gamepad.IsButtonPressed)
            {
                return;
            }

            string operation = this.operationLabel.Text;
            if (this.operations[operation].Invoke(this.gamepad))
            {
                this.CorrectAnswer();
            }
            else if (operation.EndsWith("(circle)") && this.gamepad.GetNumberedButton(4))
            {
            }
            else
            {
                this.IncorrectAnswer();
            }
        }

        private void NextOperation()
        {
            string operation;
            do
            {
                int index = this.random.Next(0, this.operations.Keys.Count);
                operation = this.operations.Keys.ElementAt(index);
            } while (operation == this.currentOperation);

            this.currentOperation = operation;
            this.operationLabel.Text = operation;
        }

        private void StartRound()
        {
            this.roundStopwatch = Stopwatch.StartNew();
        }

        private void CorrectAnswer()
        {
            var shakeTimer = new Timer();
            shakeTimer.Interval = 100;
            shakeTimer.Tick += (sender, e) =>
            {
                if (shakeTimer.Tag == null)
                {
                    this.BackColor = Color.LimeGreen;
                    this.Location = new Point(this.Location.X, this.Location.Y - 5);
                    shakeTimer.Tag = 1;
                }
                else
                {
                    this.BackColor = Color.FromName("Control");
                    this.Location = new Point(this.Location.X, this.Location.Y + 5);
                    this.NextOperation();
                    this.StartRound();
                    shakeTimer.Stop();
                }
            };
            shakeTimer.Start();
        }

        private void IncorrectAnswer()
        {
            var shakeTimer = new Timer();
            shakeTimer.Interval = 100;
            shakeTimer.Tick += (sender, e) =>
            {
                if (shakeTimer.Tag == null)
                {
                    this.BackColor = Color.OrangeRed;
                    this.Location = new Point(this.Location.X - 10, this.Location.Y);
                    shakeTimer.Tag = 1;
                }
                else if (shakeTimer.Tag.Equals(1))
                {
                    this.Location = new Point(this.Location.X + 15, this.Location.Y);
                    shakeTimer.Tag = 2;
                }
                else if (shakeTimer.Tag.Equals(2))
                {
                    this.Location = new Point(this.Location.X - 15, this.Location.Y);
                    shakeTimer.Tag = 3;
                }
                else
                {
                    this.BackColor = Color.FromName("Control");
                    this.Location = new Point(this.Location.X + 10, this.Location.Y);
                    shakeTimer.Stop();
                }
            };
            shakeTimer.Start();
        }
    }
}
