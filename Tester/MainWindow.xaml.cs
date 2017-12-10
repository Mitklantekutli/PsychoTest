using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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
using Tester.Model;
using Tester.View;
using Tester.ViewModel;

namespace Tester
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowVM _vm;
        private PersonManager _m;
        public MainWindow()
        {
            InitializeComponent();
            var f = new FailrueTest();
            f.Calculate();
            
            _m = new PersonManager();
            _vm = new MainWindowVM(_m);

            DataContext = _vm;
        }

        #region Grid

        private void DataGrid_OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            var displayName = GetPropertyDisplayName(e.PropertyDescriptor);

            if (!string.IsNullOrEmpty(displayName))
            {
                e.Column.Header = displayName;
            }

        }

        public static string GetPropertyDisplayName(object descriptor)
        {
            var pd = descriptor as PropertyDescriptor;

            if (pd != null)
            {
                // Check for DisplayName attribute and set the column header accordingly
                var displayName = pd.Attributes[typeof(DisplayNameAttribute)] as DisplayNameAttribute;

                if (displayName != null && displayName != DisplayNameAttribute.Default)
                {
                    return displayName.DisplayName;
                }

            }
            else
            {
                var pi = descriptor as PropertyInfo;

                if (pi != null)
                {
                    // Check for DisplayName attribute and set the column header accordingly
                    Object[] attributes = pi.GetCustomAttributes(typeof(DisplayNameAttribute), true);
                    for (int i = 0; i < attributes.Length; ++i)
                    {
                        var displayName = attributes[i] as DisplayNameAttribute;
                        if (displayName != null && displayName != DisplayNameAttribute.Default)
                        {
                            return displayName.DisplayName;
                        }
                    }
                }
            }

            return null;
        }

        private void RefreshDataGrid()
        {
            var s = Data.SelectedItem;
            Data.ItemsSource = null;
            Data.ItemsSource = _vm.Persons;
            Data.SelectedItem = s;
        }

        #endregion

        #region Опросники


        //Тревожность
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var p = _vm.SelectedPerson;
            FillAnswers(p.Anxiety);
        }

        //Избегание неудач
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var p = _vm.SelectedPerson;
            FillAnswers(p.Failrue);
        }

        //Личностная адаптивность
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            var p = _vm.SelectedPerson;
            FillAnswers(p.Personal);
        }

        //Мотивация
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            var p = _vm.SelectedPerson;
            FillAnswers(p.Motivation);
        }

        //Кеттел
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            var p = _vm.SelectedPerson;
            FillAnswers(p.Kettel);
        }

        //Самооценка страха
        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            var p = _vm.SelectedPerson;
            FillAnswers(p.Self);
        }

        private void FillAnswers(ITest test)
        {
            var r = new Random();
            test.Answers.Clear();
            for (int i = 0; i < test.QuestionsNumber; i++)
            {
                var m = new QuestionVM(test);
                m.Story = test.Story;
                m.Info = "Вопрос #" + (i + 1) ;
                var w = new Question();
                w.DataContext = m;
                w.ShowDialog();
                //m.Answer = r.Next(1,3) + "";
                test.Answers.Add(int.Parse(m.Answer));
            }

            Update(test);   
        }

        #endregion

        #region Редактировать

        // Тревожность
        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            EditAnswers(_vm.SelectedPerson.Anxiety);
        }

        //Избегание неудач
        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            EditAnswers(_vm.SelectedPerson.Failrue);
        }

        // Мотивация
        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            EditAnswers(_vm.SelectedPerson.Motivation);
        }

        // Кеттел
        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            EditAnswers(_vm.SelectedPerson.Kettel);
        }

        // Адаптация
        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            EditAnswers(_vm.SelectedPerson.Personal);
        }

        // Оценка страха
        private void Button_Click_14(object sender, RoutedEventArgs e)
        {
            EditAnswers(_vm.SelectedPerson.Self);
        }

        private void EditAnswers(ITest test)
        {
            var vm = new AnswersVM(test);
            var w = new AnswersWindow();
            w.DataContext = vm;
            w.ShowDialog();
            
            Update(test);
        }

        #endregion

        private void Update(ITest test)
        {
            test.Calculate();
            _vm.OnPropertyChanged(nameof(MainWindowVM.SelectedPerson));
            RefreshDataGrid();
            _m.Save(_vm.Persons.ToList());
            MessageBox.Show("Данные сохранены");
        }

        #region Создать/удалить/сохранить

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var p = new PersonInfo();
            var m = new QuestionVM();
            m.Info = "Введите имя:";
            var w = new Question(false);
            w.DataContext = m;
            w.ShowDialog();
            p.Name = m.Answer;
            _vm.Persons.Add(p);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (_vm.SelectedPerson == null)
                return;

            var r = MessageBox.Show($"Удалить {_vm.SelectedPerson.Name}?", "", MessageBoxButton.YesNo);
            if (r != MessageBoxResult.Yes)
                return;

            _vm.Persons.Remove(_vm.SelectedPerson);
            _vm.SelectedPerson = null;
            _m.Save(_vm.Persons.ToList());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            _m.Save(_vm.Persons.ToList());
            MessageBox.Show("Данные сохранены");
        }







        #endregion

    }
}
