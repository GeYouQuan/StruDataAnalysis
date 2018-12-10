<template>
  <div id="app">
    <h1>{{ msg }}</h1>
    <uploadcomponent></uploadcomponent>
  </div>
</template>

<script>
import uploadcomponent from './component/upload/index.vue'
export default {
  name: 'app',
  data () {
    return {
      msg: '结构化数据解析平台'
    }
  },
  components: { uploadcomponent }
}
</script>

<style lang="scss">
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}

h1, h2 {
  font-weight: normal;
}

</style>
