using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CommonModels;
using Newtonsoft.Json;

namespace PremiereWpf1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly HttpClient httpClient;
        public MainWindow()
        {
            InitializeComponent();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44375/")
            };
            RenderSessions().GetAwaiter().GetResult();
        }

        private async Task RenderSessions()
        {
            var sessions = await FetchSessions();
            foreach (var session in sessions)
            {
                LayoutGrid.RowDefinitions.Add(new RowDefinition());
                var textBlock = new TextBlock
                {
                    Text = session.Film.Name
                };
                LayoutGrid.Children.Add(textBlock);
            }
        }
        private async Task<List<Session>> FetchSessions()
        {
            var response = httpClient.GetAsync("api/session/get").Result;
            if (response.IsSuccessStatusCode)
            {
                var rawAnser = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Session>>(rawAnser);
            }
            return new List<Session>(0);
        }
    }
}
