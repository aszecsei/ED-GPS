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

        private BindingList<Location> locations;

        private string currentSystem = "";
        private string currentLocation = "";

        private List<EDDBSystem> systems;
        private List<EDDBStation> stations;
        private List<EDDBCommodity> commodities;

        private bool runningRoute;

        public Form1()
        {
            InitializeComponent();

            locations = new BindingList<Location>();
            locationsListBox.DataSource = locations;
            locationsListBox.DisplayMember = "Display";

            systems = new List<EDDBSystem>();
            systemBox.DataSource = systems;
            systemBox.DisplayMember = "name";

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

                        currentSystem = args.System;
                        currentLocation = args.Target;

                        CalculateNextJump();
                    }
                }
            }
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
            locations.Add(new Location());
            locationsListBox.SelectedIndex = locations.Count - 1;
            UpdateLocationData();
        }

        private void deleteLocationButton_Click(object sender, EventArgs e)
        {
            locations.RemoveAt(locationsListBox.SelectedIndex);
        }

        private void moveUpButton_Click(object sender, EventArgs e)
        {
            if(locationsListBox.SelectedIndex > 0)
            {
                Location temp = locations[locationsListBox.SelectedIndex - 1];
                locations[locationsListBox.SelectedIndex - 1] = locations[locationsListBox.SelectedIndex];
                locations[locationsListBox.SelectedIndex] = temp;
                locationsListBox.SelectedIndex--;
                locationsListBox.Update();
            }
        }

        private void moveDownButton_Click(object sender, EventArgs e)
        {
            if (locationsListBox.SelectedIndex < locations.Count - 1)
            {
                Location temp = locations[locationsListBox.SelectedIndex + 1];
                locations[locationsListBox.SelectedIndex + 1] = locations[locationsListBox.SelectedIndex];
                locations[locationsListBox.SelectedIndex] = temp;
                locationsListBox.SelectedIndex++;
                locationsListBox.Update();
            }
        }

        private void systemBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (systemBox.SelectedItem != null && stations != null)
            {
                Console.WriteLine("Bloop!");
                List<EDDBStation> stationsInSystem = stations.Where(station => (station.system_id == ((EDDBSystem)systemBox.SelectedItem).id)).ToList();
                if(stationsInSystem != null)
                {
                    stationsInSystem.Insert(0, new EDDBStation());
                    stationBox.DataSource = new BindingList<EDDBStation>(stationsInSystem);
                    stationBox.DisplayMember = "name";
                    stationBox.Update();
                    if (stationsInSystem.Count > 1)
                        stationBox.Enabled = true;
                    else
                        stationBox.Enabled = false;
                }
                else
                {
                    stationBox.DataSource = null;
                    stationBox.Update();
                    stationBox.Enabled = false;
                }

                ((Location)locationsListBox.SelectedItem).System = ((EDDBSystem)systemBox.SelectedItem).name;
            }
            else
            {
                stationBox.DataSource = null;
                stationBox.Update();
            }

            locationsListBox.Update();
        }

        private void stationBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(stationBox.SelectedItem != null && ((EDDBStation)stationBox.SelectedItem).name != null)
            {
                ((Location)locationsListBox.SelectedItem).Station = ((EDDBStation)stationBox.SelectedItem).name;
                
                // Enable trading!
                purchaseBox.Enabled = true;
                sellBox.Enabled = true;

                purchaseCommodityBox.DataSource = new BindingList<EDDBCommodity>(commodities);
                purchaseCommodityBox.DisplayMember = "name";
                purchaseCommodityBox.Text = "";

                sellCommodityBox.DataSource = new BindingList<EDDBCommodity>(commodities);
                sellCommodityBox.DisplayMember = "name";
                sellCommodityBox.Text = "";
            }

            locationsListBox.Update();
        }

        private void purchaseBox_CheckedChanged(object sender, EventArgs e)
        {
            ((Location)locationsListBox.SelectedItem).Buy = purchaseBox.Checked;
            if(purchaseBox.Checked)
            {
                purchaseCommodityAmountBox.Enabled = true;
                purchaseCommodityBox.Enabled = true;
                purchaseCommodityBox.Text = commodities[0].name;
            }
            else
            {
                purchaseCommodityAmountBox.Enabled = false;
                purchaseCommodityAmountBox.Value = 0;
                purchaseCommodityBox.Enabled = false;
                purchaseCommodityBox.Text = "";
            }
        }

        private void purchaseCommodityBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((Location)locationsListBox.SelectedItem).BuyCommodityName = purchaseCommodityBox.SelectedText;
        }

        private void purchaseCommodityAmountBox_ValueChanged(object sender, EventArgs e)
        {
            ((Location)locationsListBox.SelectedItem).BuyCommodityAmount = (int)purchaseCommodityAmountBox.Value;
        }

        private void sellBox_CheckedChanged(object sender, EventArgs e)
        {
            ((Location)locationsListBox.SelectedItem).Sell = sellBox.Checked;
            if (sellBox.Checked)
            {
                sellCommodityAmountBox.Enabled = true;
                sellCommodityBox.Enabled = true;
                sellCommodityBox.Text = commodities[0].name;
            }
            else
            {
                sellCommodityAmountBox.Enabled = false;
                sellCommodityAmountBox.Value = 0;
                sellCommodityBox.Enabled = false;
                sellCommodityBox.Text = "";
            }
        }

        private void sellCommodityBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((Location)locationsListBox.SelectedItem).SellCommodityName = sellCommodityBox.SelectedText;
        }

        private void sellCommodityAmountBox_ValueChanged(object sender, EventArgs e)
        {
            ((Location)locationsListBox.SelectedItem).SellCommodityAmount = (int)sellCommodityAmountBox.Value;
        }

        private void locationsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateLocationData();
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
                addLocationButton.Enabled = true;
                Cursor.Current = Cursors.Default;
            });
        }

        private void UpdateLocationData()
        {
            Location selectedLocation = (Location)locationsListBox.SelectedItem;
            systemBox.Enabled = true;
            systemBox.Text = selectedLocation.System;
            if (selectedLocation.System != "")
            {
                stationBox.Enabled = true;
                stationBox.Text = selectedLocation.Station;

                purchaseBox.Enabled = true;
                sellBox.Enabled = true;

                if(selectedLocation.Buy)
                {
                    purchaseBox.Checked = true;
                    purchaseCommodityAmountBox.Value = selectedLocation.BuyCommodityAmount;
                    purchaseCommodityBox.Text = selectedLocation.BuyCommodityName;
                }

                if(selectedLocation.Sell)
                {
                    sellBox.Checked = true;
                    sellCommodityAmountBox.Value = selectedLocation.SellCommodityAmount;
                    sellCommodityBox.Text = selectedLocation.SellCommodityName;
                }
            }
            else
            {
                stationBox.Text = "";
            }
        }
    }
}