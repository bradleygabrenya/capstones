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
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentDAO equipmentDAO;

        public EquipmentController(IEquipmentDAO _equipmentDAO)
        {
            equipmentDAO = _equipmentDAO;
        }

        [HttpGet("/equipment")]
        public List<Equipment> GetEquipmentList()
        {
            List<Equipment> equipmentDetails = equipmentDAO.GetEquipmentDetails();
            return equipmentDetails;
        }

    }
}
