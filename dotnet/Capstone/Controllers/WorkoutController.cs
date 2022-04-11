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
        public WorkoutController(IWorkoutDAO _workoutDAO)
        {
            workoutDAO = _workoutDAO;
        }

        [HttpGet("/workouts/{userId}")]
        //[Authorize]
        public List<DailyWorkout> GetDailyWorkouts(int userId)
        {
            List<DailyWorkout> dailyWorkouts = workoutDAO.GetDailyWorkouts(userId);
            return dailyWorkouts;
        }

        [HttpGet("/workouts/{userId}/{workoutId}")]
        //[Authorize]
        public List<UseTracking> GetUseTrackings(int userId, int workoutId)
        {
            List<UseTracking> useTrackings = workoutDAO.GetWorkoutDetails(userId, workoutId);
            return useTrackings;
        }


    }
}
