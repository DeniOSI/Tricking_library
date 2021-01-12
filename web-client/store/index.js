export const mutations = {
  }
export const actions = {
  async nuxtServerInit({ dispatch}){
    await dispatch('tricks/fetchTricks');
  }
}

