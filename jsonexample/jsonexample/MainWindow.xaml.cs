using Newtonsoft.Json;
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

namespace jsonexample
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

        private void btnGetquote_Click(object sender, RoutedEventArgs e)
        {
            //https://got-quotes.herokuapp.com/quotes

            using (HttpClient client = new HttpClient())//using system.net.http
            {
                HttpResponseMessage response = client.GetAsync(@"https://got-quotes.herokuapp.com/quotes").Result;//need @ when entering url .result gets out of Asynch. 
                if (response.IsSuccessStatusCode)//
                {
                    var content = response.Content.ReadAsStringAsync().Result;
                    GOTquote gq = JsonConvert.DeserializeObject<GOTquote>(content); //using newtonsoft.json

                   // var x = JsonConvert.SerializeObject(gq); not needed
                   txtQuote.Text = gq.quote + "\n" + "-" + gq.character;
                }
            }
            //copied and pasted from canvas
        }
    }
}
