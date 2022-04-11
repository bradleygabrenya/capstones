using Capstone.DAO.Interfaces;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class WorkoutDAO : IWorkoutDAO
    {
        private string getDetails = "SELECT * FROM use_tracking WHERE user_id = @user_id AND workout_id = @workout_id";
        private string getWorkouts = "SELECT * FROM daily_workout WHERE user_id = @user_id";
        private readonly string connectionString;

        public WorkoutDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;

        }

        public List<DailyWorkout> GetDailyWorkouts(int userId)
        {
            List<DailyWorkout> dailyWorkouts = new List<DailyWorkout>();

            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(getWorkouts, conn);
                    cmd.Parameters.AddWithValue("@user_id", userId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while(reader.Read())
                    {
                        DailyWorkout dailyWorkout = new DailyWorkout();

                        dailyWorkout.UserId = Convert.ToInt32(reader["user_id"]);
                        dailyWorkout.WorkoutId = Convert.ToInt32(reader["workout_id"]);
                        dailyWorkout.CheckIn = Convert.ToDateTime(reader["check_in"]);
                        dailyWorkout.CheckOut = Convert.ToDateTime(reader["check_out"]);
                        dailyWorkouts.Add(dailyWorkout);
                    }
                }
            }
            catch(SqlException ex)
            {

            }
            return dailyWorkouts;
        }
        public List<UseTracking> GetWorkoutDetails(int userId, int workoutId)
        {
            List<UseTracking> returnUseTracking = new List<UseTracking>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(getDetails, conn);
                    cmd.Parameters.AddWithValue("@user_id", userId);
                    cmd.Parameters.AddWithValue("@workout_id", workoutId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        UseTracking useTracking = new UseTracking();
                        useTracking.TrackingId = Convert.ToInt32(reader["tracking_id"]);
                        useTracking.UserId = Convert.ToInt32(reader["user_id"]);
                        useTracking.WorkoutId = Convert.ToInt32(reader["workout_id"]);
                        useTracking.EquipmentId = Convert.ToInt32(reader["equipment_id"]);
                        useTracking.Reps = Convert.ToInt32(reader["reps"]);
                        useTracking.Weight = Convert.ToDecimal(reader["weight"]);
                        useTracking.UseStart = Convert.ToDateTime(reader["use_start"]);
                        useTracking.UseStop = Convert.ToDateTime(reader["use_stop"]);
                        returnUseTracking.Add(useTracking);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return returnUseTracking;
        }
    }
}
