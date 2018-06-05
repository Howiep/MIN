import axios from 'axios'
import store from '@/store'

axios.defaults.headers.common['Authorization'] = 'bearer ' + store.state.user.token

export default () => {
  return axios.create({
    baseURL: 'https://cryptic-fjord-69506.herokuapp.com/api'
  })
}
