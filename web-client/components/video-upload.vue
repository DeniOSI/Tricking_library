<template>
  <v-dialog :value="active" persistent>
    <!--  <template v-slot:activator="{ on }">-->
    <!--          <v-btn @click="toggleActivity" depressed>-->
    <!--            Upload-->
    <!--          </v-btn>-->
    <!--  </template>-->
    <v-stepper v-model="step">
      <v-stepper-header>
        <v-stepper-step :complete="step > 1" step="1">
          Select type
        </v-stepper-step>
        <v-divider v-if="type===uploadedType().TRICK"></v-divider>

        <v-stepper-step v-if="type===uploadedType().TRICK" :complete="step > 2" step="2">
          Trick information
        </v-stepper-step>
        <v-divider></v-divider>

        <v-stepper-step :complete="step > 3" step="3">
          Upload video
        </v-stepper-step>
        <v-divider></v-divider>
        <v-stepper-step :complete="step > 4" step="4">
          Trick information
        </v-stepper-step>
        <v-divider></v-divider>
        <v-stepper-step step="5">
          Confirmation
        </v-stepper-step>
      </v-stepper-header>
      <v-stepper-items>
        <v-stepper-content step="1">
          <div class="d-flex flex-column align-center">
            <v-btn class="my-2" @click="setType({type: uploadedType().TRICK})">Video</v-btn>
            <v-btn class="my-2" @click="setType({type: uploadedType().SUBMISSION})">Submission</v-btn>
          </div>
        </v-stepper-content>
        <v-stepper-content step="2">
          <div>
            <v-text-field v-model="trickName" label="Trick name"></v-text-field>
            <v-btn @click="saveTrick">Save trick</v-btn>
          </div>
        </v-stepper-content>
          <v-stepper-content step="3">
            <v-file-input show-size label="File input" accept="video/*" @change="handleFile"></v-file-input>
          </v-stepper-content>
          <v-stepper-content step="4">
            <v-text-field v-model="trickName"></v-text-field>
            <v-btn @click="saveTrick">Save trick</v-btn>
          </v-stepper-content>
          <v-stepper-content step="5">
            Success
          </v-stepper-content>
      </v-stepper-items>
    </v-stepper>
    <div class="justify-center d-flex my-4">
      <v-btn @click="toggleActivity">Close</v-btn>
    </div>
  </v-dialog>
</template>

<script>
import {mapState, mapActions, mapMutations} from 'vuex'
import {UPLOAD_TYPE} from '~/data/enum.js'

export default {
  name: "video-upload",
  data: () => ({
    trickName: "",

  }),
  computed: {
    ...mapState('video-upload', ['uploadPromise', 'active', "step", "type"])
  },
  methods: {
    ...mapMutations('video-upload', ['reset', 'toggleActivity', 'setType']),
    ...mapActions('video-upload', ['uploadVideo', 'createTrick']),

    uploadedType() {
      return UPLOAD_TYPE
    },

    async handleFile(file) {
      if (!file)
        return;
      const form = new FormData();
      form.append("video", file)
      console.log({form})
      await this.uploadVideo({form});
    },

    async saveTrick() {
      if (!this.uploadPromise) {
        console.log('File wasn\'t uploaded');
        return;
      }
      const video = await this.uploadPromise;
      console.log(video);
      await this.createTrick({trick: {name: this.trickName, video}})
      this.reset();
    },

  }
}
</script>

<style scoped>

</style>
