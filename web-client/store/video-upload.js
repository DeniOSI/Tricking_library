import {UPLOAD_TYPE} from "~/data/enum";

const initState = () => ({
  uploadPromise: null,
  active: false,
  type: '',
  step: 1,
})
export const state = initState
export const mutations = {
  setTask(state, {task}) {
    state.uploadPromise = task
    state.step++
  },
  setType(state, {type}) {
    state.type = type
    if(state.type === UPLOAD_TYPE.TRICK)
    state.step++
    else
      state.step+=2
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
    const task = this.$axios.$post('/api/videos', form);
    commit('setTask', {task});
  },
  async createTrick({commit, dispatch}, {trick}) {
    await this.$axios.$post("/api/tricks", trick);
    await dispatch('tricks/fetchTricks')
  }
}

