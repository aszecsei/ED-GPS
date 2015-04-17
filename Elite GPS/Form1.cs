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

namespace Elite_GPS
{
    public partial class Form1 : Form
    {
        private X52 x52;
        private SpeechSynthesizer _speechSynthesizer;
        private LogMonitor monitor;

        private BindingList<Location> locations;

        private Location selectedLocation = null;

        private string currentSystem = "";
        private string currentLocation = "";

        public Form1()
        {
            InitializeComponent();

            locations = new BindingList<Location>();
            locationsListBox.DataSource = locations;
            locationsListBox.DisplayMember = "Display";

            _speechSynthesizer = new SpeechSynthesizer();

            x52 = new X52();
            monitor = new LogMonitor();
            monitor.DataUpdated += OnNewLogData;
            monitor.Start();

            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(OnFormClose);
        }

        void OnNewLogData(object source, LogMonitorEventArgs args)
        {
            if (args.Commander != null)
            {
                if(x52.SetText(1, "CMDR " + args.Commander))
                {
                    _speechSynthesizer.Speak("Welcome Commander " + args.Commander + ".");
                }
            }

            if (args.System != null)
            {
                if (x52.SetText(2, args.System + " (" + args.Target + ")"))
                {
                    // Our location has changed
                    if(args.System != currentSystem)
                        _speechSynthesizer.Speak("Your new system is " + args.System + ".");
                    if(args.Target != currentLocation)
                        _speechSynthesizer.Speak("Your new location is " + args.Target + ".");
                }
            }

            /*
            if (args.PlayMode != null)
            {
                x52.SetText(3, Regex.Replace(args.PlayMode, @"\b(\w)", m => m.Value.ToUpper()));
            }
            */
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
            selectedLocation = locations[locations.Count - 1];
            UpdateLocationData();
        }

        private void deleteLocationButton_Click(object sender, EventArgs e)
        {

        }

        private void moveUpButton_Click(object sender, EventArgs e)
        {

        }

        private void moveDownButton_Click(object sender, EventArgs e)
        {

        }

        private void systemBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void stationBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void purchaseBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void purchaseCommodityBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void purchaseCommodityAmountBox_ValueChanged(object sender, EventArgs e)
        {

        }

        private void sellBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void sellCommodityBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void sellCommodityAmountBox_ValueChanged(object sender, EventArgs e)
        {

        }

        private void locationsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedLocation = locations[locationsListBox.SelectedIndex];
            UpdateLocationData();
        }

        private void UpdateLocationData()
        {
            systemBox.Enabled = true;
            systemBox.Text = selectedLocation.System;
            if(selectedLocation.System != "")
            {
                stationBox.Enabled = true;
                stationBox.Text = selectedLocation.Station;
            }
            else
            {
                stationBox.Enabled = false;
                stationBox.Text = "";
            }
        }

        private void startRouteButton_Click(object sender, EventArgs e)
        {

        }

        private void stopRouteButton_Click(object sender, EventArgs e)
        {

        }
    }
}