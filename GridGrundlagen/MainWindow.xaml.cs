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

namespace GridGrundlagen
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

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            string url = YoutubeUrlTextBox.Text;
            string videoId = "ugji-_yWoRk"; //falls keine andere videoId gefunden werden kann

            if (url == string.Empty)
            {
                MessageBox.Show("Bitte gib eine YouTube-URL in die weiße Textbox ein!");
            }
            else if (url.Contains("youtu.be"))
            {
                string[] elements = url.Split('/');
                videoId = elements.Last();
            }
            else if (url.Contains("youtube.com"))
            {
                int startIndex = url.IndexOf("v=") + 2;
                int endIndex = url.IndexOf("&");
                videoId = url.Substring(startIndex, endIndex - startIndex);
            }

            YouTubePlayer.Address = $"https://www.youtube.com/embed/{videoId}?start=68&fs=1";
        }
    }
}
