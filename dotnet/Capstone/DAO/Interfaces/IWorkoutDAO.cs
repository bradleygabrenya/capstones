using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO.Interfaces
{
    public interface IWorkoutDAO
    {
        public List<DailyWorkout> GetDailyWorkouts(int userId);
        public List<UseTracking> GetWorkoutDetails(int workoutId);
        public String StartDailyWorkout(int userId);

        
    }
}
