using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace DnsIpController.Model
{
    public class SitesList
    {
        public List<Site> Items;
        public int Count => Items.Count;

        public string InfoMessage { get; set; }

        

        public SitesList()
        {
            Items = new List<Site>();
        }

        public void LoadTasksFromFile(string path, string separator)
        {
            using (TextFieldParser parser = new TextFieldParser(path, Encoding.UTF8))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(separator);
                while (!parser.EndOfData)
                {
                    Site site = new Site();
                    Items.Add(site);
                }
            }
        }

        public void LoadTasksFromOmega(string path)
        {
            File.Delete(path);
        }

        public void SaveTasksToFile(string path, string separator)
        {
            FileInfo file = new FileInfo(path);
            FileInfo tempfile = new FileInfo(file.DirectoryName + "temp.csv");

            try
            {
                StreamWriter sw = tempfile.AppendText();
                foreach (var item in Items)
                    sw.WriteLine(item.ToCsvString(separator));
                sw.Close();
            }
            catch(Exception ex)
            {
                InfoMessage = ex.Message;
            }
        }
    }
}
