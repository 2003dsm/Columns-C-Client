using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;


namespace Cliente
{
    public partial class Form2 : Form
    {
        int salas = 0;
        public Form2()
        {
            Button button = new Button();

            button.Text = "Return";





            button.Location = new Point(0, 0);
            button.Size = new Size(50, 30);

            button.Show();

            button.Click += (sender, EventArgs) => {

                Form4 newForm = new Form4();

                newForm.Show();

                this.SetVisibleCore(false);
            };
            this.Controls.Add(button);

            this.AutoScroll = true;

            InitializeComponent();

            this.Size = new Size(1000, 500);

            SocketServer.Instance.GetSocket().EmitAsync("getRooms");


            SocketServer.Instance.GetSocket().On("rooms", response =>
            {
            dynamic json2 = JsonConvert.DeserializeObject(response.ToString());

                for (int i = 0; i < json2[0].Count;i++)
                {
                    int sala = json2[0][i];
                    AñadirSala(sala);
                }
            });

            SocketServer.Instance.GetSocket().On("clientRoomCreated", response =>
            {
                AñadirSala(response.GetValue<int>());
            });
        }


        private void AñadirSala(int id)
        {

            Button button = new Button();
            button.Text = "Sala" + (id);
            button.Location = new Point((50 + ((salas * 150)) % 900), 25 + (75 * ((int)salas / 6)));
            button.Size = new Size(100, 50);

            button.Show();

            button.Click += (sender, EventArgs) => {
                OnCreateRoom(sender, EventArgs, id); 
            };


            this.BeginInvoke((MethodInvoker)delegate {
                this.Controls.Add(button);

            });

            salas++;
        }

        private void OnCreateRoom(object sender, EventArgs e, int id)
        {
            Form3 newForm = new Form3(id);

            newForm.Size = new Size(800, 600);

            newForm.Show();

            this.SetVisibleCore(false);
        }





        private void Form2_Load(object sender, EventArgs e)
        {



        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
