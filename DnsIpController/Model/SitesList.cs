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
                int exeptions = 0;

                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(separator);
                while (!parser.EndOfData)
                {
                    try
                    {
                        string[] fields = parser.ReadFields();
                        Site site = new Site(
                                                Convert.ToInt32(fields[0]),
                                                Convert.ToInt32(fields[1]),
                                                fields[2],
                                                fields[3],
                                                Convert.ToInt32(fields[4]),
                                                fields[5],
                                                fields[6],
                                                fields[7],
                                                fields[8],
                                                fields[9],
                                                fields[10]
                                            );
                        Items.Add(site);
                        InfoMessage = $"Загружено {Count} сайтов";
                    }
                    catch(Exception ex)
                    {
                        exeptions++;
                        InfoMessage = $"Ошибок загрузки из файла - {exeptions} ({ex.Message})";
                        continue;
                    }
                }
            } 
        }

        public bool LoadTasksFromOmega(string path)
        {
            if (DataBase.LoadTasksFromOmega(this))
            {
                SaveTasksToFile(path, ";");
                LoadTasksFromFile(path, ";");
                return true;
            }
            return false;
        }

        private void SaveTasksToFile(string path, string separator)
        {
            FileInfo file = new FileInfo(path);
            FileInfo tempfile = new FileInfo(file.DirectoryName + "temp.csv");

            try
            {
                StreamWriter sw = tempfile.AppendText();
                foreach (var item in Items)
                    sw.WriteLine(item.ToCsvString(separator));
                sw.Close();
                file.Delete();
                tempfile.MoveTo(path);
            }
            catch(Exception ex)
            {
                InfoMessage = ex.Message;
            }
        }
    }
}
