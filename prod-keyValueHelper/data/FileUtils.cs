using System.IO;
using System.Windows;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;

namespace prod_keyValueHelper.data;

public class FileUtils
{
    private string _pathToConfigJsonfile;
    private string _jsonFileReadData;
    private FileInfo? deserializeObjectDataFileInfo;
    private string _projectPath;
    // файл для импорта
    private string _importedFile;
    //private static string _path = "./prod-keyValueHelper/data/fileinfo.json";

    public FileUtils()
    {
        _projectPath = AppDomain.CurrentDomain.BaseDirectory;
        _pathToConfigJsonfile = Path.Combine(_projectPath, "data/fileinfo.json");
        // читает файл конфигурации 
        _jsonFileReadData = File.ReadAllText(_pathToConfigJsonfile);
        // десериализует
        deserializeObjectDataFileInfo = JsonConvert.DeserializeObject<FileInfo>(_jsonFileReadData); // json path
        //_fileInfo = JsonConvert.DeserializeObject<FileInfo>(_jsonFileReadData); #json or csv
    }

    public class FileUtilsPathGetter()
    {
        public string _projectPath { get; set; }
        public string _pathToConfigJsonfile { get; set; }
        public string _importedFile { get; set; }

        public string _jsonFileReadData { get; set; }
        
        public string deserializeObjectDataFileInfo { get; set; }
    }

    public FileUtilsPathGetter GetFileUtils()
    {
        return new FileUtilsPathGetter
        {
            _projectPath = _projectPath,
            _pathToConfigJsonfile = _pathToConfigJsonfile,
            _importedFile = _importedFile,
            _jsonFileReadData = _jsonFileReadData,
            deserializeObjectDataFileInfo = deserializeObjectDataFileInfo.FilePath
        };
    }

    public bool FileIsImported()
    {
        if (GetFileUtils().deserializeObjectDataFileInfo != "") return true;
        else return false;
    }

    public void ImportFile(string filePath)
    {
        GetFileUtils().deserializeObjectDataFileInfo = filePath;
        var fileInfo = new FileInfo { FilePath = filePath };
        string serializedData = JsonConvert.SerializeObject(fileInfo, Formatting.Indented);
        File.WriteAllText(GetFileUtils()._pathToConfigJsonfile, serializedData);
    }


    async public Task ImportDataToDatabase()
    {
        Database database = new Database();
        var filepath = GetFileUtils().deserializeObjectDataFileInfo;
        var readData = File.ReadAllText(filepath);
        switch (filepath)
        {
            case var _ when filepath.EndsWith(".json"):
                Root root = JsonConvert.DeserializeObject<Root>(readData);
                foreach (var interaction in root.InteractionsTable)
                {
                    database.InsertData(interaction.AttributeKey, interaction.AttributeValue);
                }

                break;
            case var _ when filepath.EndsWith(".csv"):
                List<IInteraction> interactions = new List<IInteraction>();
                using (TextFieldParser parser = new TextFieldParser(filepath))
                {
                    parser.Delimiters = new[] { "," };
                    while (!parser.EndOfData)
                    {
                        var fields = parser.ReadFields();
                        var attribute = new Interaction { AttributeKey = fields[0], AttributeValue = fields[1] };
                        interactions.Add(attribute);
                    }
                }

                foreach (var attribute in interactions)
                {
                    await database.InsertData(attribute.AttributeKey, attribute.AttributeValue);
                }
                break;
            default:
                System.Windows.MessageBox.Show("Неверное расширение файла");
                break;
        }
    }
}