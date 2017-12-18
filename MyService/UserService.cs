using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyDTO;
using MyIService;
using MyCommon;


namespace MyService
{
    class UserService : IUserService
    {
        public void AddNew(string username, string password)
        {
            using (MyDbContent ctx = new MyDbContent())
            {
                if (ctx.Users.Any(u=>u.UserName==username))
                {
                    throw new ApplicationException("账号已存在");
                }
                User user = new User();
                user.UserName = username;
                user.UserPass = MD5Helper.Md5(password);
                user.IsDeleted = false;
                ctx.Add(user);
                ctx.SaveChanges();
            }
        }

        public bool CheckLogin(string username, string password)
        {
            using (MyDbContent ctx=new MyDbContent())
            {
                User user = ctx.Users.SingleOrDefault(u => u.UserName == username);
                if (user==null)
                {
                    return false;
                }
                return user.UserPass == MD5Helper.Md5(password);
            }
        }

        public UserDTO GetUserName(string username)
        {
            using (MyDbContent ctx=new MyDbContent())
            {
                User user = ctx.Users.SingleOrDefault(u => u.UserName == username);
                if (user ==null)
                {
                    return null;
                }
                return ToDTO(user);
            }
        }

        public UserDTO ToDTO(User user)
        {
            UserDTO dto = new UserDTO();
            dto.Id = user.Id;
            dto.UserName = user.UserName;
            dto.UserPass = user.UserPass;
            return dto;
        }
    }
}
