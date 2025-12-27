using proj.Commands;
using proj.Models.Entities;
using proj.Repositories;
using proj.Services;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace proj.ViewModels
{
    public class LoginViewModel : PropertyChangedBase
    {
        public string Email { get; set; }
        public string Password { get; set; }

        private readonly UserRepository _userRepository = new();

        public ICommand LoginCommand => new MyCommand(Login);
        public ICommand OpenRegisterCommand => new MyCommand(OpenRegister);

        private void Login(object obj)
        {
            var user = _userRepository
                .GetAll()
                .FirstOrDefault(u => u.Email == Email && u.PasswordHash == Password);

            if (user == null)
            {
                MessageBox.Show("Неверный email или пароль!");
                return;
            }

            Session.CurrentUser = user;

            if (Session.HasRole("Administrator"))
            {
                MessageBox.Show($"Добро пожаловать, Администратор {user.FirstName}!");
            }
            else if (Session.HasRole("Worker"))
            {
                MessageBox.Show($"Добро пожаловать, Работник {user.FirstName}!");
            }
            else
            {
                MessageBox.Show($"Добро пожаловать, {user.FirstName}!");
            }

            var menu = new Menu();
            menu.Show();

            Application.Current.Windows
                .OfType<Window>()
                .FirstOrDefault(w => w.DataContext == this)?
                .Close();
        }

        private void OpenRegister(object obj)
        {
            var registerWindow = new RegisterWindow();
            registerWindow.ShowDialog();
        }
    }
}
