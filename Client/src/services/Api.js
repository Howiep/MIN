import axios from 'axios'

export default () => {
  return axios.create({
    baseURL: 'https://still-woodland-62167.herokuapp.com/api/'
  })
}
