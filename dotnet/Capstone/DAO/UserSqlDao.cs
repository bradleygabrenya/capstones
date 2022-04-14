using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Capstone.DAO.Interfaces;
using Capstone.Models;
using Capstone.Security;
using Capstone.Security.Models;

namespace Capstone.DAO
{
    public class UserSqlDao : IUserDao
    {
        private readonly string connectionString;
        
        private string checkOutUser = "UPDATE users SET check_in = 'false' WHERE user_id = @user_id;";
        private string updateRole = "UPDATE users SET user_role = @new_role WHERE user_id = @user_id;";
        private string updateProfile = "UPDATE users SET email = @email, workout_goals = @workout_goals, workout_profile = @workout_profile, " +
            "photo = @photo WHERE user_id = @user_id";
        public UserSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public User GetUser(string username)
        {
            User returnUser = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM users WHERE username = @username", conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        returnUser = GetUserFromReader(reader);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return returnUser;
        }

        public List<User> GetUsers()
        {
            List<User> returnUsers = new List<User>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM users", conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        User returnUser = GetUserFromReader(reader);
                        returnUsers.Add(returnUser);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return returnUsers;
        }

        public User AddUser(string username, string password, string role,string email, string workoutGoals,string workoutProfile, string photo)
        {
            IPasswordHasher passwordHasher = new PasswordHasher();
            PasswordHash hash = passwordHasher.ComputeHash(password);

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO users (username, password_hash, salt, user_role) VALUES (@username, @password_hash, @salt, @user_role)", conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password_hash", hash.Password);
                    cmd.Parameters.AddWithValue("@salt", hash.Salt);
                    cmd.Parameters.AddWithValue("@user_role", role);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return GetUser(username);
        }

        private User GetUserFromReader(SqlDataReader reader)
        {
            User u = new User()
            {
                UserId = Convert.ToInt32(reader["user_id"]),
                Username = Convert.ToString(reader["username"]),
                PasswordHash = Convert.ToString(reader["password_hash"]),
                Salt = Convert.ToString(reader["salt"]),
                Role = Convert.ToString(reader["user_role"]),
                Email = Convert.ToString(reader["email"]),
                WorkoutGoals = Convert.ToString(reader["workout_goals"]),
                WorkoutProfile = Convert.ToString(reader["workout_profile"]),
                Photo = Convert.ToString(reader["photo"]),
                CheckedIn = Convert.ToString(reader["check_in"])
            };

            return u;
        }

        public void UpdateUserRole(User user)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(updateRole, conn);
                    cmd.Parameters.AddWithValue("@user_id", user.UserId);
                    cmd.Parameters.AddWithValue("@new_role", user.Role);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }

        }

        public void UpdateUserProfile(User user)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(updateProfile, conn);
                    cmd.Parameters.AddWithValue("@user_id", user.UserId);
                    cmd.Parameters.AddWithValue("@email", user.Email);
                    cmd.Parameters.AddWithValue("@workout_goals", user.WorkoutGoals);
                    cmd.Parameters.AddWithValue("@workout_profile", user.WorkoutProfile);
                    cmd.Parameters.AddWithValue("@photo", user.Photo);
                    
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }
        //cmd.Parameters.AddWithValue("@email", email);
        //cmd.Parameters.AddWithValue("@workout_goals", workoutGoals);
        //cmd.Parameters.AddWithValue("@workout_profile", workoutProfile);
        //cmd.Parameters.AddWithValue("@photo", photo);
    }
}
