using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CommonModels;

namespace PremiereWpf1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly HttpClient httpClient;
        private List<Session> sessions { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44375/")
            };
            FetchSessions().Wait();
            RenderFilms();
        }

        private void CreateGridRows(int quantity)
        {
            for (var i = 0; i < quantity; i++)
                LayoutGrid.RowDefinitions.Add(new RowDefinition());

        }

        private void HandleFilmClick(Object sender, MouseButtonEventArgs e, Film film)
        {
            var sessionWindow = new SessionsWindow(film, sessions);
            sessionWindow.Show();
        }

        private void RenderFilms()
        {
            var films = sessions.Select(x => x.Film)
                .GroupBy(x => x.Id)
                .Select(x => x.First())
                .ToList();
            CreateGridRows(films.Count);
            for (var i = 0; i < films.Count; i++)
            {
                var textBlock = new TextBlock
                {
                    Text = films[i].Name
                };
                var currentI = i;
                textBlock.MouseLeftButtonUp +=
                    (sender, e) =>
                    HandleFilmClick(sender, e, films[currentI]);
                Grid.SetColumn(textBlock, i % 3);
                Grid.SetRow(textBlock, i / 3);
                LayoutGrid.Children.Add(textBlock);
            }
        }

        private async Task FetchSessions()
        {
            var response = httpClient.GetAsync("api/session/get").Result;
            if (response.IsSuccessStatusCode)
            {
                sessions = JsonConvert
                    .DeserializeObject<List<Session>>(
                        await response.Content.ReadAsStringAsync()
                    );
            }
        }
    }
}
