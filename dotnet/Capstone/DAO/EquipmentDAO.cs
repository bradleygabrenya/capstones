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
        private string getEquipmentMetrics = "SELECT SUM(ut.reps) [total_equipment_reps], sum(DATEDIFF(SECOND,ut.use_start,ut.use_stop)) [total_use_seconds],  e.equipment_name FROM use_tracking ut JOIN equipment e ON ut.equipment_id = e.equipment_id WHERE ut.use_start >= DATEADD(DAY,-30,GETDATE()) GROUP BY e.equipment_name";

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

        public List<EquipmentMetrics> GetEquipmentMetrics()
        {
            List<EquipmentMetrics> equipmentMetrics = new List<EquipmentMetrics>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(getEquipmentMetrics, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        EquipmentMetrics equipment = new EquipmentMetrics();

                        equipment.TotalEquipmentReps = Convert.ToInt32(reader["total_equipment_reps"]);
                        equipment.TotalUseSeconds = Convert.ToInt32(reader["total_use_seconds"]);
                        equipment.EquipmentName = Convert.ToString(reader["equipment_name"]);

                        equipmentMetrics.Add(equipment);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return equipmentMetrics;
        }
    }
}

