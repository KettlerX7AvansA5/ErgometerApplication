using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ErgometerLibrary;
namespace ErgometerApplication
{
    class DataSaving
    {
        List<Meting> local_data = null;
        private List<Meting> ReadFile()
        {
            string path;
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Ergometer files(*.ergo) | *.ergo | All files(*.*) | *.*";
            if (file.ShowDialog() == DialogResult.OK)
            {
                path = file.FileName;
                List<Meting> readFile = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Meting>>(System.IO.File.ReadAllText(path));
                return readFile;
            }
            else
            {
                return null;
            }
        }
        private List<Meting> SaveData(Meting meting, List<Meting> _data)
        {
            List<Meting> local_data = _data;
            local_data.Add(meting);
            return local_data;
        }
        private void WriteFile(List<Meting> _data)
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(_data);
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ErgometerSessionData.ergo");
            System.IO.File.WriteAllText(path, json);
            Console.WriteLine("Writing file: " + path);
        }
       

    }
}
