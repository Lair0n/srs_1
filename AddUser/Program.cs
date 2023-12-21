using HashPasswords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Tur_Agentstvo;
using Tur_Agentstvo.Models;


namespace AddUser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //try
            //{
                var db = Helper.getContext();
                Avtorizacia avtorizacia = new Avtorizacia();
                Sotrudnik sotrudnik = new Sotrudnik();

                Console.WriteLine("Введите вашу фамилию: ");
                string familia = Console.ReadLine();
                sotrudnik.Familia = familia;
                Console.WriteLine("Введите ваше имя: ");
                string imya = Console.ReadLine();
                sotrudnik.Imya = imya;
                Console.WriteLine("Введите ваше отчество(при наличии): ");
                string otchestvo = Console.ReadLine();
                sotrudnik.Otchestvo = otchestvo;
                Console.WriteLine("Введите ваш номер телефона: ");
                string nomer = Console.ReadLine();
                sotrudnik.Contactniy_telephone = nomer;
                Console.WriteLine("Выберите вашу должность(1 - Администратор. 2 - Турагент. 3 - Менеджер по продажам): ");
                int job = Convert.ToInt32(Console.ReadLine());
                sotrudnik.ID_Doljnost = job;

                sotrudnik.ID_Avtorizacii = avtorizacia.ID_Avtorizacii;

                Console.WriteLine("Введите ваш Login: ");
                string login = Console.ReadLine();
                avtorizacia.Login = login;
                Console.WriteLine("Введите Password: ");
                string password = Console.ReadLine();
                string hasgPasswords = Class1.HashPassword(password);
                avtorizacia.Password = hasgPasswords;
                Console.WriteLine($"Хэшированный пароль: {hasgPasswords}");

                db.Avtorizacia.Add(avtorizacia);
                db.Sotrudnik.Add(sotrudnik);
                db.SaveChanges();

                Console.ReadKey();
           // }
            /*catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }*/
        }
    }
}
