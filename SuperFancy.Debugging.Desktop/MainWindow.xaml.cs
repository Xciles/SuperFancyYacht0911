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
using Newtonsoft.Json;

namespace SuperFancy.Debugging.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // My "library" method.
        public static async Task<User> GetJsonAsync(Uri uri)
        {
            using (var client = new HttpClient())
            {
                var jsonString = await client.GetStringAsync(uri);
                return JsonConvert.DeserializeObject<User>(jsonString);
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var jsonTask = await GetJsonAsync(new Uri("https://jsonplaceholder.typicode.com/users/1"));
            textBox1.Text = jsonTask.Name;
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
    }
}
