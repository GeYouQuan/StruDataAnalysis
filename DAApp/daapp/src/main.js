import Vue from 'vue'
import uploader from 'vue-simple-uploader'
import App from './App.vue'

Vue.use(uploader)

new Vue({
  el: '#app',
  render: h => h(App)
})
