using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WebAppAPI_ClientKennzeichen.Models;

namespace WebAppAPI_ClientKennzeichen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HttpClient client = new HttpClient();
        private List<DataModel> _listInfos = new List<DataModel>();


        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btnGetKennzeichen_Click(object sender, RoutedEventArgs e)
        {
            // https://localhost:7044/api/KennzeichenInfos
            client.BaseAddress = new Uri("https://localhost:7077/api/KennzeichenInfos");
            string strResult = await client.GetStringAsync(client.BaseAddress);
            lBox.Items.Add(strResult);
            DataModel[]? infos = await client.GetFromJsonAsync<DataModel[]>(client.BaseAddress);
            if (infos == null)
                return;
            _listInfos = new List<DataModel>();
            if (_listInfos == null)
                return;

            _listInfos.AddRange(infos);
            dGridResult.ItemsSource = _listInfos;
            //if (dGridResult.Columns.Contains("Id"))
                //dGridResult.Columns["Id"].Visible = false;

        }

        

        private async void btnSetKennzeichen_Click(object sender, RoutedEventArgs e)
        {
            // https://localhost:7044/api/KennzeichenInfos
            client.BaseAddress = new Uri("https://localhost:7077/api/KennzeichenInfos");
            
            DataModel newData = _listInfos.Last();
            //payload = JsonSerializer
            //await client.PutAsJsonAsync<DataModel>(newData);
            
            //string strResult = await client.GetStringAsync(client.BaseAddress);
            //lBox.Items.Add(strResult);
            
            DataModel[]? infos = await client.GetFromJsonAsync<DataModel[]>(client.BaseAddress);
            if (infos == null)
                return;
            List<DataModel> listInfos = new List<DataModel>();
            if (listInfos == null)
                return;

            listInfos.AddRange(infos);
            dGridResult.ItemsSource = listInfos;
            //if (dGridResult.Columns.Contains("Id"))
            //dGridResult.Columns["Id"].Visible = false;

        }
    }
}