using proj.Models.Entities;
using proj.Repositories;
using proj.Commands;
using System.Windows;

namespace proj.ViewModels
{
    public class RegisterViewModel : PropertyChangedBase
    {
        private readonly UserRepository _userRepository;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }

        public MyCommand RegisterCommand { get; }

        public RegisterViewModel()
        {
            _userRepository = new UserRepository();
            RegisterCommand = new MyCommand(_ => Register());
        }

        private void Register()
        {
            User user = new User
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                PasswordHash = Password,
                Phone = Phone,
                RegistrationDate = DateTime.Now,
                IsActive = true
            };

            _userRepository.Add(user);
            MessageBox.Show("Вы успешно зарегистрировались!");
            Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive)?.Close();
        }
    }
}
