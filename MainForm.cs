using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OperatorGame
{
    public partial class MainForm : Form
    {
        private GameForm gameForm;

        public MainForm()
        {
            this.InitializeComponent();
            this.EnumerateGamepads();
        }

        private void EnumerateGamepads()
        {
            IDictionary<Guid, string> gamepads = Gamepad.Enumerate();
            
            this.startButton.Enabled = gamepads.Any();
            this.controllerDropDown.DataSource = gamepads.ToList();
            this.controllerDropDown.ValueMember = "Key";
            this.controllerDropDown.DisplayMember = "Value";
        }

        private void StartButtonClick(object sender, EventArgs e)
        {
            var gamepadID = (Guid) this.controllerDropDown.SelectedValue;

            this.Hide();

            this.gameForm = new GameForm(gamepadID);
            this.gameForm.FormClosed += (x, y) => this.EndGame();
            this.gameForm.Show();
        }

        private void EnumerateButtonClick(object sender, EventArgs e)
        {
            this.EnumerateGamepads();
        }

        private void EndGame()
        {
            this.Show();
        }
    }
}
