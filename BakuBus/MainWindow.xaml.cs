using Microsoft.Maps.MapControl.WPF;
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
//KEY-PGgXDxXtbqJFb22FYOW4~V9ZWj-mMArtwhcHO7OXOyA~Amvufht9v-dLEV-Fp360l5Jk0Lwhvc8UUO9DNGeO0BMQj3ziwsNsDQADV1M-iewb
namespace BakuBus
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string Key { get; set; } = " PGgXDxXtbqJFb22FYOW4~V9ZWj-mMArtwhcHO7OXOyA~Amvufht9v-dLEV-Fp360l5Jk0Lwhvc8UUO9DNGeO0BMQj3ziwsNsDQADV1M-iewb";
        public ApplicationIdCredentialsProvider Provider { get; set; }

        public MainWindow()
        {
            this.DataContext = this;
            Provider = new ApplicationIdCredentialsProvider(Key);
            InitializeComponent();
            GetBusses();
        }
        public void GetBusses()
        {
            var client = new HttpClient();
            var link = "https://www.bakubus.az/az/ajax/apiNew1";
            dynamic busses = JsonConvert.DeserializeObject(client.GetAsync(link).Result.Content.ReadAsStringAsync().Result);
            foreach (var item in busses)
            {
                dynamic bus = item["@attributes"];
                string driverName = bus["DRIVER_NAME"];

                //MessageBox.Show(item.ToString());
            }
            {

            }
        }
    }
}
