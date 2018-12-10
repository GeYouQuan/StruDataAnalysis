<template>
  <uploader :options="options" class="uploader-example">
    <uploader-unsupport></uploader-unsupport>
    <uploader-drop>
      <p>拖动文件到此上传</p>
      <uploader-btn>上传(批量)</uploader-btn>
      <uploader-btn :attrs="attrs">上传</uploader-btn>
      <uploader-btn :directory="true">上传文件夹</uploader-btn>
    </uploader-drop>
    <uploader-list></uploader-list>
  </uploader>
</template>

<script>
import {ACCEPT_CONFIG} from '../config/config.js'
import {api} from '../../api/api.js'
  export default {
    data () {
      return {
        options: {
          target: api.UploadURL, // '//jsonplaceholder.typicode.com/posts/',
          testChunks: false
        },
        attrs: {
          accept: ACCEPT_CONFIG.getDatas()
        },
        statusText: {
          success: '成功了',
          error: '出错了',
          uploading: '上传中',
          paused: '暂停中',
          waiting: '等待中'
        }
      }
    },
    methods: {
      complete () {
        console.log('complete', arguments)
      },
      fileComplete () {
        console.log('file complete', arguments)
      }
    },
    mounted () {
      this.$nextTick(() => {
        window.uploader = this.$refs.uploader.uploader
      })
    }
  }
</script>

<style>
  .uploader-example {
    width: 880px;
    padding: 15px;
    margin: 40px auto 0;
    font-size: 12px;
    box-shadow: 0 0 10px rgba(0, 0, 0, .4);
  }
  .uploader-example .uploader-btn {
    margin-right: 4px;
  }
  .uploader-example .uploader-list {
    max-height: 440px;
    overflow: auto;
    overflow-x: hidden;
    overflow-y: auto;
  }
</style>
