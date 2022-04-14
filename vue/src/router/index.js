import Vue from 'vue'
import Router from 'vue-router'
import Home from '../views/Home.vue'
import Login from '../views/Login.vue'
import Logout from '../views/Logout.vue'
import Register from '../views/Register.vue'
import store from '../store/index'
import DailyWorkouts from '../views/DailyWorkouts.vue'
import WorkoutDetails from '../views/WorkoutDetails.vue'
import UserList from '../views/UsersView.vue'
import UseTrackingForm from '../views/UseTrackingForm.vue'
import UpdateUserRole from '../views/UpdateUserRole.vue'
import UserProfile from '../views/UserProfile.vue'


Vue.use(Router)

/**
 * The Vue Router is used to "direct" the browser to render a specific view component
 * inside of App.vue depending on the URL.
 *
 * It also is used to detect whether or not a route requires the user to have first authenticated.
 * If the user has not yet authenticated (and needs to) they are redirected to /login
 * If they have (or don't need to) they're allowed to go about their way.
 */

const router = new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "/login",
      name: "login",
      component: Login,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/userList",
      name: "user-list",
      component: UserList,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/logout",
      name: "logout",
      component: Logout,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/register",
      name: "register",
      component: Register,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/workouts/:userId",
      name: "workouts",
      component: DailyWorkouts,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/workoutdetails/:workoutId",
      name:"workout-details",
      component: WorkoutDetails,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/usetrackingform/:workoutId",
      name: "use-tracking-form",
      component: UseTrackingForm,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/profile/admin",
      name: "update-user-role",
      component: UpdateUserRole,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/profile/user",
      name: "user-profile",
      component: UserProfile,
      meta: {
        requiresAuth: false
      }
    }
  ]
})

router.beforeEach((to, from, next) => {
  // Determine if the route requires Authentication
  const requiresAuth = to.matched.some(x => x.meta.requiresAuth);

  // If it does and they are not logged in, send the user to "/login"
  if (requiresAuth && store.state.token === '') {
    next("/login");
  } else {
    // Else let them go to their next destination
    next();
  }
});

export default router;
