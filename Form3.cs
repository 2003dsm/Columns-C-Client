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


namespace Cliente
{

    public partial class Form3 : Form
    {
        Sala sala = new Sala();

        public Form3(int id)
        {

            InitializeComponent();

            sala.ID = id;

            SocketServer.Instance.GetSocket().On("isClientConnected", response =>
            {

                    SocketServer.Instance.GetSocket().EmitAsync("clientConnected", id);

            });

            SocketServer.Instance.GetSocket().EmitAsync("clientConnected", id);



            SocketServer.Instance.GetSocket().EmitAsync("getPlayers", id);

            SocketServer.Instance.GetSocket().On("newPlayer", response =>
            {
                dynamic json2 = JsonConvert.DeserializeObject(response.ToString());
                if (json2[0].idRoom == sala.ID)
                {
      this.BeginInvoke((MethodInvoker)delegate {

          int a = json2[0].user;
                    sala.AddNewPlayer(a, this);
                });
                }
          
            });


                SocketServer.Instance.GetSocket().On("playersInRoom", response=>
            {
            dynamic json2 = JsonConvert.DeserializeObject(response.ToString());

                for (int i = 0; i < json2[0].Count; i++)
                {
                    int player = json2[0][i].idUser;

                    this.BeginInvoke((MethodInvoker)delegate {
                        sala.AddNewPlayer(player, this);

                    });

                }

            });
            SocketServer.Instance.GetSocket().On("newGrid", response2 =>
            {

                dynamic json3 = JsonConvert.DeserializeObject(response2.ToString());
                for (int i = 0; i < json3.Count; i++)
                {
                    int idRoom = json3[0].idRoom;
                    int player = json3[0].player;

                    if (idRoom == sala.ID)
                    {

                        for(int e = 0; e < sala.players.Length; e++)
                        {
                            if (sala.players[e].ID == player)
                            {
                                int x = json3[0].x;
                                int y = json3[0].y;
                                int color = json3[0].color;
                                sala.players[e].grid.UpdateGrid(x, y, color);
                            }
                        }
                        
                    }
                }
            });


           
        }





        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            SocketServer.Instance.GetSocket().EmitAsync("clientDisconnected", sala.ID);

        }


        private void Form3_Load(object sender, EventArgs e)
        {


        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
