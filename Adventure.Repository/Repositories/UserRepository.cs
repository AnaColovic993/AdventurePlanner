using Adventure.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adventure.Repository.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly AdventureDbContext _adventureDbContext;

        public UserRepository(AdventureDbContext adventureDbContext)
        {
            this._adventureDbContext = adventureDbContext;
        }
        public void Create(User user)
        {
            _adventureDbContext.Add(user);
            _adventureDbContext.SaveChanges();
        }

        public User GetOne(User user)
        {
            //TODO: LOGIN
            
            return user;
        }
    }
}
