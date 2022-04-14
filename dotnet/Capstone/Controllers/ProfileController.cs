using Capstone.DAO.Interfaces;
using Capstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {

        private readonly IUserDao userDAO;

        public ProfileController(IUserDao _userDAO)
        {
            userDAO = _userDAO;
        }


        [HttpPut("/profile/admin")]
        //[Authorize (Roles = "admin")]
        public void PutUserRole(User user)
        {
            userDAO.UpdateUserRole(user);       
        }
    }
}
