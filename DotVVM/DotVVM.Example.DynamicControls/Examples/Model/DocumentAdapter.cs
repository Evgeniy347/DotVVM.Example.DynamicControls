using DotVVM.Framework.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Example.DynamicControls.Examples.Controls;
using System.Web.Hosting;

namespace DotVVM.Example.DynamicControls.Examples.Model
{
    internal static class DocumentAdapter
    {
        private static readonly object _lock = new object();
        private static FileSite _instance;
        public static FileSite EnshureSite()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        string folder = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "..\\lists");
                        string[] files = Directory.GetFiles(folder, "*.csv");
                        FileSite fileSite = new FileSite();
                        fileSite.Lists = new Dictionary<string, FileList>(files.Length);

                        foreach (string file in files)
                        {
                            string[] lines = File.ReadAllLines(file);

                            string headerLines = lines[0];
                            FieldSetting[] settings = InitFields(headerLines);

                            FileList fileList = new FileList()
                            {
                                Name = Path.GetFileNameWithoutExtension(file),
                                Fields = settings,
                                Items = lines.Skip(1).Select(x => Convert(x, settings)).ToDictionary(x => x.ID),
                            };

                            fileSite.Lists.Add(fileList.Name, fileList);
                        }
                        _instance = fileSite;
                    }
                }
            }

            return _instance;
        }

        public static void Save(FileList list)
        {
            string header = list.Fields.Select(x => $"{x.Name}({x.Type})").StringJoin(";");
            List<string> result = list.Items.Values.Select(Convert).ToList();
            result.Insert(0, header);

            string folder = Path.Combine("C:\\Users\\GTR\\Desktop\\По работе\\DotVVM\\lists", $"{list.Name}.csv");
            File.WriteAllLines(folder, result);
        }

        private static string Convert(FileItem item)
        {
            return item.FieldValue.Select(x => x.Value?.ToString()).StringJoin(";");
        }

        private static FileItem Convert(string line, FieldSetting[] settings)
        {
            string[] parts = line.Split(';');
            FileItem fileItem = new FileItem()
            {
                FieldValue = new FieldValue[settings.Length]
            };

            int i = -1;
            foreach (FieldSetting setting in settings)
            {
                string valueRaw = parts[++i];
                FieldValue fieldValue = new FieldValue()
                {
                    Name = setting.Name,
                    FieldSetting = setting,
                };

                fileItem.FieldValue[i] = fieldValue;
                try
                {
                    switch (setting.Type)
                    {
                        case "int":
                            {
                                if (setting.Name == "ID")
                                    fieldValue.Value = fileItem.ID = int.Parse(valueRaw);
                                else
                                    fieldValue.Value = int.Parse(valueRaw);
                            }
                            break;
                        case "string":
                            {
                                fieldValue.Value = valueRaw;
                            }
                            break;
                        case "bool":
                            {
                                fieldValue.Value = bool.Parse(valueRaw);
                            }
                            break;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Ошибка пр обработке колонки '{setting.Name}' типа '{setting.Type}', значение '{valueRaw}'", ex);
                }
            }

            return fileItem;
        }

        private static FieldSetting[] InitFields(string headerLines)
        {
            string[] parts = headerLines.Split(';');
            List<FieldSetting> reault = new List<FieldSetting>(parts.Length);
            foreach (string part in parts)
            {
                string[] columnSettings = part.Split('(', ')', ',')
                    .Select(x => x.Trim())
                    .Where(x => !string.IsNullOrEmpty(x))
                    .ToArray();

                reault.Add(new FieldSetting()
                {
                    Name = columnSettings[0],
                    Type = columnSettings[1],
                });
            }

            return reault.ToArray();
        }
    }
}
