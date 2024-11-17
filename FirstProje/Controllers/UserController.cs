using FirstProje.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstProje.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController : ControllerBase
    {
        private static List<UserModel> _users = new List<UserModel>()
        {
            new UserModel{UserId = 1, Username= "Eren",UserUnvan  = ".Net Developer"},
            new UserModel{UserId = 2, Username= "Efe",UserUnvan   = "Php Developer"},
            new UserModel{UserId = 3, Username= "Kasım",UserUnvan = "JavaScript Developer"},
        };




        [HttpGet("List")]

        public IActionResult UserList()
        {
            return Ok(_users);
        }
        [HttpGet("GetByIdUser/{id}")]
        public IActionResult GetByIdUsers(int id)
        {
            var user = _users.FirstOrDefault(p => p.UserId == id);
            if (user == null)
            {
                return NotFound(new { Message = id + " 'sine Kullanıcı Bulunamadı" });
            }

            return Ok(user);
        }

        [HttpPost]
        public IActionResult UserAdd(UserModel newUser)
        {
            newUser.UserId = _users.Max(x => x.UserId) +1;
            _users.Add(newUser);
            return Ok(newUser);
        }
        [HttpPut("UserUpdate/{id}")]
        public IActionResult UpdateUser(int id, UserModel newUser)
        {
            var user = _users.FirstOrDefault(p=>p.UserId == id);
            if (user == null)
            {
                return NotFound(new { Message = "Kullanıcı bulunamadı" });
            }
            user.UserName = newUser.UserName;
            user.UserUnvan = newUser.UserUnvan;

            return Ok(_users);
        }

        [HttpDelete("UserDelete/{id}")]
        public IActionResult UserDelete(int id)
        {
            var user = _users.FirstOrDefault(p => p.UserId == id);
            if (user == null)
            {
                return NotFound(new { Message = "Kullanıcı Bulunamadı" });
            }
            _users.Remove(user);
            return Ok(_users);

        }





    }
}
