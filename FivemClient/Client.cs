using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Dynamic;
using System.Threading.Tasks;
using System.Windows.Forms;
using EpEren.Fivem.ServerStatus;
namespace FivemClient
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }
        public static dynamic ayarlar = new { IP = "<YOUR SERVER IP>", Isım = "<YOUR SERVER NAME>" };

        Fivem fm = new Fivem(ayarlar.IP);

        dynamic bilgiler;


        private void Client_Load(object sender, EventArgs e)
        {
            bilgiler = fm.Getİnfo();

            var Players = bilgiler.Players;
            var Server = bilgiler.Server;
            var Client = bilgiler.Clients;
            var Vars = bilgiler.Vars;
            var Resources = bilgiler.Resources;

            label1.Text = ayarlar.Isım;
            label2.Text = ayarlar.Isım;
            label3.Text = Convert.ToString(Client.OnlineClients+ " / "+Client.MaxClients);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Process.Start("fivem://connect/"+ ayarlar.IP);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var isimler = "";
            for (int i = 0; i < Convert.ToInt32(bilgiler.Clients.OnlineClients); i++)
            {
                if (bilgiler.Players[i].Name != "")
                {
                    isimler += bilgiler.Players[i].Name + " - "+ bilgiler.Players[i].Ping + " MS"+"\n";
                }
            }
            MessageBox.Show(isimler);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            var eklentiler = "";
            for (int i = 0; i < Convert.ToInt32(bilgiler.Resources.Length); i++)
            {
                if (bilgiler.Resources[i] != "")
                {
                    eklentiler += bilgiler.Resources[i] + "\n";
                }
            }
            MessageBox.Show(eklentiler);
        }
    }
}
