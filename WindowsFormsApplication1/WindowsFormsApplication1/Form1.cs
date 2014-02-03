using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //byte[] b = { 0x00, 0x13, 0x20, 0xdc, 0x88, 0x92 };
            string a = textBox1.Text;
            byte[] c=strToToHexByte(a);
            WakeUp(c);
        }

        private static void WakeUp(byte[] mac)
        {
            UdpClient client = new UdpClient();
            client.Connect(IPAddress.Broadcast, 30000);

            byte[] packet = new byte[17 * 6];

            for (int i = 0; i < 6; i++)
                packet[i] = 0xFF;

            for (int i = 1; i <= 16; i++)
                for (int j = 0; j < 6; j++)
                    packet[i * 6 + j] = mac[j];

            int result = client.Send(packet, packet.Length);
            if (result != packet.Length)
            {
                System.Windows.Forms.MessageBox.Show("wrong\n");
            }
        }

        private static byte[] strToToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        } 
    }
}
