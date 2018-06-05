import Api from '@/services/Api'

export default {
  register (credentials) {
    return Api().post('/auth/register', credentials)
  },
  login (credentials) {
    return Api().post('/auth/login', credentials)
  },
  getUser (credentials) {
    return Api().get('/auth', credentials)
  }
}
