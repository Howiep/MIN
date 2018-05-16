import Vue from 'vue'
import Router from 'vue-router'
import store from './store'
import IntroPage from '@/components/setup/Intro'
import ExperiencesPage from '@/views/Experiences'
import AddExperiencesPage from '@/views/AddExperience'
import FeedPage from '@/views/Feed'
import UserPage from '@/views/User'
const Home = () => import(/* webpackChunkName: "home" */ '@/views/Home')
const Register = () => import(/* webpackChunkName: "register" */ '@/components/setup/Register')
const Login = () => import(/* webpackChunkName: "login" */ '@/components/auth/Login')
const LandingPage = () => import(/* webpackChunkName: "landingPage" */ '@/components/setup/LandingPage')

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
    {
      path: '/experiences-add',
      name: 'experiences-add',
      component: AddExperiencesPage
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
