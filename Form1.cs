using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SocketIOClient;

namespace Cliente
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void bb(object sender, EventArgs e)
        {

            if (!IPAddress.TryParse(IP.Text, out IPAddress serverIP))
            {
                MessageBox.Show("Invalid IP address");
                return;
            }

            SocketServer.Instance.ConnectToServer(IP.Text, 3000);


            Form4 newForm = new Form4();

            newForm.Show();

            PlaySimpleSound();
            this.SetVisibleCore(false);

        }



       private void PlaySimpleSound()
        {
            SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");
            simpleSound.Play();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }


}
 