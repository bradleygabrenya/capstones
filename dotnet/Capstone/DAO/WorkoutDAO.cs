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
        private string getDetails = "SELECT ut.*,e.equipment_name FROM use_tracking ut JOIN equipment e ON ut.equipment_id = e.equipment_id WHERE ut.workout_id = @workout_id ";

        private string getWorkouts = "SELECT * FROM daily_workout WHERE user_id = @user_id ORDER BY check_in DESC;";

        private string addDailyWorkout = "INSERT INTO daily_workout(user_id, check_in, check_out) " +
            " OUTPUT Inserted.workout_id " +
            " VALUES (@user_id, Getdate(), '12/31/9999'); " +
            "UPDATE users SET check_in = 'true' WHERE user_id = @user_id;";

        private string createUseTracking = "INSERT INTO use_tracking (user_id, workout_id, equipment_id, reps, weight, use_start, use_stop) " +
            " OUTPUT Inserted.tracking_id " +
            " VALUES (@user_id, @workout_id, @equipment_id, 0, 0, GETDATE(), '12/31/9999')";

        private string putUseTracking = "UPDATE use_tracking set reps = @reps, weight = @weight, use_stop = GETDATE() where tracking_id = @tracking_id";

        private string putDailyWorkout = "UPDATE daily_workout SET check_out = GETDATE() WHERE workout_id = @workout_id; " +
            "UPDATE u SET u.check_in = 'false' from users u JOIN daily_workout dw ON dw.user_id = u.user_id WHERE dw.workout_id = @workout_id; " +
            "UPDATE use_tracking set use_stop = GETDATE() WHERE workout_id = @workout_id and use_stop > GETDATE()";

        private string putDailyWorkoutEmployee = "update dw set check_out = getdate() from daily_workout dw join users u on dw.user_id = u.user_id " +
            "where u.user_id = @user_id AND dw.check_out > getdate(); " +
            "UPDATE users SET check_in = 'false' WHERE user_id = @user_id; " +
            "UPDATE use_tracking set use_stop = GETDATE() WHERE user_id = @user_id and use_stop > GETDATE()";

        private string getSevenDaySum = "SELECT SUM(DATEDIFF(second, check_in, check_out)) FROM daily_workout WHERE check_in >= DATEADD(day, -7, GETDATE()) AND user_id = @user_id and check_out != '9999-12-31 00:00:00.000';";
        private string getThirtyDaySum = "SELECT SUM(DATEDIFF(second, check_in, check_out)) FROM daily_workout WHERE check_in >= DATEADD(day, -30, GETDATE()) AND user_id = @user_id and check_out != '9999-12-31 00:00:00.000';";
        private string getSevenDayVisits = "SELECT COUNT(check_in) FROM daily_workout WHERE check_in >= DATEADD(day, -7, GETDATE()) AND user_id = @user_id;";
        private string getThirtyDayVisits = "SELECT COUNT(check_in) FROM daily_workout WHERE check_in >= DATEADD(day, -30, GETDATE()) AND user_id = @user_id;";

        private string getTotalAverageSevenDaySum = "SELECT SUM(DATEDIFF(second, check_in, check_out)) FROM daily_workout WHERE check_in >= DATEADD(day, -7, GETDATE()) and check_out != '9999-12-31 00:00:00.000';";
        private string getTotalAverageThirtyDaySum = "SELECT SUM(DATEDIFF(second, check_in, check_out)) FROM daily_workout WHERE check_in >= DATEADD(day, -30, GETDATE()) and check_out != '9999-12-31 00:00:00.000';";
        private string getTotalAverageSevenDayVisits = "SELECT COUNT(check_in) FROM daily_workout WHERE check_in >= DATEADD(day, -7, GETDATE());";
        private string getTotalAverageThirtyDayVisits = "SELECT COUNT(check_in) FROM daily_workout WHERE check_in >= DATEADD(day, -30, GETDATE());";

        //todo calculate averages 


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
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(getWorkouts, conn);
                    cmd.Parameters.AddWithValue("@user_id", userId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
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
            catch (SqlException ex)
            {
                throw;
            }
            return dailyWorkouts;
        }
        public List<UseTracking> GetWorkoutDetails(int workoutId)
        {
            List<UseTracking> returnUseTracking = new List<UseTracking>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(getDetails, conn);
                    cmd.Parameters.AddWithValue("@workout_id", workoutId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        UseTracking useTracking = new UseTracking();
                        useTracking.TrackingId = Convert.ToInt32(reader["tracking_id"]);
                        useTracking.UserId = Convert.ToInt32(reader["user_id"]);
                        useTracking.WorkoutId = Convert.ToInt32(reader["workout_id"]);
                        useTracking.EquipmentName = Convert.ToString(reader["equipment_name"]);
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

        public int StartDailyWorkout(int userId)
        {
            int workoutId = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(addDailyWorkout, conn);
                    cmd.Parameters.AddWithValue("@user_id", userId);
                    workoutId = (int)cmd.ExecuteScalar();


                }
            }
            catch (SqlException)
            {
                throw;
            }

            return workoutId;
        }



        public int CreateUseTracking(UseTracking useTracking)
        {
            int trackingId = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(createUseTracking, conn);
                    cmd.Parameters.AddWithValue("@user_id", useTracking.UserId);
                    cmd.Parameters.AddWithValue("@workout_id", useTracking.WorkoutId);
                    cmd.Parameters.AddWithValue("@equipment_id", useTracking.EquipmentId);
                    trackingId = (int)cmd.ExecuteScalar();

                }
            }
            catch (SqlException)
            {
                throw;
            }

            return trackingId;
        }

        public string PutUseTracking(UseTracking useTracking)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(putUseTracking, conn);
                    cmd.Parameters.AddWithValue("@tracking_id", useTracking.TrackingId);
                    cmd.Parameters.AddWithValue("@reps", useTracking.Reps);
                    cmd.Parameters.AddWithValue("@weight", useTracking.Weight);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return "successful";
        }

        public string PutDailyWorkout(int workoutId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(putDailyWorkout, conn);
                    cmd.Parameters.AddWithValue("@workout_id", workoutId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return "successful";
        }

        public void EmployeePutDailyWorkout(int userId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(putDailyWorkoutEmployee, conn);
                    cmd.Parameters.AddWithValue("@user_id", userId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }

        }

        public int SumSevenDays(int userId)
        {

            int result = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(getSevenDaySum, conn);
                    cmd.Parameters.AddWithValue("@user_id", userId);

                    result = (int)cmd.ExecuteScalar();
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return result;
        }

        public int SumThirtyDays(int userId)
        {

            int result = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(getThirtyDaySum, conn);
                    cmd.Parameters.AddWithValue("@user_id", userId);

                    result = (int)cmd.ExecuteScalar();
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return result;
        }

        public int SumSevenDayVisits(int userId)
        {

            int result = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(getSevenDayVisits, conn);
                    cmd.Parameters.AddWithValue("@user_id", userId);

                    result = (int)cmd.ExecuteScalar();
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return result;
        }

        public int SumThirtyDayVisits(int userId)
        {

            int result = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(getThirtyDayVisits, conn);
                    cmd.Parameters.AddWithValue("@user_id", userId);

                    result = (int)cmd.ExecuteScalar();
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return result;
        }

        public int TotalAverageSumSevenDays()
        {
            int result = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(getTotalAverageSevenDaySum, conn);

                    result = (int)cmd.ExecuteScalar();
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return result;
        }

        public int TotalAverageSumThirtyDays()
        {
            int result = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(getTotalAverageThirtyDaySum, conn);

                    result = (int)cmd.ExecuteScalar();
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return result;
        }

        public int TotalAverageSevenDayVisits()
        {
            int result = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(getTotalAverageSevenDayVisits, conn);

                    result = (int)cmd.ExecuteScalar();
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return result;
        }

        public int TotalAverageThirtyDayVisits()
        {
            int result = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(getTotalAverageThirtyDayVisits, conn);

                    result = (int)cmd.ExecuteScalar();
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return result;
        }
    }
}
