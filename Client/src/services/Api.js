import axios from 'axios'
import store from '@/store'

axios.defaults.headers.common['Authorization'] = 'bearer ' + store.state.user.token

export default () => {
  return axios.create({
    baseURL: 'http://localhost:5000/api'
  })
}
