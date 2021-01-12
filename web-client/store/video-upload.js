import {UPLOAD_TYPE} from "~/data/enum";

const initState = () => ({
  uploadPromise: null,
  active: false,
  //type: '',
  component : null

})
export const state = initState
export const mutations = {
  activate(state, {component}){
    state.active = true;
    state.component = component;
  },
  hid(state){
    this.active  = false;
  },
  setTask(state, {task}) {
    state.uploadPromise = task

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
  async createSubmission({state, commit, dispatch}, {form})
  {
    if (!state.uploadPromise) {
      console.log('File wasn\'t uploaded');
      return;
    }
    form.video= await state.uploadPromise;
    await dispatch('submissions/createSubmission', {form}, {root: true})
    commit('reset');
  }
}

