using proj.Commands;
using proj.Models.Entities;
using proj.Repositories;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace proj.ViewModels
{
    public class MainWindowViewModel : PropertyChangedBase
    {
        private readonly UserRepository _userRepository;

        private User _selectedUser;
        public User SelectedUser
        {
            get => _selectedUser;
            set { _selectedUser = value; OnPropertyChanged(); }
        }

        public ObservableCollection<User> Users { get; set; }

        public MyCommand AddCommand { get; }
        public MyCommand UpdateCommand { get; }
        public MyCommand DeleteCommand { get; }

        public MainWindowViewModel()
        {
            _userRepository = new();

            Users = new ObservableCollection<User>(_userRepository.GetAll());

            Users.CollectionChanged += Users_CollectionChanged;

            AddCommand = new MyCommand(_ => AddUser());
            UpdateCommand = new MyCommand(_ => UpdateUser(), _ => SelectedUser != null);
            DeleteCommand = new MyCommand(_ => DeleteUser(), _ => SelectedUser != null);
        }

        private void Users_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (User user in e.NewItems)
                    _userRepository.Add(user);
            }
        }

        private UserRepository Get_userRepository()
        {
            return _userRepository;
        }

        private void AddUser()
        {
            var newUser = new User();
            var editWindow = new EditUserWindow(newUser);

            if (editWindow.ShowDialog() == true)
            {
                _userRepository.Add(newUser);

                Users.Add(newUser);
            }
        }

        private void UpdateUser()
        {
            if (SelectedUser == null) return;

            var clone = SelectedUser.Clone();

            var window = new EditUserWindow(clone);

            if (window.ShowDialog() == true)
            {
                SelectedUser.FirstName = clone.FirstName;
                SelectedUser.LastName = clone.LastName;
                SelectedUser.PasswordHash = clone.PasswordHash;
                SelectedUser.Email = clone.Email;
                SelectedUser.Phone = clone.Phone;
                SelectedUser.IsActive = clone.IsActive;

                _userRepository.Update(SelectedUser.UserId, SelectedUser);
            }
        }

        private void DeleteUser()
        {
            if (SelectedUser == null) return;

            _userRepository.Delete(SelectedUser.UserId);
            Users.Remove(SelectedUser);
        }
    }
}