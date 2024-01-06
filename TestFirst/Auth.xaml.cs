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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TestFirst
{
    /// <summary>
    /// Interaction logic for Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {

        public Auth()
        {
            InitializeComponent();
            DoubleAnimation btnAnimation = new DoubleAnimation();
            btnAnimation.From = 0;
            btnAnimation.To = 450;
            btnAnimation.Duration = TimeSpan.FromSeconds(3);
            AuthButton.BeginAnimation(Button.WidthProperty, btnAnimation);
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            string login = TextBoxLogin.Text.Trim();
            string pass = TextBoxPassword.Password.Trim();
            if (login.Length < 5)
            {
                TextBoxLogin.ToolTip = "Вы ввели менее 5 символов";
                TextBoxLogin.Background = Brushes.Red;
            }
            else if (pass.Length < 5)
            {
                TextBoxPassword.ToolTip = "Вы ввели менее 5 символов";
                TextBoxPassword.Background = Brushes.Red;
            }else
            {
                TextBoxLogin.ToolTip = "";
                TextBoxLogin.Background = Brushes.Transparent;

                TextBoxPassword.ToolTip = "";
                TextBoxPassword.Background = Brushes.Transparent;

                Users authUser = null;
                using (test4Entities db = new test4Entities())
                {
                    authUser = db.Users.Where(b => b.login == login && b.password == pass).FirstOrDefault();
                }

                if (authUser != null)
                {
                    MessageBox.Show("Все хорошо");
                    UserPageWindow userPageWindow= new UserPageWindow();
                    userPageWindow.Show();
                    Hide();
                }
                else

                    MessageBox.Show("Вы ввели что то некорректоное");

            }
           
        }

        private void Button_Window_Main_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }
    }
}
