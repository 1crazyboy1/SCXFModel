﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCXFModel
{
    public partial class Form1 : Form
    {
        bool NeedsStop = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread thread = new Thread(Thread_Random);
            thread.Start();
            bool NeedsStop = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            NeedsStop = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NeedsStop = false;
        }

        private void Thread_Random()
        {
            MYRandom ran = new MYRandom();
            ran.IsEven  += new IsEvenEvent(updateTextBox);

            while (true)
            {
                ran.run_Random();
                if (NeedsStop==false)
                
                    break;
                
                Thread.Sleep(200);
            }
        }

        private void updateTextBox(object sender, IsEvenEventArgs e)
        {
            textBox1.Invoke(new Action(()=>
            {
            
                string ShowText = "产生了一个随机偶数：" + e.Random.ToString() + "\r\n";
                textBox1.Text += ShowText;
                textBox1.Focus();
                textBox1.Select(this.textBox1.TextLength, 0);
                textBox1.ScrollToCaret();
            
             
            }));
            
        }
    }
}
