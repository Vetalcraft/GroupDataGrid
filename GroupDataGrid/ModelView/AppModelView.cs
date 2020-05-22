using GroupDataGrid.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace GroupDataGrid.ModelView
{
    class AppModelView : INotifyPropertyChanged
    {

        #region Variables

        private ObservableCollection<Device> devices = new ObservableCollection<Device>();
        public static int IdCount { get; set; }
        private CollectionViewSource vData;

        #endregion

        #region Property
        public ObservableCollection<Device> Devices
        {
            get { return devices; }
            set { devices = value; OnPropetryChanged(); }
        }

        public CollectionViewSource VData
        {
            get { return vData; }
            set { vData = value; OnPropetryChanged(); }
        }
        #endregion

        #region Constructor

        public AppModelView()
        {
            Random rnd = new Random();
            VData = new CollectionViewSource() { };
            

            for (int thirdOctet = 0; thirdOctet < 1; thirdOctet++)
            {
                for (int fourthOctet = 0; fourthOctet < 256; fourthOctet++)
                {
                    Devices.Add(new Device(AppModelView.IdCount++, $"192.168.{thirdOctet}.{fourthOctet}", rnd.Next(3)));
                }
            }

            VData.Source = Devices;
            VData.GroupDescriptions.Add(new PropertyGroupDescription("TypeDevice"));
            VData.IsLiveGroupingRequested = true;
            


        }

        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropetryChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        #endregion
    }
}
