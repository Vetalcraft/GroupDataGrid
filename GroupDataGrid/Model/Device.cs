using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupDataGrid.Model
{
    class Device
    {
        public int ID { get; set; }
        public string IP { get; set; }
        public string TypeDevice { get; set; }

        public Device(int id, string ip, int td)
        {
            ID = id;
            IP = ip;

            switch (td)
            {
                case 0:
                    TypeDevice = "PC";
                    break;

                case 1:
                    TypeDevice = "Router";
                    break;

                case 2:
                    TypeDevice = "Printer";
                    break;
            }
        }

    }
}
