﻿using Microsoft.AspNetCore.Mvc;
using Vinodrill_Back.Models.EntityFramework;

namespace Vinodrill_Back.Models.Repository
{
    public interface IUserRepository : IDataRepository<User>
    {
        User GetAuthUser(User user);
        Task<ActionResult<User>> FindByEmail(string email);
    }
}
