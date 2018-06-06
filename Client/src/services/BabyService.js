import babies from '@/services/data/babies.json'

export default {
  async get () {
    try {
      return await babies
    } catch (error) {
      return 'Failed to get babies'
    }
  }
}
