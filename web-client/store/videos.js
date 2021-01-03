const initState = () => ({
  uploadPromise: null,
  active: false,
  uploadtype: '',
})
export const state = initState
export const mutations = {
  setTask(state, {task}) {
    state.uploadPromise = task
  },
  setType(state, {uploadtype}) {
    console.log(uploadtype)
    state.uploadtype = uploadtype
  },
  toggleActivity( state) {
    state.active = !state.active
    if (!state)
      Object.assign(state, initState())
  },
  reset(state) {
    Object.assign(state, initState())
  }
}
export const actions = {
  async uploadVideo({commit, dispatch}, {form}) {
    console.log('file video:', {form})
    const task = this.$axios.$post('/api/videos', form);
    commit('setTask', {task});
  },
  async createTrick({commit, dispatch}, {trick}) {
    await this.$axios.$post("/api/tricks", trick);
    await dispatch('index/nuxtServerInit')
  }
}

