using configuratore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace configuratoreSerial6._0
{
    internal class reportCls
    {

        static int device;
        static string Matricola;

        static public void setMatricola(String m) {  Matricola = m; }

        static public void setDevice(int x) { device = x; }
        static public void SaveTestReportFile()
        {
            String dt = DateTime.Now.ToString("yyyy_MM_dd_"); //  2015 - 05 - 16T05: 50:06
            String fileName = dir.getDir(device) + "TestReport_" + dt+".csv";
            if (!File.Exists(fileName))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(fileName))
                {
                    sw.WriteLine(formatCSVString());
                    sw.Close();
                }
            } else
            {
                using (StreamWriter sw = File.AppendText(fileName))
                {
                    sw.WriteLine(formatCSVString());
                    sw.Close();
                }
            }
        }

        static string  formatCSVString()
        {
            String r = DateTime.Now.ToString("HH:mm")+"\t"+Matricola;
            for (int i=0;i<reportList.getSizeList();i++ )
            {
                r = r + "\t" + reportList.getLabelList(i) + "\t" + reportList.getPassFailList(i);
            }
            return r;    
        }


    }
}
