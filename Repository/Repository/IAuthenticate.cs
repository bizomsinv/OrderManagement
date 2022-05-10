using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public interface IAuthenticate
    {
        string Auth(string userName, string password);
        Task<User> AddUser(User user);
        string EncodePasswordToBase64(string password);
        string DecodeFrom64(string encodedData);
    }
}
