import  axios from "axios";

const initState = () =>({
  message : "Init"
})

export const state = initState

export const mutations = {
  setMessage(state, message){
    state.message = message
  },
  reset(state){
    Object.assign(state, initState())
  }
}

export const actions = {
  async nuxtServerInit({commit, dispatch}){
    const message = (await axios.get("http://localhost:5000/api/home")).data;
    commit("setMessage", message)
    // await dispatch('tricks/fetchTricks');
  }
}

