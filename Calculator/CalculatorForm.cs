using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        private double answer = 0;
        private bool isOperationActive = false;
        private string operation = "";

        public Calculator()
        {
            InitializeComponent();
        }

        private void ButtonNumber_Click(object sender, EventArgs e)
        {
            if((result.Text == "0") || isOperationActive)
                result.Clear();

            isOperationActive = false;
            Button buttonNumber = (Button)sender;

            if(buttonNumber.Text == ",")
            {
                if(!result.Text.Contains(","))
                    result.Text += buttonNumber.Text;
            }
            else
                result.Text += buttonNumber.Text;

            buttonEqual.Focus();
        }

        private void ButtonCE_Click(object sender, EventArgs e)
        {
            if (currentExpression.Text == "")
                buttonC.PerformClick();
            else
            {
            result.Text = "0";
            isOperationActive = false;
            }

            buttonEqual.Focus();
        }

        private void ButtonC_Click(object sender, EventArgs e)
        {
            result.Text = "0";
            answer = 0;
            currentExpression.Text = "";
            isOperationActive = false;

            buttonEqual.Focus();
        }

        private void ButtonOperation_Click(object sender, EventArgs e)
        {
            Button buttonOperation = (Button)sender;

            if (!isOperationActive)
            {
                buttonEqual.PerformClick();
                operation = buttonOperation.Text;
                answer = double.Parse(result.Text);
                currentExpression.Text = answer + " " + operation;
                result.Text = "";
                isOperationActive = true;
            }

            buttonEqual.Focus();
        }

        private void ButtonEqual_Click(object sender, EventArgs e)
        {
            switch (operation)
            {
                case "+":
                    result.Text = Convert.ToString(answer + double.Parse(result.Text));
                    break;
                case "-":
                    result.Text = Convert.ToString(answer - double.Parse(result.Text));
                    break;
                case "*":
                    result.Text = Convert.ToString(answer * double.Parse(result.Text));
                    break;
                case "/":
                    result.Text = Convert.ToString(answer / double.Parse(result.Text));
                    break;
                default:
                    break;
            }

            currentExpression.Text = "";
            operation = "";
            isOperationActive = false;
        }

        private void Calculator_KeyDown(object sender, KeyEventArgs e)
        {

            Keys key = e.KeyCode;

            if (key == Keys.NumPad1)
                buttonOne.PerformClick();
            if (key == Keys.NumPad2)
                buttonTwo.PerformClick();
            if (key == Keys.NumPad3)
                buttonThree.PerformClick();
            if (key == Keys.NumPad4)
                buttonFour.PerformClick();
            if (key == Keys.NumPad5)
                buttonFive.PerformClick();
            if (key == Keys.NumPad6)
                buttonSix.PerformClick();
            if (key == Keys.NumPad7)
                buttonSeven.PerformClick();
            if (key == Keys.NumPad8)
                buttonEight.PerformClick();
            if (key == Keys.NumPad9)
                buttonNine.PerformClick();
            if (key == Keys.NumPad0)
                buttonZero.PerformClick();
            if (key == Keys.Decimal)
                buttonComma.PerformClick();

            if (key == Keys.Back)
                buttonCE.PerformClick();

            if (key == Keys.Add)
                buttonPlus.PerformClick();
            if (key == Keys.Subtract)
                buttonMinus.PerformClick();
            if (key == Keys.Multiply)
                buttonTimes.PerformClick();
            if (key == Keys.Divide)
                buttonSlash.PerformClick();
        }
    }
}
