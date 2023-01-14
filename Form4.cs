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

    public partial class Form4 : Form
    {

        public Form4()
        {
            InitializeComponent();

           
        }








        private void Form4_Load(object sender, EventArgs e)
        {


        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void rep(object sender, EventArgs e)
        {
            Form5 newForm = new Form5();

            newForm.Show();

            this.SetVisibleCore(false);
        }

        private void salas(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();

            newForm.Show();

            this.SetVisibleCore(false);
        }
    }
}
