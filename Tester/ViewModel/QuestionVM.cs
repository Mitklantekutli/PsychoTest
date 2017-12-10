using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Tester.Annotations;

namespace Tester
{
    class QuestionVM : INotifyPropertyChanged
    {
        private readonly ITest _test;
        public ITest Test => _test;
        private string _answer;
        private string _info;
        private string _story;

        public string Answer
        {
            get { return _answer; }
            set
            {
                if (value == _answer) return;
                _answer = value;
                OnPropertyChanged();
            }
        }

        public string Info
        {
            get { return _info; }
            set { _info = value; }
        }

        public string Story
        {
            get { return _story; }
            set { _story = value; }
        }

        public QuestionVM(ITest test)
        {
            _test = test;
        }
        public QuestionVM()
        {
        }

        #region INPC

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        #endregion
    }
}
