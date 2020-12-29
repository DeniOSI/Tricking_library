<template>
  <v-row justify="center" align="center">
    <v-col cols="12" sm="8" md="6">
      <div class="text-center">
        <logo/>
        <vuetify-logo/>
      </div>
          {{ message }}
      <v-btn @click="reset">Reset message</v-btn>

      <div v-if="tricks">

        <p v-for="t in tricks">
        {{t.name}}
      </p>
      </div>

      <v-text-field v-model="trickName"></v-text-field>
      <v-btn @click="saveTrick">Save trick</v-btn>

      <v-btn @click="resetTricks">Reset tricks</v-btn>



    </v-col>
  </v-row>
</template>

<script>
import Logo from '~/components/Logo.vue'
import VuetifyLogo from '~/components/VuetifyLogo.vue'
import {mapState, mapActions, mapMutations} from 'vuex'

export default {
  components: {
    Logo,
    VuetifyLogo
  },
  data: () => ({
    trickName: ""
  }),
  computed:{
    ...mapState({
    message: state => state.message}),
    ...mapState('tricks', {
     tricks: state => state.tricks})
    },
  methods: {
    ...mapMutations([
    'reset'
  ]),
  ...mapMutations('tricks', {
     resetTricks: 'reset'
  }),
  ...mapActions('tricks', ['createTrick']),
  async saveTrick(){

    console.log('Trick name: ', this.trickName)
    await this.createTrick({trick: {name: this.trickName}})
    this.trickName = "";
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
