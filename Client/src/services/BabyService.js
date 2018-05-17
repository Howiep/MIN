import babies from '@/services/data/babies.json'
import _ from 'lodash'

export default {
  async get () {
    try {
      return await babies
    } catch (error) {
      return 'Failed to get babies'
    }
  }
}
