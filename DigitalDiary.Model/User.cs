using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DigitalDiary.Model
{
    public enum TypeUser
    {
        Student,
        Teacher,
        Parent
    }
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public TypeUser TypeUser { get; set; }
        public List<Human> Humans { get; set; }

        public static bool operator true (User user)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (user.Login == "")
                throw new Exception("Не верный логин");
            if (user.Password == "")
                throw new Exception("Пустой пароль");
            if (user.Password.Length <= 6)
                throw new Exception("Слишком короткий пароль");
            if (!regex.IsMatch(user.Email))
                throw new Exception("Не верный E-mail");

            return true;
        }
        public static bool operator false(User user)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            return !(user.Login != "" && user.Password != "" && user.Password.Length > 6 && regex.IsMatch(user.Email));
        }

        public void UpdateEnty(User user)
        {
            if (user != null) {

                Password= user.Password;
                Email= user.Email;            
            }
        }

    }
}
