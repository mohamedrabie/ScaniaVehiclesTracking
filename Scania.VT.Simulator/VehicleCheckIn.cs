using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scania.VT.Simulator
{
    public partial class VehicleCheckIn : Form
    {
        HubConnection connection;
        IHubProxy vehiclesHub;

        public VehicleCheckIn()
        {
            InitializeComponent();

             connection = new HubConnection("http://localhost:8415/signalr");
            //Make proxy to hub based on hub name on server
            vehiclesHub = connection.CreateHubProxy("VehiclesHub");
            //Start connection

            connection.Start().ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    Console.WriteLine("There was an error opening the connection:{0}",
                                      task.Exception.GetBaseException());
                }
                else
                {
                    Console.WriteLine("Connected");
                }

            }).Wait();

            //connection.Stop();
        }
        private void btnOnline_Click(object sender, EventArgs e)
        {
            vehiclesHub.Invoke<string>("UpdateMyStatus", txtVehicleNo.Text).ContinueWith(task => {
                if (task.IsFaulted)
                {
                    Console.WriteLine("There was an error calling send: {0}",
                                      task.Exception.GetBaseException());
                }
                else
                {
                    Console.WriteLine(task.Result);
                }
            }).Wait();
        }
        private void btnOffline_Click(object sender, EventArgs e)
        {

        }



    }
}
