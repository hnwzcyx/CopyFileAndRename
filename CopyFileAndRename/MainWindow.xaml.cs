using System;
using System.Collections.Generic;
using System.IO;
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

namespace CopyFileAndRename
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Source.Text = @"C:\Users\36098\AppData\Local\Packages\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\LocalState\Assets";
            this.sufix.Text = ".jpg";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string SourceDictory = this.Source.Text;
            string TargetDictory = this.Target.Text;
            string Sufix = this.sufix.Text;
            if (Directory.Exists(SourceDictory))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(SourceDictory);
                var dirs = directoryInfo.GetFiles();
                foreach (var file in dirs)
                {
                    var newFullName = System.IO.Path.Combine(TargetDictory, file.Name);
                    newFullName = newFullName + Sufix;
                   var newFile = file.CopyTo(newFullName);
                    if (newFile != null)
                    {
                        this.Detial.Text += newFile.FullName;
                    }
                }
            }
        }
    }
}
