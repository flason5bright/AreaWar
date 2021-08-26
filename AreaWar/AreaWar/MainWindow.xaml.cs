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

namespace AreaWar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowViewModel vm = new MainWindowViewModel();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = vm;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.btn.Content.ToString() == "Start")
            {
                this.btn.Content = "Stop";
                vm.Start();
            }
            else
            {
                this.btn.Content = "Start";
                vm.Stop();
            }
           
        }
    }
}
