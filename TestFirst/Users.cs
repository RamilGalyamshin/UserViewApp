namespace TestFirst
{
    using System;
    using System.Collections.Generic;
    
    public partial class Users
    {
        public string pass;
        public Users()
        {
            // Конструктор без параметров
        }
        public Users(string login, string pass, string email)
        {
            this.login = login;
            this.password = pass;
            this.email = email;
        }

        public override string ToString()
        {
            return "Пользователь: " + login + "Email: " + email;
        }

        public int id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string email { get; set; }
    }
}
