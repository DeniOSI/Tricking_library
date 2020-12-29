<template>

  <div>

    <v-file-input
      label="File input"
      outlined
      dense
      @change="handleFile"
      accept = "video/*"
    ></v-file-input>

    {{ message }}
    <v-btn @click="reset">Reset message</v-btn>

    <div v-if="tricks">

      <p v-for="t in tricks">
        {{ t.name }}
      </p>
    </div>

    <v-text-field v-model="trickName"></v-text-field>
    <v-btn @click="saveTrick">Save trick</v-btn>

    <v-btn @click="resetTricks">Reset tricks</v-btn>
  </div>

</template>

<script>
import Logo from '~/components/Logo.vue'
import VuetifyLogo from '~/components/VuetifyLogo.vue'
import {mapState, mapActions, mapMutations} from 'vuex'
import Axios from "axios";

export default {
  components: {
    Logo,
    VuetifyLogo
  },
  data: () => ({
    trickName: ""
  }),
  computed: {
    ...mapState({
      message: state => state.message
    }),
    ...mapState('tricks', {
      tricks: state => state.tricks
    })
  },
  methods: {
    ...mapMutations([
      'reset'
    ]),
    ...mapMutations({
      resetTricks: 'reset'
    }),
    ...mapActions('tricks', ['createTrick']),
    async saveTrick() {
      await this.createTrick(this.trickName)
    },
    async handleFile(file){
      if(!file)
      return;
      console.log(file)
        const result =  new FormData();
        result.append("video", file)
        await Axios.post('http://localhost:5000/api/videos', result);
    }
  }


  // fetch: async function () {
  //   console.log("test fetchMessage")
  //   // await this.$store.dispatch("fetchMessage");
  //  await this.$store.dispatch('fetchMessage');
  // }
  // asyncData(payload){
  //   console.log("Just test")
  //  return Axios.get("http://localhost:5000/api/home/")
  //     .then(({data}) => {
  //       return {message: data}
  //     })
  // }


}
</script>
