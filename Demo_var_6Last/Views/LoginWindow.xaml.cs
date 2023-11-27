using Demo_var_6Last.DataB;
using Demo_var_6Last.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Demo_var_6Last.Views
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        UserDB userDB = new UserDB();
        public LoginWindow()
        {
            InitializeComponent();
        }
        private void SignInBtn_Click(object sender, RoutedEventArgs e)
        {
            string passText = passTbx.Text;
            string loginText = loginTbx.Text;            
            if(passText==null || loginText==null)
            {
                MessageBox.Show("Вы ввели не все данные");
                return;
            }

            User user1 = userDB.GetUsers().FirstOrDefault(item => item.Login == loginText);

            if (user1 == null)
            {
                MessageBox.Show("Такого пользователя нет");
                return;
            }
            if (user1.Password != passText)
            {
                MessageBox.Show("Вы ввели неверный пароль");
                return;
            }            
            MessageBox.Show($"Вы вошли как {user1.Lfp}");
            SignIn(user1);            
        }
        public void SignIn(User user)
        {
            ContentWindow contentWindow = new ContentWindow(user);
            contentWindow.Show();
            this.Close();
        }
    }
}
