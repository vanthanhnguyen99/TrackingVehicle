using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTracking
{
    class coord
    {
        public double x { get; set; }
        public double y { get; set; }
        public string name { get; set; }

        public coord()
        { }
        public coord(double x, double y, string name)
        {
            this.x = x;
            this.y = y;
            this.name = name;
        }

        public byte[] toByteArray()
        {
            List<byte> list = new List<byte>();

            list.AddRange(BitConverter.GetBytes(this.x));
            list.AddRange(BitConverter.GetBytes(this.y));

            return list.ToArray();
        }

        public void convertByteToCord(byte[] data)
        {

            // Bit 1st to bit 8th storage x
            this.x = BitConverter.ToDouble(data, 0);
            // Bit 9th to bit 16th storage y
            this.y = BitConverter.ToDouble(data, 8);
            // Bit 17th to end storage name
            byte[] bytes = new byte[data.Length - 16];
            for (int i = 16; i < data.Length; i++)
            {
                if (Convert.ToChar(data[i]) == '\0') break;
                bytes[i - 16] = data[i];
            }
            this.name = System.Text.Encoding.ASCII.GetString(bytes).ToString();

        }

        public void displayData()
        {
            Console.WriteLine(x + "," + y);
            Console.WriteLine("name: " + this.name);

        }
    }
}
