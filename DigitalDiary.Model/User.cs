using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalDiary.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public List<Human> Humans { get; set; }

        public void UpdateEnty(User user)
        {
            if (user != null) {

                Password= user.Password;
                Email= user.Email;            
            }
        }

    }
}
