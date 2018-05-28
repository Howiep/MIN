import Vue from 'vue'
import Router from 'vue-router'
import store from './store'

// Code splitting, webpack will make these into a file each on top of the reguler bundling.
const LandingPage = () => import(/* webpackChunkName: "landingPage" */ '@/components/setup/LandingPage')
const Register = () => import(/* webpackChunkName: "register" */ '@/components/setup/Register')
const IntroPage = () => import(/* webpackChunkName: "intro" */ '@/components/setup/Intro')
const Login = () => import(/* webpackChunkName: "login" */ '@/components/auth/Login')
const Home = () => import(/* webpackChunkName: "home" */ '@/views/Home')
const ExperiencesPage = () => import(/* webpackChunkName: "experiences" */ '@/views/Experiences')
const FeedPage = () => import(/* webpackChunkName: "feed" */ '@/views/Feed')
const UserPage = () => import(/* webpackChunkName: "user" */ '@/views/User')

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
      redirect: 'home'
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
      beforeEnter: ifLoggedIn
    },

    // Experience
    {
      path: '/experiences',
      name: 'experiences',
      component: ExperiencesPage,
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
