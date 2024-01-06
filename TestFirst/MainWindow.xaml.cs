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
using System.Windows.Media.Animation;

namespace TestFirst
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        test4Entities db;
        public MainWindow()
        {
            InitializeComponent();
            db = new test4Entities();

            DoubleAnimation btnAnimation = new DoubleAnimation();
            btnAnimation.From = 0;
            btnAnimation.To = 450;
            btnAnimation.Duration = TimeSpan.FromSeconds(3);
            regButton.BeginAnimation(Button.WidthProperty, btnAnimation);

        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {

            string login = TextBoxLogin.Text.Trim();
            string pass = TextBoxPassword.Password.Trim();
            string pass2 = TextBoxPasswordRepeat.Password.Trim();
            string email = TextBoxEmail.Text.Trim().ToLower();
            if (login.Length < 5)
            {
                TextBoxLogin.ToolTip = "Вы ввели менее 5 символов";
                TextBoxLogin.Background = Brushes.Red;
            }
            else if (pass.Length < 5) {
                TextBoxPassword.ToolTip = "Вы ввели менее 5 символов";
                TextBoxPassword.Background = Brushes.Red;
            }
            else if (pass != pass2)
            {
                TextBoxPasswordRepeat.ToolTip = "Пароли не совпадают";
                TextBoxPasswordRepeat.Background = Brushes.Red;
            }
            else if (pass.Length < 5 || !email.Contains("@") || !email.Contains("."))
            {
                TextBoxEmail.ToolTip = "Ошибка";
                TextBoxEmail.Background = Brushes.Red;
            }
            else {
                TextBoxLogin.ToolTip = "";
                TextBoxLogin.Background = Brushes.Transparent;

                TextBoxPassword.ToolTip = "";
                TextBoxPassword.Background = Brushes.Transparent;

                TextBoxPasswordRepeat.ToolTip = "";
                TextBoxPasswordRepeat.Background = Brushes.Transparent;

                TextBoxEmail.ToolTip = "";
                TextBoxEmail.Background = Brushes.Transparent;
                MessageBox.Show("Все хорошо");

                Users user = new Users(login, pass, email);

                db.Users.Add(user);
                db.SaveChanges();

                Auth authWindow = new Auth();
                authWindow.Show();
                this.Hide();
            }
        }

        private void Button_Window_Click(object sender, RoutedEventArgs e)
        {
            Auth authWindow = new Auth();
            authWindow.Show();
            this.Hide();
        }
    }
}
