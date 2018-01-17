using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace AsyncAwait
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            txtOutput.Text = string.Empty;

            btnCpuBoundTask.Click += async (o, e) =>
            {
                txtOutput.Text += $"Doing long-running operation." + Environment.NewLine;

                var totalCount = await Task.Run(() =>
                {
                    int count = 0;
                    for (int i = 0; i < 100000000; i++)
                    {
                        count += i;
                    }

                    return count;
                });

                txtOutput.Text += $"Calculated result was {totalCount}." + Environment.NewLine;
            };

            btnIoBoundTask.Click += async (o, e) =>
            {
                txtOutput.Text += $"Downloading file." + Environment.NewLine;
                var client = new WebClient();
                await client.DownloadFileTaskAsync("http://dotnetfoundation.org", "temp.txt");
                txtOutput.Text += $"Done." + Environment.NewLine;
            };


        }

        
    }
}
