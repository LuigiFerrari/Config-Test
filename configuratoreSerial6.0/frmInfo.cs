using configuratoreSerial6._0.uniqueID;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace configuratore
{
    public partial class frmInfo : Form
    {
        String[] Livelli =
        {
            "MANUFACTURER",
            "COMMISIONING",
            "USER"

        };
        public frmInfo(int codice)
        {
            InitializeComponent();
            lblLivello.Text = Livelli[codice];
        }

        private void frmInfo_Load(object sender, EventArgs e)
        {
            softwareRelease.Text = Versione.getVersion();
            // cercaUSB1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmRequireCOnfig frmRequire = new frmRequireCOnfig();
            frmRequire.ShowDialog();
            int configurazione = frmRequire.getConfig();
            if (configurazione >= 0)
            {
                uniqueID.setConfigurazione(configurazione);
                lblLivello.Text = Livelli[configurazione];
                global.setLivello(configurazione);
            }
        }



        // Add a reference to System.Management.
        //private void cercaUSB()
        //{
        //    ManagementObjectSearcher device_searcher =
        //        new ManagementObjectSearcher("SELECT * FROM Win32_USBHub");
        //    foreach (ManagementObject usb_device in device_searcher.Get())
        //    {
        //        Debug.WriteLine(usb_device.Properties["DeviceID"].Value.ToString());
        //        Debug.WriteLine(usb_device.Properties["PNPDeviceID"].Value.ToString());
        //        Debug.WriteLine(usb_device.Properties["Description"].Value.ToString());
        //        Debug.WriteLine("-----------------------");
        //    }
        //}

        //private void cercaUSB1()
        //{
        //    ManagementObjectCollection collection;
        //    using (var searcher = new ManagementObjectSearcher(@"Select * From Win32_PnPEntity"))
        //        collection = searcher.Get();


        //    foreach (var device in collection)
        //    {
        //        Debug.WriteLine((string)device.GetPropertyValue("DeviceID"));
        //        Debug.WriteLine((string)device.GetPropertyValue("PNPDeviceID"));
        //        Debug.WriteLine((string)device.GetPropertyValue("Description"));
        //        Debug.WriteLine((string)device.GetPropertyValue("Name"));
        //        Debug.WriteLine((string)device.GetPropertyValue("Caption"));
        //        Debug.WriteLine((string)device.GetPropertyValue("Service"));
        //        Debug.WriteLine((string)device.GetPropertyValue("iManufacturer"));
        //        Debug.WriteLine((string)device.GetPropertyValue("Name"));
        //        Debug.WriteLine("-----------------------");


        //        // Other properties supported by Win32_PnPEntity
        //        // See http://msdn.microsoft.com/en-us/library/aa394353%28v=vs.85%29.aspx
        //        //var keys = new string[] {
        //        //        "Availability",
        //        //        "Caption",
        //        //        "ClassGuid",
        //        //        "CompatibleID[]",
        //        //        "ConfigManagerErrorCode",
        //        //        "ConfigManagerUserConfig",
        //        //        "CreationClassName",
        //        //        "Description",
        //        //        "DeviceID",
        //        //        "ErrorCleared",
        //        //        "ErrorDescription",
        //        //        "HardwareID[]",
        //        //        "InstallDate",
        //        //        "LastErrorCode",
        //        //        "Manufacturer",
        //        //        "Name",
        //        //        "PNPDeviceID",
        //        //        "PowerManagementCapabilities[]",
        //        //        "PowerManagementSupported",
        //        //        "Service",
        //        //        "Status",
        //        //        "StatusInfo",
        //        //        "SystemCreationClassName",
        //        //        "SystemName"
        //        //};

        //    }

        //    collection.Dispose();
        //}

    }
}
