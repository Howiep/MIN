const categories = [
  {
    id: 0,
    semester: 4,
    name: 'fødselshjælp',
    actions: [
      'Temperaturmåling',
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
  },
  {
    id: 1,
    semester: 4,
    name: 'barselsomsorg',
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
  },
  {
    id: 2,
    semester: 4,
    name: 'omsorg for mor med kompliceret barsel',
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
  },
  {
    id: 3,
    semester: 4,
    name: 'observation og pleje af det nyfødte syge barn',
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
  },
  {
    id: 4,
    semester: 4,
    name: 'pleje af barn med:',
    actions: [
      'Respiratoriske problemer',
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
  },
  {
    id: 5,
    semester: 4,
    name: 'andet relevant',
    actions: [
      'Tværfaglig samarbejde',
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
  },
  {
    id: 6,
    semester: 4,
    name: 'gynækologi',
    actions: [
      'Indlæggelsessamtale',
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
  },
  {
    id: 7,
    semester: 4,
    name: 'diagnoser',
    actions: [
      'Fertilitetsproblemer',
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
  },
  {
    id: 8,
    semester: 4,
    name: 'svangreomsorg Jordmoderkonsultation',
    actions: [
      'Jordemoderkonsultation',
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
  },
  {
    id: 9,
    semester: 4,
    name: 'kompliceret svangreomsorg',
    actions: [
      'Mindre liv',
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
  },
  {
    id: 10,
    semester: 4,
    name: 'kompliceret fødsel',
    actions: [
      'Observation og vurdering af afvigende og patologisk CTG',
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
  },
  {
    id: 11,
    semester: 4,
    name: 'det nyfødte barn',
    actions: [
      'Genoplivning af nyfødte',
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
  },
  {
    id: 12,
    semester: 4,
    name: 'dokumentation og rapportering',
    actions: [
      'Journalføring',
      'Fødselsregistrering / anmeldelser',
      'Rapportgivning ved vagtskifte eller overflytning'
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
