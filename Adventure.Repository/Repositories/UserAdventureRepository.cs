using Adventure.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adventure.Repository.Repositories
{
    public class UserAdventureRepository:IUserAdventureRepository
    {
        private readonly AdventureDbContext _adventureDbContext;

        public UserAdventureRepository(AdventureDbContext adventureDbContext)
        {
            this._adventureDbContext = adventureDbContext;
        }

        //Returns all if UserId is not specified, returns for User if we have condition UserId
        public IEnumerable<UserAdventure> GetAll(params string[] conditions)
        {
            if (conditions == null)
            {
                return _adventureDbContext.UserAdventure.AsEnumerable();
            }
            else
            {
                return _adventureDbContext.UserAdventure.Where(p => p.UserId == Convert.ToInt32(conditions[0])).AsEnumerable();
            }
        }

        public void Create(UserAdventure userAdventure)
        {

        }

        public void Update(UserAdventure userAdventure)
        {

        }

        public void Delete(UserAdventure userAdventure)
        {

        }

    }
}
