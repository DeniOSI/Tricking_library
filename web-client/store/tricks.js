import Axios from "axios";

const initState = () =>({
  tricks : []
})

export const state = initState

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
    console.log('fetchTricks start')
    const tricks = (await Axios.get("http://localhost:5000/api/tricks")).data;
    console.log('Tricks: ', tricks);
    commit('setTricks');
  },
  async createTrick({commit, dispatch}, {trick})
  {
    await Axios.post("http://localhost:5000/api/tricks", trick);
    dispatch('fetchTricks');
  }
}

