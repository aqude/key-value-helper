using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using prod_keyValueHelper.data;

namespace prod_keyValueHelper;

public partial class StartPageGetData : Page
{
    private DataImportedChecker _dataImportedChecker = new DataImportedChecker();
    private FileUtils _fileUtils = new FileUtils();
    private Frame _frame;

    public StartPageGetData(Frame frame)
    {
        _frame = frame;
        InitializeComponent();
        LoadAsyncImportDataChecker();
    }

    private async void LoadAsyncImportDataChecker()
    {
        var database = new Database();
        var result = await _dataImportedChecker.IsDatabaseIsInitialized();
        if (!result)
        {
            await database.OpenConnectionAsync();
            database.InitDatabase();
            database.CloseConnection();
        }
    }

    private async void ButtonGetDataOnJsonFile(object sender, RoutedEventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "JSON files (*.json)|*.json|CSV files (*.csv)|*.csv";
        if (openFileDialog.ShowDialog() == true)
        {
            string path = openFileDialog.FileName;
            _fileUtils.ImportFile(path);
        }
        await _fileUtils.ImportDataToDatabase();
        // sleep
        await Task.Delay(1000);
        _frame.Navigate(new MainPage());
    }

    private void HelpButtonOnClick(object sender, RoutedEventArgs e)
    {
        HelpWindow helpWindow = new HelpWindow();
        helpWindow.Show();
    }
}