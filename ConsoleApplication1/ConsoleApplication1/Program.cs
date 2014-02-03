using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] b = { 0x00, 0x13, 0x20, 0xdc, 0x88, 0x92 };
            System.Console.WriteLine("hello world");
            WakeUp(b);
            return ;

        }
        private static void WakeUp(byte[] mac) {
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
    }
}
