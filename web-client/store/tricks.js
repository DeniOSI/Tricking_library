const initState = () =>({
  tricks : []
})

export const state = initState
export const getters = {

  trickItems : state => state.tricks.map(x=>({text: x.name, value: x.id})),

}

export const mutations = {
  setTricks(state, {tricks}){
    state.tricks = tricks
  },
  reset(state){
    Object.assign(state, initState())
  }
}
export const actions = {
  async fetchTricks({commit}){
    const tricks = (await  this.$axios.$get("/api/tricks"));
    commit('setTricks', {tricks});
  },
  async createTrick({commit, dispatch}, {form}) {
     await this.$axios.$post("/api/tricks", form);
     dispatch('fetchTricks')
  }
}

