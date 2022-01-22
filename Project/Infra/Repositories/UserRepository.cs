using Business.Interfaces.Repositories;
using Business.IO.Users;
using Domain.Entity;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class UserRepository : RepositoryBase<Context.CodeContext, UserEntity>, IUserRepository
    {
        public UserRepository(Context.CodeContext context) : base(context)
        {

        }

        public async Task<UserAuthView> Get(string username, string password)
        {
            //var query =  DbSet as IQueryable<UserEntity>;
            //return await query.Where(x => x.Nome.ToLower() == username.ToLower() && x.Senha == password).FirstOrDefaultAsync();
            return await Task.Run(() => new UserAuthView { Nome = "sup", Senha = "sup", Role = "manager" });

        }
    }
}
