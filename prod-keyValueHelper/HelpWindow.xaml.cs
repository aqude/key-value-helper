using System.Windows;
using System.Windows.Shapes;
using prod_keyValueHelper.data;
using Path = System.IO.Path;

namespace prod_keyValueHelper;

public partial class HelpWindow : Window
{
    private string _image1Json;
    private string _image2Csv;
    public HelpWindow()
    {
        InitializeComponent();
        
        FileUtils fileUtils = new FileUtils();

        DataImagesGetter dataImagesGetter = new DataImagesGetter()
        {
            Image1JsonGetter = Path.Combine(fileUtils.GetFileUtils()._projectPath, "img", "json.png"),
            Image2CsvGetter = Path.Combine(fileUtils.GetFileUtils()._projectPath, "img", "csv.png"),
        };
        
        this.DataContext = dataImagesGetter;
    }

    public class DataImagesGetter
    {
        public string Image1JsonGetter { get; set; }
        public string Image2CsvGetter { get; set; }
    }
    
    public DataImagesGetter GetDataImagesGetter()
    {
        return new DataImagesGetter
        {
            Image1JsonGetter = _image1Json,
            Image2CsvGetter = _image2Csv
        };
    }
}