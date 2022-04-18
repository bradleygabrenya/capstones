using Capstone.DAO.Interfaces;
using Capstone.Models;
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
    public class ClassScheduleController : ControllerBase
    {

        private readonly IClassScheduleDAO classScheduleDAO;

        public ClassScheduleController(IClassScheduleDAO _classScheduleDAO)
        {
            classScheduleDAO = _classScheduleDAO;
        }

        [HttpGet("/classes")]
        public List<ClassSchedule> GetClasses()
        {
            List<ClassSchedule> classes = classScheduleDAO.GetListOfClasses();
            return classes;
        }
    }
}
