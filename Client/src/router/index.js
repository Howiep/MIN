import Vue from 'vue'
import Router from 'vue-router'
import Home from '@/components/Home'
import Register from '@/components/auth/Register'
import Login from '@/components/auth/Login'
import LandingPage from '@/components/setup/Landing'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
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
    {
      path: '/landing',
      name: 'landing',
      component: LandingPage
    }
  ]
})
