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
using Newtonsoft.Json;

namespace PremiereWpf1
{
    /// <summary>
    /// Логика взаимодействия для SessionsWindow.xaml
    /// </summary>
    public partial class SessionsWindow : Window
    {
        public SessionsWindow(Film film, List<Session> sessions)
        {
            InitializeComponent();
            this.Title = film.Name;
            SessionsView.ItemsSource = sessions
                .Where(x => x.Film.Id == film.Id).ToList();
        }

        public void OnClick(object sender, RoutedEventArgs e)
        {
          
        }
    }
}
