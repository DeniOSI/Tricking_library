<template>
  <v-stepper v-model="step">
    <v-stepper-header>
      <v-stepper-step :complete="step > 1" step="1">
        Trick information
      </v-stepper-step>
      <v-divider></v-divider>
      <v-stepper-step step="2">
        Confirmation
      </v-stepper-step>
    </v-stepper-header>
    <v-stepper-items>
      <v-stepper-content step="1">
        <v-text-field v-model="form.trickName" label="Enter trick name" dense></v-text-field>
        <v-select v-model="form.trickId" :items="trickItems" label="Select trick" dense deletable-chips chips small-chips></v-select>
        <v-select v-model="form.difficulties" :items="trickItems" label="Select difficulty" dense deletable-chips chips small-chips></v-select>
        <v-select v-model="form.progressions" :items="trickItems" label="Select progressions" dense multiple chips small-chips deletable-chips ></v-select>
        <v-select v-model="form.prerequisites" :items="trickItems" label="Select prerequisites" dense multiple chips small-chips deletable-chips></v-select>
        <v-select v-model="form.trickCategories" :items="trickItems" label="Select categories" dense multiple chips small-chips deletable-chips></v-select>
        <v-btn @click="step++">Next</v-btn>
      </v-stepper-content>
      <v-stepper-content step="2">
        <v-btn @click="save">Save</v-btn>
      </v-stepper-content>
    </v-stepper-items>
  </v-stepper>

</template>

<script>
import {mapActions, mapMutations} from 'vuex'


const initState = () => ({
  step: 1,
  form: {
    trickName: "",
    difficulties: "",
    progressions: [],
    prerequisites: [],
    trickCategories: []
  }
})

export default {
  name: "TrickSteps",
  data: initState,
  computed: {
    trickItems(){
     return [
        {text: "foo", value: 1},
        {text: "bar", value: 2},
        {text: "baz", value: 3},
      ]
    }
  },
  methods: {
    ...mapMutations('video-upload', ['reset']),
    ...mapActions('tricks', ['createTrick']),
    async save() {
      await this.createTrick({form: {name: this.form.trickName},})
      this.reset();
      Object.assign(this.$data, initState)
    },

  }
}
</script>

<style scoped>

</style>
