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
using System.Threading.Tasks;
using System.IO;
using BytesRoad.Net.Ftp;
using INIManager;


namespace FTP_Agent
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
        string appPath = AppDomain.CurrentDomain.BaseDirectory;


        public MainWindow()
        {
            InitializeComponent();
        }


        FtpClient client = new FtpClient();
        string timeWork;

        FtpClient client2 = new FtpClient();
        string currentPath;
        string currentPath2;


        // Сохраняем данные в ini файл
        public void getDataFromIni()
        {
            string basePath = System.IO.Path.Combine(appPath);
            INIManager.Class1.INIManager manager = new Class1.INIManager(appPath + @"/my.ini");

            txtPath.Text = manager.GetPrivateString("main", "basePath");
            txtPath2.Text = manager.GetPrivateString("main", "basePath2");

            txtServer.Text = manager.GetPrivateString("main", "server");
            txtPort.Text = manager.GetPrivateString("main", "port");
            txtLogin.Text = manager.GetPrivateString("main", "login");
            txtPassword.Password = manager.GetPrivateString("main", "passw");

            if (manager.GetPrivateString("main", "viewAll") == "True")
                chAll.IsChecked = true;
            else
                chAll.IsChecked = false;

            txtNumber.Text = manager.GetPrivateString("main", "number");
            txtNumber.Text = manager.GetPrivateString("main", "number");

            /*if (manager.GetPrivateString("main", "topmost") == "True")
                chTopMost.IsChecked = true;
            else
                chTopMost.Checked = false;*/

            txtSave.Text = manager.GetPrivateString("main", "save");
            dataTime1.Text = manager.GetPrivateString("main", "data");

            timeWork = manager.GetPrivateString("main", "data").ToString();


        }

        // Запись всех настроек 
        public void saveAllData()
        {
            string basePath = System.IO.Path.Combine(appPath);
            INIManager.Class1.INIManager manager = new Class1.INIManager(basePath + @"/my.ini");
            manager.WritePrivateString("main", "basePath", txtPath.Text.Trim());
            manager.WritePrivateString("main", "basePath2", txtPath2.Text.Trim());
            manager.WritePrivateString("main", "server", txtServer.Text.Trim());
            manager.WritePrivateString("main", "port", txtPort.Text.Trim());
            manager.WritePrivateString("main", "login", txtLogin.Text.Trim());
            manager.WritePrivateString("main", "passw", txtPassword.Password.Trim());
            manager.WritePrivateString("main", "viewAll", chAll.IsChecked.ToString());
            manager.WritePrivateString("main", "number", txtNumber.Text.Trim());
            //manager.WritePrivateString("main", "topmost", chTopMost.Checked.ToString());
            manager.WritePrivateString("main", "save", txtSave.Text.Trim());
            manager.WritePrivateString("main", "data", dataTime1.Text.ToString());

        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void mainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            getDataFromIni();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            saveAllData();
        }
    }
}
