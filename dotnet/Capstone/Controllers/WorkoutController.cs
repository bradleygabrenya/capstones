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
    public class WorkoutController : ControllerBase
    {
        private readonly IWorkoutDAO workoutDAO;
        private readonly IUserDao userDAO;
        public WorkoutController(IWorkoutDAO _workoutDAO, IUserDao _userDAO)
        {
            userDAO = _userDAO;
            workoutDAO = _workoutDAO;
        }

        [HttpGet("/workouts/{userId}")]
        //[Authorize]
        public List<DailyWorkout> GetDailyWorkouts(int userId)
        {
            List<DailyWorkout> dailyWorkouts = workoutDAO.GetDailyWorkouts(userId);
            return dailyWorkouts;
        }

        [HttpGet("/workoutdetails/{workoutId}")]
        //[Authorize]
        public List<UseTracking> GetUseTrackings(int workoutId)
        {
            List<UseTracking> useTrackings = workoutDAO.GetWorkoutDetails(workoutId);
            return useTrackings;
        }

        [HttpPost("/workouts/{userId}")]
        //[Authorize]
        public int PostDailyWorkout(int userId)
        {
            int completed = workoutDAO.StartDailyWorkout(userId);
            return completed;
        }

        [HttpPost("/workoutdetails")]
        //[Authorize]
        public int PostUseTracking(UseTracking useTracking)
        {
            int completed = workoutDAO.CreateUseTracking(useTracking);
            return completed;
        }

        [HttpPut("/workoutdetails")]
        //[Authorize]
        public string PutUseTracking(UseTracking useTracking)
        {
            string completed = workoutDAO.PutUseTracking(useTracking);
            return completed;
        }

        [HttpPut("/workoutdetails/{workoutId}")]
        public string PutDailyWorkout(int workoutId)
        {
            string completed = workoutDAO.PutDailyWorkout(workoutId);
            return completed;
        }

        [HttpPut("/employeeCheckout/{userId}")]
        //[Authorize(Roles = "employee, admin")]
        public void EmployeePutDailyWorkout(int userId)
        {
            workoutDAO.EmployeePutDailyWorkout(userId);
        }

        [HttpGet("/usermetrics/{userId}")] 
        public UserMetrics GetUserMetrics(int userId)
        {
            UserMetrics userMetrics = new UserMetrics();

            userMetrics.SevenDaySum = workoutDAO.SumSevenDays(userId);
            userMetrics.ThirtyDaySum = workoutDAO.SumThirtyDays(userId);
            userMetrics.SumSevenDayVisits = workoutDAO.SumSevenDayVisits(userId);
            userMetrics.SumThirtyDayVisits = workoutDAO.SumThirtyDayVisits(userId);

            return userMetrics;
        }

        [HttpGet("/totalusermetrics")]
        public TotalAverageMetrics GetTotalUserMetrics()
        {
            TotalAverageMetrics totalAverageMetrics = new TotalAverageMetrics();

            totalAverageMetrics.TotalAverageSevenDaySum = workoutDAO.TotalAverageSumSevenDays();
            totalAverageMetrics.TotalAverageThirtyDaySum = workoutDAO.TotalAverageSumThirtyDays();
            totalAverageMetrics.TotalAverageSevenDayVisits = workoutDAO.TotalAverageSevenDayVisits();
            totalAverageMetrics.TotalAverageThirtyDayVisits = workoutDAO.TotalAverageThirtyDayVisits();

            return totalAverageMetrics;
        }
    }
}
