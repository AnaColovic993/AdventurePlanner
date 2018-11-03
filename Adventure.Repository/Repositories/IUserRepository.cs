using Adventure.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adventure.Repository.Repositories
{
    public interface IUserRepository
    {
        void Create(User user);
        User GetOne(User user);
        //TODO:
        //void Update(User user);
        //void Delete(User user);
    }
}
