import Api from '@/services/Api'

export default {
  get () {
    return Api().get('/shifts')
  },
  create (shift) {
    return Api().post('/shifts', shift)
  }
}
