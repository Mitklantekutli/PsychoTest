using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tester.Annotations;

namespace Tester.ViewModel
{
    public class AnswersVM : INotifyPropertyChanged
    {
        private readonly ITest _test;
        public List<Answer> Answers { get; set; }

        public AnswersVM(ITest test)
        {
            _test = test;
            var index = 1;
            Answers = test.Answers.Select(x => new Answer {Id = index++, Text = x}).ToList();
        }

        #region INPC

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        public bool Save()
        {
            Answers.ForEach(x=>_test.Answers[x.Id-1]=x.Text);
            try
            {
                _test.Calculate();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Одно из значений выходит за диапазон: " + _test.Story);
                return false;
            }
        }
    }

    public class Answer : INotifyPropertyChanged
    {
        private int _text;
        public int Id { get; set; }

        public int Text
        {
            get { return _text; }
            set
            {
                if (value == _text) return;
                _text = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
