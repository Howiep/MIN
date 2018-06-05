import Api from '@/services/Api'

export default {
  create (shift) {
    return Api().post('/shifts', shift)
  }
}
