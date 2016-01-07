using System;
using System.Collections.Generic;
using System.Linq;
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

namespace WpfApplication1
{
    using System.Net.Http;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            resultsTextBox.Clear();
            await CreateMultipleTasksAsync();
            resultsTextBox.Text += "\r\nControl returned to start button click";
        }

        private async Task CreateMultipleTasksAsync()
        {
            var client = new HttpClient() { MaxResponseContentBufferSize = 1000000 };

            Task<int> download1 = ProcessURLAsync("http://msdn.microsoft.com", client);
            Task<int> download2 = ProcessURLAsync("http://msdn.microsoft.com/en-us/library/hh156528(VS.110).aspx", client);
            Task<int> download3 = ProcessURLAsync("http://msdn.microsoft.com/en-us/library/67w7t67f.aspx", client);

            int length1 = await download1;
            int length2 = await download2;
            int length3 = await download3;

            int total = length1 + length2 + length3;

            resultsTextBox.Text +=
                string.Format("\r\n\r\nTotal bytes returned:  {0}\r\n", total);
        }

        async Task<int> ProcessURLAsync(string url, HttpClient client)
        {
            var byteArray = await client.GetByteArrayAsync(url);
            DisplayResults(url, byteArray);

            return byteArray.Length;
        }

        private void DisplayResults(string url, byte[] content)
        {
            var bytes = content.Length;

            var displayURL = url.Replace("http://", "");

            resultsTextBox.Text += string.Format("\n{0,-58} {1, 8}", displayURL, bytes);
        }
    }
}
