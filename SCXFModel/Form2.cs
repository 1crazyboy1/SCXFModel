using System;
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
    public partial class Form2 : Form
    {
        bool NeedStop = false;
        bool NeedStop1 = false;
        bool NeedStop2 = false;
        bool NeedStop3 = false;
        bool NeedStop4 = false;
        List<int> RandomList = new List<int>();

        

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = (button2.Text == "开始生产") ? "停止生产" : "开始生产";
            if (button1.Text=="停止生产")
            {
                Thread thread = new Thread(Thread1_Random);
                thread.Start();
                NeedStop1 = false;
            }
            else
            {
                NeedStop1 = true;
            }
                    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Text = (button2.Text == "开始生产") ? "停止生产" : "开始生产";
            if (button2.Text == "停止生产")
            {
                Thread thread1 = new Thread(Thread2_Random);
                thread1.Start();
                NeedStop2 = false;
            }
            else
            {
                NeedStop2 = true;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Text = (button3.Text == "开始生产") ? "停止生产" : "开始生产";
            if (button3.Text == "停止生产")
            {
                Thread thread3 = new Thread(Thread3_Random);
                thread3.Start();
                NeedStop3 = false;
            }
            else
            {
                NeedStop3 = true;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Text = (button4.Text == "开始生产") ? "停止生产" : "开始生产";
            if (button4.Text == "停止生产")
            {
                Thread thread4 = new Thread(Thread4_Random);
                thread4.Start();
                NeedStop4 = false;
            }
            else
            {
                NeedStop4 = true;
            }

        }



        private void Thread1_Random()
        {
            MYRandom ran = new MYRandom();
            ran.IsEven += new IsEvenEvent(SaveDate1);
            while (true)
            {
                if (NeedStop1==false)
                {
                    break;
                }
                ran.run_Random();
                Thread.Sleep(200);
            }
                
        }

        private void Thread2_Random()
        {
            MYRandom ran = new MYRandom();
            ran.IsEven += new IsEvenEvent(SaveDate1);
            while (true)
            {
                if (NeedStop2 == false)
                {
                    break;
                }
                ran.run_Random();
                Thread.Sleep(200);
            }

        }
        private void Thread3_Random()
        {
            MYRandom ran = new MYRandom();
            ran.IsEven += new IsEvenEvent(SaveDate1);
            while (true)
            {
                if (NeedStop3 == false)
                {
                    break;
                }
                ran.run_Random();
                Thread.Sleep(200);
            }

        }

        private void Thread4_Random()
        {
            MYRandom ran = new MYRandom();
            ran.IsEven += new IsEvenEvent(SaveDate1);
            while (true)
            {
                if (NeedStop4 == false)
                {
                    break;
                }
                ran.run_Random();
                Thread.Sleep(200);
            }

        }


        private void SaveDate1(object sender,IsEvenEventArgs e)
        {
            lock (this)
            {
                RandomList.Add(e.Random);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.Text = (button5.Text=="开始消费") ? "停止消费" : "开始消费";
            if (button5.Text=="开始消费")
            {
                Thread MYTHREAD1 = new Thread(Customer1);

                MYTHREAD1.Start();
                Thread MYTHREAD2 = new Thread(Customer2);
                MYTHREAD2.Start();
                NeedStop = false;

            }
            else
            {
                NeedStop = true;
            }
        }


        private void Customer1()
        {
            while (true)
            {
                if (NeedStop == true) break;
                Thread.Sleep(100);
                lock (this)
                {
                    if (RandomList.Count == 0) continue;
                    if (RandomList.ElementAt(0) % 2 == 0)
                    {
                        textBox1.Text += RandomList.ElementAt(0).ToString() + "\r\n";
                        RandomList.RemoveAt(0);
                        textBox1.Focus();//获取焦点
                        textBox1.Select(this.textBox1.TextLength, 0);//光标定位到文本最后
                        textBox1.ScrollToCaret();//滚动到光标处

                    }

                }
            }

          
        }


        private void Customer2()
        {

        }
    }
}
