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

namespace AsyncExampleWPF
{
    using System.Collections;
    using System.IO;
    using System.Net;
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

        private async void startButton_Click(object sender, RoutedEventArgs e)
        {
            startButton.IsEnabled = false;

            resultsTextBox.Clear();
            await SumPageSizesAsync();
            resultsTextBox.Text += "\r\nControl returned to startButton_Click";

            startButton.IsEnabled = true;
        }

        private async Task SumPageSizesAsync()
        {
            var urlList = SetUpURLList();
            var client = new HttpClient() { MaxResponseContentBufferSize = 1000000 };

            IEnumerable<Task<int>> downloadTasksQuery = urlList.Select(url => ProcessURL(url, client));

            // this starts query
            Task<int>[] downloadTasks = downloadTasksQuery.ToArray();

            int[] lengths = await Task.WhenAll(downloadTasks);

            int total = lengths.Sum();

            //            var total = 0;


            //            foreach (var url in urlList)
            //            {
            //                var urlContents = await client.GetByteArrayAsync(url);
            //
            //                DisplayResults(url, urlContents);
            //
            //                total += urlContents.Length;
            //            }

            resultsTextBox.Text += String.Format("\r\n\r\nTotal bytes returned:  {0}\r\n", total);
        }

        private async Task<int> ProcessURL(string url, HttpClient client)
        {
            var byteArray = await client.GetByteArrayAsync(url);
            DisplayResults(url, byteArray);

            return byteArray.Length;
        }

        private void DisplayResults(string url, byte[] content)
        {
            // Display the length of each website. The string format 
            // is designed to be used with a monospaced font, such as
            // Lucida Console or Global Monospace.
            var bytes = content.Length;
            // Strip off the "http://".
            var displayURL = url.Replace("http://", "");
            resultsTextBox.Text += string.Format("\n{0,-58} {1,8}", displayURL, bytes);
        }

        private async Task<byte[]> GetURLContentsAsync(string url)
        {
            var content = new MemoryStream();

            var webReq = (HttpWebRequest) WebRequest.Create(url);

            using (var response = await webReq.GetResponseAsync())
            {
                using (var responseStream = response.GetResponseStream())
                {
                    await responseStream.CopyToAsync(content);
                }
            }

            return content.ToArray();
        }



        private List<string> SetUpURLList()
        {
            var urls = new List<string>
            {
                "http://msdn.microsoft.com/library/windows/apps/br211380.aspx",
                "http://msdn.microsoft.com",
                "http://msdn.microsoft.com/en-us/library/hh290136.aspx",
                "http://msdn.microsoft.com/en-us/library/ee256749.aspx",
                "http://msdn.microsoft.com/en-us/library/hh290138.aspx",
                "http://msdn.microsoft.com/en-us/library/hh290140.aspx",
                "http://msdn.microsoft.com/en-us/library/dd470362.aspx",
                "http://msdn.microsoft.com/en-us/library/aa578028.aspx",
                "http://msdn.microsoft.com/en-us/library/ms404677.aspx",
                "http://msdn.microsoft.com/en-us/library/ff730837.aspx"
            };

            return urls;
        }
    }
}
