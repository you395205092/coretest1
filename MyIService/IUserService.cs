using MyDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyIService
{
    public interface IUserService:IServiceTag
    {
        void AddNew(string username, string password);
        UserDTO GetUserName(string username);
        bool CheckLogin(string username, string password);
    }
}
