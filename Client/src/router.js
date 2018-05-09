import Vue from 'vue'
import Router from 'vue-router'
import Home from '@/views/Home'
import Register from '@/components/setup/Register'
import Login from '@/components/auth/Login'
import LandingPage from '@/components/setup/LandingPage'
import IntroPage from '@/components/setup/Intro'
import ExperiencesPage from '@/views/Experiences'
import FeedPage from '@/views/Feed'
import UserPage from '@/views/User'

Vue.use(Router)

export default new Router({
  routes: [
    // Default
    {
      path: '/',
      name: '',
      redirect: 'home'
    },
    {
      path: '/home',
      name: 'home',
      component: Home
    },

    // Auth
    {
      path: '/register',
      name: 'register',
      component: Register
    },
    {
      path: '/login',
      name: 'login',
      component: Login
    },

    // Intro
    {
      path: '/landing',
      name: 'landing',
      component: LandingPage
    },
    {
      path: '/intro',
      name: 'intro',
      component: IntroPage
    },

    // Experience
    {
      path: '/experiences',
      name: 'experiences',
      component: ExperiencesPage
    },

    // Feed
    {
      path: '/feed',
      name: 'feed',
      component: FeedPage
    },

    // User
    {
      path: '/user',
      name: 'user',
      component: UserPage
    }
  ]
})
