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
        public int StartDailyWorkout(int userId);
        public int CreateUseTracking(UseTracking useTracking);
        public string PutUseTracking(UseTracking useTracking);
        public string PutDailyWorkout(int workoutId);
        
    }
}
