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
            Items.Clear();

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
                        InfoMessage = $"Загружено {Count} заданий";
                    }
                    catch (Exception ex)
                    {
                        exeptions++;
                        InfoMessage = $"Ошибок загрузки из файла - {exeptions} ({ex.Message})";
                        continue;
                    }
                }
            } 
        }

        public void LoadFromInternet(string path, SetInfoDelegate sid)
        {
            if (Count == 0)
            {
                InfoMessage = "Нет заданий для проверки адреса в сети Интернет";
                return;
            }
            try
            {
                for (int i = 0; i < Count; i++)
                {
                    Items[i].LoadFromInternet();
                    sid($"Обработано {i+1} заданий");
                }
                InfoMessage = $"Обработка заданий закончена. Обработано {Count} заданий";
                SaveTasksToFile(path, ";");
            }
            catch (Exception ex)
            {
                InfoMessage = $"Ошибка при загрузке данных из Интернета: {ex.Message}";
                return;
            }
        }

        public bool LoadTasksFromOmega(string path)
        {
            Items.Clear();
            if (DataBase.LoadTasksFromOmega(this))
            {
                SaveTasksToFile(path, ";");
                return true;
            }
            return false;
        }

        public void SaveTasksToFile(string path, string separator)
        {
            FileInfo file = new FileInfo(path);
            FileInfo tempfile = new FileInfo(file.DirectoryName + "temp.csv");

            try
            {
                using (StreamWriter sw = new StreamWriter(tempfile.FullName, true, Encoding.UTF8))
                {
                    foreach (var item in Items)
                        sw.WriteLine(item.ToCsvString(separator));
                }
                file.Delete();
                tempfile.MoveTo(path);
            }
            catch(Exception ex)
            {
                InfoMessage =  $"Ошибка сохранения в файл: {ex.Message}";
            }
        }
    }
}
