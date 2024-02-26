using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordGenerator
{
    public partial class Form1 : Form
    {

        int currentPasswordLength = 0;
        Random character = new Random();

        private void passwordGenerator(int passwordLength)
        {
            String allCharacters = "ABCDEFGHIJKLMNOPRSTUVZXYabcdefghijklmnoprstuvzxy0123456789!#$&@";
            String upperCase = "ABCDEFGHIJKLMNOPRSTUVZXY";
            String lowerCase = "abcdefghijklmnoprstuvzxy";
            String specialSymbols = "!#$&@";
            String numbers = "0123456789";

            String randomPassword = "";
            for(int i = 0; i < passwordLength; i++)
            {
                int randomNum;
                if(i == 0)
                {
                    randomNum = character.Next(0, upperCase.Length);
                    randomPassword += upperCase[randomNum];
                }
                randomNum = character.Next(0, allCharacters.Length);
                randomPassword += allCharacters[randomNum];
            }
            passwordLabel.Text = randomPassword;
        }

        public Form1()
        {
            InitializeComponent();
            passwordLengthSlider.Minimum = 5;
            passwordLengthSlider.Maximum = 20;
            passwordGenerator(5);
        }

        private void CopyPasswordButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(passwordLabel.Text);
        }

        private void passwordLengthSlider_Scroll(object sender, EventArgs e)
        {
            PasswordLengthLabel.Text = "Password Length: " + passwordLengthSlider.Value.ToString();
            currentPasswordLength = passwordLengthSlider.Value;
            passwordGenerator(currentPasswordLength);
        }

        private void generatePasswordButton_Click(object sender, EventArgs e)
        {
            passwordGenerator(currentPasswordLength);
        }
    }
}
