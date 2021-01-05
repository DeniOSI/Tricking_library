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
  async fetchSubmissions({commit}){

    const submissions = (await  this.$axios.$get("/api/submissions"));
    console.log(submissions);
    commit('setSubmission', {submissions});
  },
}

