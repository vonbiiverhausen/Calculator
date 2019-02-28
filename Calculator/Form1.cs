using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator {
    public partial class Form1 : Form {

        private bool clearField;
        CalcController controller;

        public Form1() {
            InitializeComponent();
            this.KeyDown += Form1_Keydown;
            controller = new CalcController();
        }

        /* KEYBOARD SHORTCUTS */
        private void Form1_Keydown(object sender, KeyEventArgs e) {
            switch (e.KeyValue) {
                case 48:
                case 96:
                    addChar('0');
                    break;
                case 49:
                case 97:
                    addChar('1');
                    break;
                case 50:
                case 98:
                    addChar('2');
                    break;
                case 51:
                case 99:
                    addChar('3');
                    break;
                case 52:
                case 100:
                    addChar('4');
                    break;
                case 53:
                case 101:
                    addChar('5');
                    break;
                case 54:
                case 102:
                    addChar('6');
                    break;
                case 55:
                case 103:
                    addChar('7');
                    break;
                case 56:
                case 104:
                    addChar('8');
                    break;
                case 57:
                case 105:
                    addChar('9');
                    break;
                case 110:
                case 188:
                case 190:
                    addChar('.');
                    break;
                case 107:
                case 187:
                    addChar('+');
                    break;
                case 109:
                case 189:
                    addChar('-');
                    break;
                case 106:
                    addChar('x');
                    break;
                case 111:
                    addChar('/');
                    break;
                case 13:
                    controller.storeValues(txt_screen.Text);    // Store current values
                    txt_screen.Text = controller.Calculate();   // Get result of calculation
                    controller.storeValues(txt_screen.Text, prepend: "= ");    // Store result of calculation
                    txt_stored.Lines = controller.getValueArray();  // Update storage screen with updated list
                    break;
                default:
                    Console.WriteLine(e.KeyValue);
                    break;
            }
        }

        /* Check if character is allowed */
        private bool charIsAllowed(char character) {
            return character != '.' &&
                character != '/' &&
                character != 'x' &&
                character != '-' &&
                character != '+';
        }

        /* Check if character is an operator */
        private bool isOperator(char character) {
            return character == '/' ||
                character == 'x' ||
                character == '+' ||
                character == '-';
        }

        /* Check if string already contains an operator */
        private bool hasOperator(string s) {
            return s.Contains('+') ||
                s.Contains('-') ||
                s.Contains('x') ||
                s.Contains('/');
        }

        /* Check if string already has a character that is only allowed once*/
        private bool hasCharAllowedOnce() {
            return txt_screen.Text.Contains(".") ||
            txt_screen.Text.Contains("+") ||
            txt_screen.Text.Contains("-") ||
            txt_screen.Text.Contains("/") ||
            txt_screen.Text.Contains("x");
        }

        /* Method for adding characters */
        private void addChar(char character) {

            /* If character to be added is an operator and current text doesn't contain
             * an operator, add said operator 
             * This is to avoid multiple operators on single line, like +++-/5+--+ */
            if (isOperator(character) && !hasOperator(txt_screen.Text)) {
                controller.storeValues(txt_screen.Text);

                txt_stored.Lines = controller.getValueArray();
                txt_screen.Text = character.ToString()+" ";
            }

            /* If character to be added is a comma and the current text doesn't contain
             * a comma, add comma
             * This is to avoid values with multiple commas, ie. "1....2.3.5"*/
            if (character == '.' && !txt_screen.Text.Contains('.')) {
                txt_screen.Text += character.ToString();
            }

            /* If character to be added isn't an operator or a comma
             AND
             1) text equals "0", then replace with character
             2) text doesn't equal "0", then append character
             This is to avoid strings like "00000000" and "0123"
             */
            if (!isOperator(character) && character != '.') {
                if (txt_screen.Text.Equals("0")) {
                    txt_screen.Text = character.ToString(); // if char = '0', this might be wasteful
                } else {
                    txt_screen.Text += character;
                }
            }
        }

        /* BUTTON FUNCTIONS */
        private void btn_1_Click(object sender, EventArgs e) {
            addChar('1');
        }

        private void btn_2_Click(object sender, EventArgs e) {
            addChar('2');
        }

        private void btn_3_Click(object sender, EventArgs e) {
            addChar('3');
        }

        private void btn_4_Click(object sender, EventArgs e) {
            addChar('4');
        }

        private void btn_5_Click(object sender, EventArgs e) {
            addChar('5');
        }

        private void btn_6_Click(object sender, EventArgs e) {
            addChar('6');
        }

        private void btn_7_Click(object sender, EventArgs e) {
            addChar('7');
        }

        private void btn_8_Click(object sender, EventArgs e) {
            addChar('8');
        }

        private void btn_9_Click(object sender, EventArgs e) {
            addChar('9');
        }

        private void btn_0_Click(object sender, EventArgs e) {
            addChar('0');
        }

        private void btn_decimal_Click(object sender, EventArgs e) {
            addChar('.');
        }

        private void btn_div_Click(object sender, EventArgs e) {
            addChar('/');
        }

        private void btn_mul_Click(object sender, EventArgs e) {
            addChar('x');
        }

        private void btn_sub_Click(object sender, EventArgs e) {
            addChar('-');
        }

        private void btn_add_Click(object sender, EventArgs e) {
            addChar('+');
        }

        private void btn_calc_Click(object sender, EventArgs e) {
            controller.storeValues(txt_screen.Text);    // Store current values
            txt_screen.Text = controller.Calculate();   // Get result of calculation
            controller.storeValues(txt_screen.Text);    // Store result of calculation
            txt_stored.Lines = controller.getValueArray();  // Update storage screen with updated list
        }
    }
}
