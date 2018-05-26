import axios from 'axios'

export default () => {
  return axios.create({
    baseURL: 'https://cryptic-fjord-69506.herokuapp.com/api/'
  })
}
