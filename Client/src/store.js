import Vue from 'vue'
import Vuex from 'vuex'
import createPersistedState from 'vuex-persistedstate'

Vue.use(Vuex)

export default new Vuex.Store({
  strict: true,
  state: {
    isLoggedIn: null,
    user: {
      token: null,
      userId: null,
      userName: null
    },
    snackContent: {
      snackbarStatus: null,
      timeout: null,
      snackColor: null,
      message: null
    }
  },
  mutations: {
    setUser (state, user) {
      state.user.token = user.token
      state.user.userId = user.userId
      state.user.userName = user.userName
      state.isLoggedIn = !!(user.token)
    },
    toggleSnackbar (state, snackContent) {
      state.snackContent.snackbarStatus = snackContent.snackbarStatus
      state.snackContent.timeout = snackContent.timeout
      state.snackContent.snackColor = snackContent.snackColor
      state.snackContent.message = snackContent.message
    },
    resetSnackbar (state, snackContent) {
      state.snackContent.snackbarStatus = false
      state.snackContent.timeout = null
      state.snackContent.snackColor = null
      state.snackContent.message = null
    }
  },
  actions: {
    setUser ({commit}, user) {
      commit('setUser', user)
    },
    toggleSnackbar ({commit}, snackContent) {
      commit('toggleSnackbar', snackContent)
      setTimeout(() => {
        commit('resetSnackbar', snackContent)
      }, snackContent.timeout)
    }
  },
  getters: {
    isLoggedIn (state) {
      return state.isLoggedIn
    },
    snackContent (state) {
      return state.snackContent
    }
  },
  plugins: [createPersistedState()]
})
