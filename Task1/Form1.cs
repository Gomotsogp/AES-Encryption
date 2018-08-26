using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1
{
    public partial class Form1 : Form
    {
        private readonly Encryption _encryption;
        public Form1()
        {
            InitializeComponent();
            _encryption = new Encryption();// initialize global variable 
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Clear();// clear the textbox before text is placed (assigned) into it
            textBox2.Text = _encryption.Encrypt(textBox1.Text);// assign encrypted text to the textbox
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();// clear the textbox before text is placed (assigned) into it
            textBox1.Text = _encryption.Decrypt(textBox2.Text);// assign encrypted text to the textbox
        }
    }
}
