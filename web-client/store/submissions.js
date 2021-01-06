const initState = () =>({
  submissions : []
})

export const state = initState

export const mutations = {
  setSubmission(state, {submissions}){
    state.submissions = submissions
  },
  reset(state){
    Object.assign(state, initState())
  }
}
export const actions = {
  async fetchSubmissionsForTrick({commit}, {trickid}){

    const submission = (await  this.$axios.$get(`/api/tricks/${trickid}/submissions`));
    console.log(submission);
    commit('setSubmission', {submission});
  },
}

