export const mutations = {
  }
export const actions = {
  async nuxtServerInit({commit, dispatch}){
    await dispatch('tricks/fetchTricks');
    await dispatch('submissions/fetchSubmissions');
  }
}

