using Capstone.DAO.Interfaces;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class ClassScheduleDAO : IClassScheduleDAO
    {

        private readonly string connectionString;

        public ClassScheduleDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;

        }
        public List<ClassSchedule> GetListOfClasses()
        {
            List<ClassSchedule> returnClasses = new List<ClassSchedule>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM class_schedule", conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ClassSchedule classSchedule = new ClassSchedule();

                        classSchedule.ClassId = Convert.ToInt32(reader["class_id"]);
                        classSchedule.ClassName = Convert.ToString(reader["class_name"]);
                        classSchedule.ClassDescription = Convert.ToString(reader["class_description"]);
                        classSchedule.Day = Convert.ToString(reader["day_of_week"]);
                        classSchedule.Time = Convert.ToString(reader["class_time"]);

                        returnClasses.Add(classSchedule);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return returnClasses;
        }
    }
}
