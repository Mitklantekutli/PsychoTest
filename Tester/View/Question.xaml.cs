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

namespace Tester
{
    /// <summary>
    /// Interaction logic for Question.xaml
    /// </summary>
    public partial class Question : Window
    {
        private bool _closeOnNumber;
        QuestionVM _vm;
        public Question(bool closeOnNumber = true)
        {
            InitializeComponent();
            Loaded += (sender, e) =>
                MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            _closeOnNumber = closeOnNumber;
            
        }

        private void TextBoxBase_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            
            if (_closeOnNumber)
            {
                this.Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
