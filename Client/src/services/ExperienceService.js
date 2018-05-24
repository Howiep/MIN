import Api from '@/services/Api'

const categories = [
  {
    id: 0,
    semester: 4,
    name: 'fødselshjælp',
    icon: 'local_activity',
    groups: [
      {
        name: 'konsultation',
        actions: [
          'Temperaturmåling',
          'Modtagelse af familien',
          'Samtale om og planlægning af barselsomsorgen',
          'Vejledning i personlig hygiejne',
          'Vejledning om kvindens fysiologiske forandringer pp'
        ]},
      {
        name: 'Forberedelse',
        actions: [
          'Observation af bristning og episiotomi',
          'telefonsamtale med fødende',
          'Forberedelse til modtagelse',
          'modtage i modtagelse/fødegang',
          'Vejledning ved bristning og episiotomi',
          'Palpation af uterus p.p.',
          'Observation og vejledning omkring lokkier'
        ]}
    ]
  },
  {
    id: 1,
    semester: 4,
    name: 'barselsomsorg',
    icon: 'healing',
    groups: [
      {
        name: 'Barselshjælp',
        actions: [
          'Modtagelse af familien',
          'Samtale om og planlægning af barselsomsorgen',
          'Vejledning i personlig hygiejne',
          'Vejledning om kvindens fysiologiske forandringer pp',
          'Observation af bristning og episiotomi',
          'telefonsamtale med fødende',
          'Forberedelse til modtagelse',
          'modtage i modtagelse/fødegang',
          'Vejledning ved bristning og episiotomi',
          'Palpation af uterus p.p.',
          'Observation og vejledning omkring lokkier'
        ]
      }
    ]
  },
  {
    id: 2,
    semester: 4,
    name: 'omsorg for mor med kompliceret barsel',
    icon: 'school',
    groups: [
      {
        name: 'kompliceret fødsel',
        actions: [
          'Observation og pleje af mor med sphincterruptur',
          'Modtagelse af familien',
          'Samtale om og planlægning af barselsomsorgen',
          'Vejledning i personlig hygiejne',
          'Vejledning om kvindens fysiologiske forandringer pp',
          'Observation af bristning og episiotomi',
          'telefonsamtale med fødende',
          'Forberedelse til modtagelse',
          'modtage i modtagelse/fødegang',
          'Vejledning ved bristning og episiotomi',
          'Palpation af uterus p.p.',
          'Observation og vejledning omkring lokkier'
        ]
      }
    ]
  },
  {
    id: 3,
    semester: 4,
    name: 'observation og pleje af det nyfødte syge barn',
    icon: 'directions_run',
    groups: [
      {
        name: 'observation',
        actions: [
          'Modtagelse af barn på neonatalafd.',
          'Modtagelse af familien',
          'Samtale om og planlægning af barselsomsorgen',
          'Vejledning i personlig hygiejne',
          'Vejledning om kvindens fysiologiske forandringer pp',
          'Observation af bristning og episiotomi',
          'telefonsamtale med fødende',
          'Forberedelse til modtagelse',
          'modtage i modtagelse/fødegang',
          'Vejledning ved bristning og episiotomi',
          'Palpation af uterus p.p.',
          'Observation og vejledning omkring lokkier'
        ]
      }
    ]
  }
]

export default {
  getCategories () {
    try {
      return categories
    } catch (error) {
      return 'Failed to get experiences'
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
