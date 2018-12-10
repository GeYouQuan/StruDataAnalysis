<template>
 <uploader :options="options"
                @file-added="onFileAdded"
                @file-success="onFileSuccess"
                @file-progress="onFileProgress"
                @file-error="onFileError"
                class="uploader-example">
  <uploader-unsupport></uploader-unsupport>
  <uploader-drop>
   <p>Drop files here to upload or</p>
   <uploader-btn>select files</uploader-btn>
   <uploader-btn :attrs="attrs">select images</uploader-btn>
   <uploader-btn :directory="true">select folder</uploader-btn>
  </uploader-drop>
  <uploader-list></uploader-list>
 </uploader>
</template>

<script>
import {api} from "../../api/api.js"
import {ACCEPT_CONFIG} from "../config/config.js"
    import SparkMD5 from 'spark-md5';
 export default {
  data () {
   return {
    options: {
     // 可通过 https://github.com/simple-uploader/Uploader/tree/develop/samples/Node.js 示例启动服务
     target: api.UploadURL,
     testChunks: false
    },
    attrs: {
     accept: 'image/*|document/*'
    }
   }
  },
        methods: {
            onFileAdded(file) {

            },
            onFileProgress(rootFile, file, chunk) {
                console.log(`上传中 ${file.name}，chunk：${chunk.startByte / 1024 / 1024} ~ ${chunk.endByte / 1024 / 1024}`)
            },
            onFileSuccess(rootFile, file, response, chunk) {
                let res = JSON.parse(response);
                // 服务器自定义的错误，这种错误是Uploader无法拦截的
                if (!res.result) {
                    //this.$message({ message: res.message, type: 'error' });
                    return
                }
                console.log('上传成功');
            },
            onFileError(rootFile, file, response, chunk) {
               /**
                * this.$message({
                    message: response,
                    type: 'error'
                })
                * */
                console.log(response);
            },

            close() {
            },
            error(msg) {
                this.$notify({
                    title: this.$t('c.false'),
                    message: msg,
                    type: 'error',
                    duration: 2000
                })
            }
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
