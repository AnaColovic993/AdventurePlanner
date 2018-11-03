using Adventure.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adventure.Repository.Repositories
{
    public interface IUserAdventureRepository 
    {
        IEnumerable<UserAdventure> GetAll(params string[] conditions);
        void Create(UserAdventure userAdventure);
        void Update(UserAdventure userAdventure);
        void Delete(UserAdventure userAdventure);
    }
}
