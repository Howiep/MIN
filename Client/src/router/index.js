import Vue from 'vue'
import Router from 'vue-router'
import Home from '@/components/Home'
import Register from '@/components/setup/Register'
import Login from '@/components/auth/Login'
import LandingPage from '@/components/setup/LandingPage'
import IntroPage from '@/components/setup/Intro'

import ExperiencePage from '@/components/experience/experience'
import ExperienceAddPage from '@/components/experience/experience-add/experienceAdd'

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
      path: '/experience',
      name: 'experience',
      component: ExperiencePage
    },
    {
      path: '/experience-add',
      name: 'experience-add',
      component: ExperienceAddPage
    }
  ]
})
