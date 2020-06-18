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
using System.Windows.Shapes;
using CommonModels;
using CommonModels.Models;
using Newtonsoft.Json;
using Xceed.Wpf.AvalonDock.Controls;
using Xceed.Wpf.Toolkit;

namespace PremiereWpf1
{
    /// <summary>
    /// Логика взаимодействия для SessionsWindow.xaml
    /// </summary>
    public partial class SessionsWindow : Window
    {
        private readonly HttpClient httpClient;
        public SessionsWindow(Film film, IEnumerable<Session> sessions)
        {
            InitializeComponent();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44375/")
            };
            this.Title = film.Name;
            SessionsView.ItemsSource = sessions
                .Where(x => x.Film.Id == film.Id).ToList();
        }

        public void OnClick(object sender, RoutedEventArgs e)
        {
            var parent = VisualTreeHelper.GetParent((DependencyObject) sender);
            var button = (Button) sender;
            var session = (Session) button.DataContext;
            var quantity = parent.FindVisualChildren<IntegerUpDown>().First().Value;
            if (quantity == null)
                return;
            Task.Run(() => SendOrder(session, quantity.Value));
        }

        public async Task SendOrder(Session session, int quantity)
        {
            var order = new Order {Quantity = quantity, SessionId = session.Id};
            var content = new StringContent(JsonConvert.SerializeObject(order), Encoding.UTF8, "application/json");
            await httpClient.PostAsync("api/orders/create", content);
        }
    }
}
