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


namespace Cliente
{

    public partial class Form6 : Form
    {
        Sala sala = new Sala();
        public Form6(int idRep, int idPlayer, int idRoom)
        {
            Button button = new Button();

            button.Text = "Return";





            button.Location = new Point(0, 0);
            button.Size = new Size(50, 30);

            button.Show();

            button.Click += (sender, EventArgs) => {

                Form5 newForm = new Form5();

                newForm.Show();
                SocketServer.Instance.GetSocket().EmitAsync("endReplay");

                this.SetVisibleCore(false);
            };
            this.Controls.Add(button);

            InitializeComponent();

            sala.ID = idRoom;

            sala.AddNewPlayer(idPlayer, this);

            SocketServer.Instance.GetSocket().EmitAsync("emitReplay", idRep, 1, sala.players[0].ID, sala.ID);

            SocketServer.Instance.GetSocket().On("replay", response =>
            {

                dynamic json = JsonConvert.DeserializeObject(response.ToString());

                foreach (var message in json)
                {

                    for (int i = 0; i < message.Count; i++)
                    {
                        int x = message[i].x;
                        int y = message[i].y;
                        int color = message[i].color;


                        sala.players[0].grid.UpdateGrid(x, y, color);

                    }


                }
            });
        }








        private void Form6_Load(object sender, EventArgs e)
        {


        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
