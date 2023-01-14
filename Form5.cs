using SocketIOClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Numerics;
using System.Xml.Linq;


namespace Cliente
{

    public partial class Form5 : Form
    {
        int salas = 0;
        Button[] buttons = new Button[0];

        public Form5()
        {

            Button button = new Button();

            button.Text = "Return";





            button.Location = new Point(0,0);
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
            this.Size = new Size(950, 500);

            SocketServer.Instance.GetSocket().EmitAsync("rep");

            SocketServer.Instance.GetSocket().On("getRep", response =>
            {
                dynamic json = JsonConvert.DeserializeObject(response.ToString());

               

                    foreach (var message in json)
                {


                    for (int i = 0; i < message.Count; i++)
                    {
                        int partida = message[i].idPartida;
                        int player = message[i].User_idUser;
                        int room = message[i].User_Room_idRoom;
                        string name = message[i].name;
                       

                        AñadirSala(partida, player, room,name);


                    }


                }
            });
        }


        private void AñadirSala(int idRep, int idPlayer, int idRoom, string name)
        {




            Button button = new Button();

            button.Text = "Rep: " + (idRep) + " Player: " + name;
            button.Name = "sala" + salas;


     


            button.Location = new Point((50 + ((salas * 150)) % 900), 25 + (75 * ((int)salas / 6)));
            button.Size = new Size(100, 50);

            button.Show();

            button.Click += (sender, EventArgs) => {
                OnCreateRoom(sender, EventArgs, idRep, idPlayer, idRoom);
            };

            Button[] newList = new Button[buttons.Length + 1];

            // Copy the elements from the original array to the new array
            Array.Copy(buttons, newList, buttons.Length);

            // Add the new element to the new array
            newList[newList.Length - 1] = button;

            buttons = newList;

            this.BeginInvoke((MethodInvoker)delegate {
                this.Controls.Add(button);

            });

            salas++;
        }

        private void OnCreateRoom(object sender, EventArgs e, int idRep, int idPlayer, int idRoom)
        {
            Form6 newForm = new Form6(idRep, idPlayer, idRoom);

            newForm.Size = new Size(800, 600);

            newForm.Show();

            this.SetVisibleCore(false);
        }




        private void Form5_Load(object sender, EventArgs e)
        {


        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
