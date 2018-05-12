import Vue from 'vue'
import Router from 'vue-router'
import store from './store'
import Home from '@/views/Home'
import Register from '@/components/setup/Register'
import Login from '@/components/auth/Login'
import LandingPage from '@/components/setup/LandingPage'
import IntroPage from '@/components/setup/Intro'
import ExperiencesPage from '@/views/Experiences'
import AddExperiencesPage from '@/views/AddExperience'
import FeedPage from '@/views/Feed'
import UserPage from '@/views/User'

const ifNotLoggedIn = (to, from, next) => {
  if (!store.getters.isLoggedIn) {
    next()
    return
  }
  next('/')
}

const ifLoggedIn = (to, from, next) => {
  if (store.getters.isLoggedIn) {
    next()
    return
  }
  next('/landing')
}

Vue.use(Router)

export default new Router({
  routes: [
    // Default
    {
      path: '/',
      name: '',
      redirect: 'home',
      beforeEnter: ifLoggedIn
    },
    {
      path: '/home',
      name: 'home',
      component: Home,
      beforeEnter: ifLoggedIn
    },

    // Auth
    {
      path: '/register',
      name: 'register',
      component: Register,
      beforeEnter: ifNotLoggedIn
    },
    {
      path: '/login',
      name: 'login',
      component: Login,
      beforeEnter: ifNotLoggedIn
    },

    // Intro
    {
      path: '/landing',
      name: 'landing',
      component: LandingPage,
      beforeEnter: ifNotLoggedIn
    },
    {
      path: '/intro',
      name: 'intro',
      component: IntroPage,
      beforeEnter: ifNotLoggedIn
    },

    // Experience
    {
      path: '/experiences',
      name: 'experiences',
      component: ExperiencesPage,
      beforeEnter: ifLoggedIn
    },
    {
      path: '/experiences-add',
      name: 'experiences-add',
      component: AddExperiencesPage,
      beforeEnter: ifLoggedIn
    },

    // Feed
    {
      path: '/feed',
      name: 'feed',
      component: FeedPage,
      beforeEnter: ifLoggedIn
    },

    // User
    {
      path: '/user',
      name: 'user',
      component: UserPage,
      beforeEnter: ifLoggedIn
    }
  ]
})
