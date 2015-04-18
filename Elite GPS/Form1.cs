using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// using System.Text.RegularExpressions;

using System.Speech.Synthesis;
using System.Threading;
using System.Net;

namespace Elite_GPS
{
    public partial class Form1 : Form
    {
        private X52 x52;
        private SpeechSynthesizer _speechSynthesizer;
        private LogMonitor monitor;

        private BindingList<Location> route;

        private string currentSystem = "";
        private string currentLocation = "";

        private List<EDDBSystem> systems;
        private List<EDDBStation> stations;
        private List<EDDBCommodity> commodities;

        private bool runningRoute;

        public Form1()
        {
            InitializeComponent();

            route = new BindingList<Location>();
            locationsListBox.DataSource = route;
            locationsListBox.DisplayMember = "Display";

            runningRoute = false;

            _speechSynthesizer = new SpeechSynthesizer();

            x52 = new X52();
            monitor = new LogMonitor();
            monitor.DataUpdated += OnNewLogData;
            monitor.Start();

            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(OnFormClose);
        }

        void OnNewLogData(object source, LogMonitorEventArgs args)
        {
            if(runningRoute)
            {
                if (args.Commander != null)
                {
                    if (x52.SetText(1, "CMDR " + args.Commander))
                    {
                        _speechSynthesizer.Speak("Welcome Commander " + args.Commander + ".");
                    }
                }

                if (args.System != null)
                {
                    if (x52.SetText(2, args.System + " (" + args.Target + ")"))
                    {
                        // Our location has changed
                        if (args.System != currentSystem)
                            _speechSynthesizer.Speak("Your new system is " + args.System + ".");
                        if (args.Target != currentLocation)
                            _speechSynthesizer.Speak("Your new location is " + args.Target + ".");

                        CalculateNextJump();
                    }
                }
            }

            x52.SetText(1, "CMDR " + args.Commander);
            x52.SetText(2, args.System + " (" + args.Target + ")");

            currentSystem = args.System;
            currentLocation = args.Target;
        }

        private void CalculateNextJump()
        {

        }

        private void OnFormClose(object sender, EventArgs e)
        {
            x52.Dispose();
            _speechSynthesizer.Dispose();
            monitor.Dispose();
        }

        private void newRouteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm af = new AboutForm();
            af.ShowDialog();
        }

        private void addLocationButton_Click(object sender, EventArgs e)
        {
            route.Add(new Location());
            locationsListBox.SelectedIndex = route.Count - 1;
        }

        private void deleteLocationButton_Click(object sender, EventArgs e)
        {
            route.RemoveAt(locationsListBox.SelectedIndex);
        }

        private void moveUpButton_Click(object sender, EventArgs e)
        {
            if(locationsListBox.SelectedIndex > 0)
            {
                Location temp = route[locationsListBox.SelectedIndex - 1];
                route[locationsListBox.SelectedIndex - 1] = route[locationsListBox.SelectedIndex];
                route[locationsListBox.SelectedIndex] = temp;
                locationsListBox.SelectedIndex--;
                locationsListBox.Update();
            }
        }

        private void moveDownButton_Click(object sender, EventArgs e)
        {
            if (locationsListBox.SelectedIndex < route.Count - 1)
            {
                Location temp = route[locationsListBox.SelectedIndex + 1];
                route[locationsListBox.SelectedIndex + 1] = route[locationsListBox.SelectedIndex];
                route[locationsListBox.SelectedIndex] = temp;
                locationsListBox.SelectedIndex++;
                locationsListBox.Update();
                locationsListBox.Refresh();
            }
        }

        private void startRouteButton_Click(object sender, EventArgs e)
        {
            runningRoute = true;
            stopRouteButton.Enabled = true;
            startRouteButton.Enabled = false;
        }

        private void stopRouteButton_Click(object sender, EventArgs e)
        {
            runningRoute = false;
            stopRouteButton.Enabled = false;
            startRouteButton.Enabled = true;
        }

        private void loadDataButton_Click(object sender, EventArgs e)
        {
            loadDataButton.Enabled = false;
            loadDataButton.Text = "Loading Data...";
            Cursor.Current = Cursors.WaitCursor;
            Thread t = new Thread(LoadData);
            t.Start();
        }

        private void LoadData()
        {
            using (var webClient = new System.Net.WebClient())
            {
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(downloadProgressChanged);
                webClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(system_DownloadStringCompleted);

                webClient.DownloadStringAsync(new Uri("http://eddb.io/archive/v3/systems.json"), "systems");
            }
        }

        void downloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                loadingDataProgressBar.Maximum = (int)e.TotalBytesToReceive / 100;
                loadingDataProgressBar.Value = (int)e.BytesReceived / 100;
            });
            
        }

        void system_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {            
            this.Invoke((MethodInvoker)delegate
            {
                systems = Newtonsoft.Json.JsonConvert.DeserializeObject<List<EDDBSystem>>(e.Result);
                systemBox.DataSource = new BindingList<EDDBSystem>(systems);
                systemBox.DisplayMember = "name";
                systemBox.SelectedItem = null;
            });

            using (var webClient = new System.Net.WebClient())
            {
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(downloadProgressChanged);
                webClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(station_DownloadStringCompleted);

                webClient.DownloadStringAsync(new Uri("http://eddb.io/archive/v3/stations_lite.json"), "stations");
            } 
        }

        void station_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            stations = Newtonsoft.Json.JsonConvert.DeserializeObject<List<EDDBStation>>(e.Result);

            using (var webClient = new System.Net.WebClient())
            {
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(downloadProgressChanged);
                webClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(commodity_DownloadStringCompleted);

                webClient.DownloadStringAsync(new Uri("http://eddb.io/archive/v3/commodities.json"), "commodities");
            } 
        }

        void commodity_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            commodities = Newtonsoft.Json.JsonConvert.DeserializeObject<List<EDDBCommodity>>(e.Result);

            this.Invoke((MethodInvoker)delegate
            {
                systemBox.Update();
                loadDataButton.Text = "Data Loaded";
                Cursor.Current = Cursors.Default;
            });
        }

        private void Update()
        {
            if(locationsListBox.SelectedIndex > -1)
            {
                if(systemBox.Text != "")
                {

                }
                else
                {
                    stationBox.Enabled = false;
                    stationBox.Text = "";

                    purchaseBox.Enabled = false;
                    purchaseBox.Checked = false;

                    sellBox.Enabled = false;
                    sellBox.Checked = false;

                    purchaseCommodityBox.Enabled = false;
                    purchaseCommodityBox.Text = "";

                    purchaseCommodityAmountBox.Enabled = false;
                    purchaseCommodityAmountBox.Value = 0;

                    sellCommodityBox.Enabled = false;
                    sellCommodityBox.Text = "";

                    sellCommodityAmountBox.Enabled = false;
                    sellCommodityAmountBox.Value = 0;
                }
            }
            else
            {
                // Disable everything
                systemBox.Enabled = false;
                systemBox.Text = "";

                stationBox.Enabled = false;
                stationBox.Text = "";

                purchaseBox.Enabled = false;
                purchaseBox.Checked = false;

                sellBox.Enabled = false;
                sellBox.Checked = false;

                purchaseCommodityBox.Enabled = false;
                purchaseCommodityBox.Text = "";

                purchaseCommodityAmountBox.Enabled = false;
                purchaseCommodityAmountBox.Value = 0;

                sellCommodityBox.Enabled = false;
                sellCommodityBox.Text = "";

                sellCommodityAmountBox.Enabled = false;
                sellCommodityAmountBox.Value = 0;
            }
        }
    }
}