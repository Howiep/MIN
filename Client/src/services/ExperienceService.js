const experiences = [
  {
    experience: 'Telefonsamtale med fødende',
    notes: 'Overblik',
    date: new Date(),
    time: new Date()
  }
]

export default {
  get () {
    try {
      return experiences
    } catch (error) {
      return 'Failed to get experiences'
    }
  }
}
