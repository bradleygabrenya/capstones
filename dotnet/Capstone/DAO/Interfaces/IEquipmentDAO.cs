﻿using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO.Interfaces
{
    public interface IEquipmentDAO
    {
        public List<Equipment> GetEquipmentDetails();
        public List<EquipmentMetrics> GetEquipmentMetrics();
    }
}
