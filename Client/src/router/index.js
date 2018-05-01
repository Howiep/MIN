import Vue from 'vue'
import Router from 'vue-router'
import Hello from '@/components/Hello'
import Register from '@/components/auth/Register'
import Login from '@/components/auth/Login'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Hello',
      component: Hello
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
    }
  ]
})
