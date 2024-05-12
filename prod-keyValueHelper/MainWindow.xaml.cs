using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using prod_keyValueHelper.data;


namespace prod_keyValueHelper;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        LoadAsyncChecker();
    }

    private async void LoadAsyncChecker()
    {
        DataImportedChecker dataImportedChecker = new DataImportedChecker();
        FileUtils fileUtils = new FileUtils();
        if (fileUtils.FileIsImported() && await dataImportedChecker.IsDatabaseIsInitialized())
        {
            MainFrame.Navigate(new MainPage());
        }
        else
        {
            var startPage = new StartPageGetData(MainFrame);
            MainFrame.Navigate(startPage);
        }
    }
}