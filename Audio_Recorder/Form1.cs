using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Runtime.InteropServices;
using System.IO;
using System.Text;
using System.Timers;

namespace Audio_Recorder
{
    
    public partial class Form1 : Form
    {
        string folder = " C:\\Users\\PC\\Desktop\\VOICE-RECORDS\\";
        public void D()
        {
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
        }
        
        int sec = 0;
        int min = 0;
        int hour = 0;
       
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
       

        [DllImport("winmm.dll", EntryPoint = "mciSendStringA", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern int myfunc(string a, string b, int c, int d);
        public Form1()
        {
            InitializeComponent();
            label1.Text = $"0{hour}:0{min}:0{sec}";
            label2.Hide();
            button4.Hide();
            textBox1.Hide();
            button3.Hide();
            button2.Hide();
            label1.Hide();
            button5.Hide();
            button6.Hide();
            
        }
       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button2.Show();
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            myfunc("open new Type waveaudio Alias recsound", "",0,0);
            myfunc("record recsound","",0,0);
            button1.Hide();
            button4.Show();
            button5.Hide();
            label1.Show();
            label2.Show();
            sec = 0;
            min = 0;
            hour = 0;
            timer1.Start();
        }
       


        private void button2_Click(object sender, EventArgs e)
        {

            string name = textBox1.Text;
            D();

            myfunc($"save recsound C:\\Users\\PC\\Desktop\\VOICE-RECORDS\\{name}.wav", "", 0, 0);
            myfunc("close recsound", "", 0, 0);
            button2.Hide();
            button3.Hide();
            textBox1.Hide();
            button1.Show();
            button5.Hide();
            button6.Hide();






        }

        private void button4_Click(object sender, EventArgs e)
        {

            myfunc("pause recsound", "", 0, 0);
            button5.Show();
          
            button4.Hide();
            button1.Show();
            timer1.Stop();
           
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            textBox1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button4.Hide();
            button1.Hide();
            button3.Show();
            button6.Show();
            

        }

        private void AudioRecorder_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            myfunc("open new Type waveaudio Alias recsound", "", 0, 0);
            myfunc("record recsound", "", 0, 0);
            button1.Hide();
            button4.Show();
            button5.Hide();
            button6.Hide();
            button3.Hide();
            textBox1.Hide();
            button2.Hide();
            timer1.Start();

        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = $"0{hour}:0{min}:0{sec}";
            sec++;
            
            if (sec > 9)
            {
                label1.Text = $"0{hour}:0{min}:{sec}";
            }
           if (sec == 59)
            {
                sec = 0;
                min++;
            }
            if (min > 9)
            {
               
                label1.Text = $"0{hour}:{min}:{sec}";
            }
            else if (min > 59)
            {
                min = 0;
                hour++;
            }
            if (hour > 9)
            {
                label1.Text = $"{hour}:{min}:{sec}";
            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }

        
    }

