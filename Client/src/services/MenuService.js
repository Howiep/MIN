const menuItems = [
  { value: 'home', text: 'Overblik', path: 'home', icon: 'home' },
  { value: 'experiences', text: 'Erfaringer', path: 'experiences', icon: 'list' },
  { value: 'feed', text: 'Feed', path: 'feed', icon: 'notifications_none' },
  { value: 'user', text: 'Bruger', path: 'user', icon: 'person_outline' }
]

export default {
  get () {
    try {
      return menuItems
    } catch (error) {
      return 'Failed to get menu items'
    }
  },
  getText (menuPath) {
    try {
      const path = menuPath.slice(1)
      return menuItems.find(menuPath => menuPath.path === path).text
    } catch (error) {
      console.log(error)
      return 'MIN'
    }
  }
}
