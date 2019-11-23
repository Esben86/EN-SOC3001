using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace AlarmUI
{
    public partial class Form1 : Form
    {

        private Thread workerThread;
        public string strReceivedUDPMessage;
        public bool remoteControllActivated;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            workerThread = new Thread(this.DoReceiveUDP);
            workerThread.IsBackground = true;
            workerThread.Start();
            triggeredAlarmImage.Visible = false;
        }

        public void DoReceiveUDP()
        {
            UdpClient sock = new UdpClient(9050);
            IPEndPoint iep = new IPEndPoint(IPAddress.Any, 0);

            while (true)
            {
                try
                {
                    // Receive message as UDP
                    byte[] data = sock.Receive(ref iep);
                    // Convert bytes to ASCII String
                    strReceivedUDPMessage = Encoding.ASCII.GetString(data, 0, data.Length);
                    // Call the function UdpDataReceived
                    this.Invoke(new EventHandler(this.UdpDataReceived));
                }
                catch (Exception e) { }
            }
            sock.Close();
        }

        public void UdpDataReceived(object Sender, EventArgs e)
        {
            receivedMessageTextBox.Text = strReceivedUDPMessage;
            string[] commandArguments = strReceivedUDPMessage.Split(',');

            if (commandArguments[0] == "$CTRL_MODE")
            {
                controllModeTextBox.Text = commandArguments[1];
                if (commandArguments[1] == "UI")
                {
                    // remoteControllActivated = true;
                    rotateCWButton.Enabled = true;
                    rotateCCWButton.Enabled = true;
                    captureImageButton.Enabled = true;
                    motionDetectionCheckBox.Enabled = true;
                    setSensButton.Enabled = true;
                }
                else
                {
                    // remoteControllActivated = false;
                    rotateCWButton.Enabled = false;
                    rotateCCWButton.Enabled = false;
                    captureImageButton.Enabled = false;
                    motionDetectionCheckBox.Enabled = false;
                    setSensButton.Enabled = false;
                }
            }
            else if (commandArguments[0] == "$MOTION_DETECT")
            {
                if (commandArguments[1] == "ON")
                {
                    turnedOnByTextBox.Text = commandArguments[2];
                    turnedOffByTextBox.Text = "";
                    motionDetectOffImage.Visible = false;
                    motionDetectionCheckBox.Checked = true;
                    
                }
                else if (commandArguments[1] == "OFF")
                {
                    turnedOffByTextBox.Text = commandArguments[2];
                    turnedOnByTextBox.Text = "";
                    motionDetectOffImage.Visible = true;
                    motionDetectionCheckBox.Checked = false;
                }
            }
            else if (commandArguments[0] == "$ALARM")
            {
                if (commandArguments[1] == "TRIGGERED")
                {
                    triggeredAlarmImage.Visible = true;

                }
                else if (commandArguments[1] == "RESET")
                {
                    triggeredAlarmImage.Visible = false;
                }
            }
            else if (commandArguments[0] == "$CAM_SENS")
            {
                sensTextBox.Text = commandArguments[1];
            }
            else if (commandArguments[0] == "$CAM_POS")
            {
                camPosTextBox.Text = commandArguments[1];
            }
        }

        private void rotateCWButton_Click(object sender, EventArgs e)
        {
            byte[] data = new byte[1024];

            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("128.39.112.22"), 9050);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            string stringToSend = "$ROTATE, CW";

            data = Encoding.ASCII.GetBytes(stringToSend);
            server.SendTo(data, data.Length, SocketFlags.None, ipep);
        }

        private void rotateCCWButton_Click(object sender, EventArgs e)
        {
            byte[] data = new byte[1024];

            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("128.39.112.22"), 9050);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            string stringToSend = "$ROTATE, CCW";

            data = Encoding.ASCII.GetBytes(stringToSend);
            server.SendTo(data, data.Length, SocketFlags.None, ipep);
        }

        private void captureImageButton_Click(object sender, EventArgs e)
        {
            byte[] data = new byte[1024];

            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("128.39.112.22"), 9050);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            string stringToSend = "$IMAGE_CAPTURE";

            data = Encoding.ASCII.GetBytes(stringToSend);
            server.SendTo(data, data.Length, SocketFlags.None, ipep);
        }

        private void motionDetectionCheckBox_Click(object sender, EventArgs e)
        {
            byte[] data = new byte[1024];

            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("128.39.112.22"), 9050);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            string stringToSend = "";


            if (motionDetectionCheckBox.Checked)
            {
                stringToSend = "$MOTION_DETECT, ON";
                motionDetectOffImage.Visible = false;
                turnedOnByTextBox.Text = "UI";
                turnedOffByTextBox.Text = "";
            }
            else
            {
                stringToSend = "$MOTION_DETECT, OFF";
                motionDetectOffImage.Visible = true;
                turnedOnByTextBox.Text = "";
                turnedOffByTextBox.Text = "UI";
            }

            data = Encoding.ASCII.GetBytes(stringToSend);
            server.SendTo(data, data.Length, SocketFlags.None, ipep);
        }

        private void setSensButton_Click(object sender, EventArgs e)
        {
            byte[] data = new byte[1024];

            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("128.39.112.22"), 9050);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            string sensValue = sensTextBox.Text.ToString();
            int sensValueAsInt = Convert.ToInt32(sensValue);
           

            if (sensValueAsInt < 1000 || sensValueAsInt > 10000)
            {
                invalidSensValueLabel.Text = "Enter a valid number!";
                invalidSensValueLabel.ForeColor = Color.Red;
            }
            else
            {
                string stringToSend = "$CAM_SENS, " + sensValue;
                sensTextBox.Text = sensValue;

                invalidSensValueLabel.Text = "";

                data = Encoding.ASCII.GetBytes(stringToSend);
                server.SendTo(data, data.Length, SocketFlags.None, ipep);
            }
        }
    }
}