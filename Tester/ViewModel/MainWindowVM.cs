using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using Tester.Annotations;

namespace Tester.ViewModel
{
    class MainWindowVM : INotifyPropertyChanged
    {
        private PersonInfo _selectedPerson;
        private ObservableCollection<PersonInfo> _persons;

        public ObservableCollection<PersonInfo> Persons
        {
            get { return _persons; }
            set
            {
                if (Equals(value, _persons)) return;
                _persons = value;
                OnPropertyChanged();
            }
        }

        public PersonInfo SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                if (Equals(value, _selectedPerson)) return;
                _selectedPerson = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(PersonInfoVisibility));
            }
        }

        public Visibility PersonInfoVisibility => SelectedPerson != null ? Visibility.Visible : Visibility.Collapsed;
        public MainWindowVM(PersonManager m)
        {
            Persons = new ObservableCollection<PersonInfo>();
            m.Load().ForEach(Persons.Add);
        }

        #region INPC

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        #endregion
    }
}
