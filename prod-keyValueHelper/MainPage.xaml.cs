using System.Windows;
using System.Windows.Controls;
using prod_keyValueHelper.data;

namespace prod_keyValueHelper;

public partial class MainPage : Page
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        Database database = new Database();
        string key = TextValue.Text;
        string value = await database.FindData(key);
        if (value == null)
        {
            MessageBox.Show("Ключ не найден");
        }
        else
        {
            Thread thread = new Thread(() => Clipboard.SetText(value));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
            
            MessageBox.Show($"Значение: {value}\n\nДанные скорректны");
        }
    }
}