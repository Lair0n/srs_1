using HashPasswords;
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
using Tur_Agentstvo.Models;

namespace Tur_Agentstvo.Pages
{
    /// <summary>
    /// Логика взаимодействия для Autho.xaml
    /// </summary>
    public partial class Autho : Page
    {
        public Autho()
        {
            InitializeComponent();
        }
        private int cap = 0;

        private void btnEnterGuests_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new client(null));
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            string login = txtbLogin.Text.Trim();
            string password = pswbPassword.Password.Trim();
            string Hash = Class1.HashPassword(password);
            var doljnosti = Helper.getContext().Sotrudnik.Where(d => d.ID_Doljnost == 2).FirstOrDefault();

            Models.Sotrudnik sotrudniki = new Models.Sotrudnik();

            if (login.Length > 0 && password.Length > 0)
            {
                if (cap < 1)
                {
                    var job = Helper.getContext().Sotrudnik;
                    var user = Helper.getContext().Avtorizacia.Where(u => u.Login == login && u.Password == Hash).FirstOrDefault();
                    if (user != null)
                    {
                        var id = Helper.getContext().Sotrudnik.Where(id1 => id1.ID_Avtorizacii == user.ID_Avtorizacii).FirstOrDefault();
                        var asd = id.Doljnost;
                        if (asd.Doljnost1 == "Администратор")
                        {
                            NavigationService.Navigate(new Admin());
                        }
                        else if (asd.Doljnost1 == "Менеджер по продажам")
                        {
                            NavigationService.Navigate(new Manager());
                        }

                    }
                    else
                    {
                        MessageBox.Show("Такой пользователь не найден!");
                        cap++;
                        txtBlockCaptcha.Text = GenerateRandomCaptcha(4);
                    }
                }
                else
                {
                    var user = Helper.getContext().Avtorizacia.Where(u => u.Login == login && u.Password == password).FirstOrDefault();
                    string captcha = txtboxCaptcha.Text;
                    if (captcha == txtBlockCaptcha.Text)
                    {
                        TextLogin.Text = "Логин:";
                        TextPassword.Text = "Пароль:";
                        txtBlockCaptcha.Visibility = Visibility.Collapsed;
                        txtboxCaptcha.Visibility = Visibility.Collapsed;
                        txtbLogin.Visibility = Visibility.Visible;
                        pswbPassword.Visibility = Visibility.Visible;
                        txtBlockCaptcha.TextDecorations = null;
                        txtBlockCaptcha.FontStyle = FontStyles.Normal;
                        txtbLogin.Clear();
                        pswbPassword.Clear();
                        txtboxCaptcha.Clear();
                        cap--;
                        MessageBox.Show("Капча введена верно, попробуйте авторизироваться еще раз");

                    }
                    else
                    {
                        MessageBox.Show("Капча введена неверно");
                        txtboxCaptcha.Text = "";
                        txtBlockCaptcha.Text = GenerateRandomCaptcha(4);
                    }
                }

            }
            else
            {
                MessageBox.Show("Не все поля заполнены! Заполните поля логина и пароля!");
            }
        }
        private string GenerateRandomCaptcha(int length)
        {
            TextLogin.Text = "";
            TextPassword.Text = "Введи зачёркнутый текст";
            txtbLogin.Visibility = Visibility.Collapsed;
            pswbPassword.Visibility = Visibility.Collapsed;
            txtboxCaptcha.Visibility = Visibility.Visible;
            txtBlockCaptcha.Visibility = Visibility.Visible;

            txtBlockCaptcha.TextDecorations = TextDecorations.Strikethrough;

            txtBlockCaptcha.FontStyle = FontStyles.Italic;

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
