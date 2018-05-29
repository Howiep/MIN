import Api from '@/services/Api'

export default {
  get () {
    try {
      return Api().get('experiences')
    } catch (error) {
      return 'Failed to get experiences'
    }
  },
  getCategories () {
    try {
      return Api().get('experiences/categories')
    } catch (error) {
      return 'Failed to get categories'
    }
  },
  getActions () {
    try {
      return Api().get('experiences/actions')
    } catch (error) {
      return 'Failed to get actions'
    }
  }
}

// const experiences = [
//   {
//     experience: 'Telefonsamtale med fødende',
//     notes: 'Overblik',
//     date: new Date(),
//     time: new Date()
//   }
// ]
