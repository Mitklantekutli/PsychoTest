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
using System.Windows.Shapes;
using Tester.ViewModel;

namespace Tester.View
{
    /// <summary>
    /// Interaction logic for AnswersWindow.xaml
    /// </summary>
    public partial class AnswersWindow : Window
    {
        public AnswersWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as AnswersVM;
            if (vm.Save())
                this.Close();
        }
    }
}
