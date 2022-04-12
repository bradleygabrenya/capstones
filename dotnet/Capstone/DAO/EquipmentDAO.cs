using Capstone.DAO.Interfaces;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class EquipmentDAO : IEquipmentDAO
    {
        private string getEquipmentDetails = "SELECT * FROM equipment;";

        private readonly string connectionString;

        public EquipmentDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;

        }

        public List<Equipment> GetEquipmentDetails()
        {
            List<Equipment> equipmentDetails = new List<Equipment>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(getEquipmentDetails, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Equipment equipment = new Equipment();

                        equipment.EquipmentId = Convert.ToInt32(reader["equipment_id"]);
                        equipment.Name = Convert.ToString(reader["equipment_name"]);
                        equipment.Details = Convert.ToString(reader["description"]);
                        equipmentDetails.Add(equipment);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return equipmentDetails;
        }
    }
}
