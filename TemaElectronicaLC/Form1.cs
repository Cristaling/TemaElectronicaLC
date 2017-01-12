using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TemaElectronicaLC.Managers;
using TemaElectronicaLC.Util;

namespace TemaElectronicaLC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void convertButton_Click(object sender, EventArgs e)
        {
            try
            {
                BaseNumber input1 = new BaseNumber(Convert.ToInt32(inputBaseBox.Text), inputTextBox.Text);
                BaseNumber output = ConversionManager.convertToBaseByInter(input1, Convert.ToInt32(outputBaseBox.Text));
                outputTextBox.Text = output.numar;
            }
            catch (Exception ex)
            {
                errorLabel.Text = "Una din bazele selectate nu este valida";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                BaseNumber input1 = new BaseNumber(Convert.ToInt32(inputBaseBox.Text), inputTextBox.Text);
                BaseNumber input2 = new BaseNumber(Convert.ToInt32(inputBaseBox2.Text), inputTextBox2.Text);
                BaseNumber output = ConversionManager.addNumbersByInter(input1, input2, Convert.ToInt32(outputBaseBox.Text));
                outputTextBox.Text = output.numar;
            }
            catch (Exception ex)
            {
                errorLabel.Text = "Una din bazele selectate nu este valida";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                BaseNumber input1 = new BaseNumber(Convert.ToInt32(inputBaseBox.Text), inputTextBox.Text);
                BaseNumber input2 = new BaseNumber(Convert.ToInt32(inputBaseBox2.Text), inputTextBox2.Text);
                BaseNumber output = ConversionManager.subNumbersByInter(input1, input2, Convert.ToInt32(outputBaseBox.Text));
                outputTextBox.Text = output.numar;
            }
            catch (Exception ex)
            {
                errorLabel.Text = "Una din bazele selectate nu este valida";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                BaseNumber input1 = new BaseNumber(Convert.ToInt32(inputBaseBox.Text), inputTextBox.Text);
                BaseNumber input2 = new BaseNumber(Convert.ToInt32(inputBaseBox2.Text), inputTextBox2.Text);
                BaseNumber output = ConversionManager.mulNumbersByInter(input1, input2, Convert.ToInt32(outputBaseBox.Text));
                outputTextBox.Text = output.numar;
            }
            catch (Exception ex)
            {
                errorLabel.Text = "Una din bazele selectate nu este valida";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                BaseNumber input1 = new BaseNumber(Convert.ToInt32(inputBaseBox.Text), inputTextBox.Text);
                BaseNumber input2 = new BaseNumber(Convert.ToInt32(inputBaseBox2.Text), inputTextBox2.Text);
                BaseNumber output = ConversionManager.divNumbersByInter(input1, input2, Convert.ToInt32(outputBaseBox.Text));
                outputTextBox.Text = output.numar;
            }
            catch (Exception ex)
            {
                errorLabel.Text = "Una din bazele selectate nu este valida";
            }
        }
    }
}
