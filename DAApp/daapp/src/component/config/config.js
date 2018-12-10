export const ACCEPT_CONFIG = {
  UploadURL="",
  image: ['.png', '.jpg', '.jpeg', '.gif', '.bmp'],
  video: ['.mp4', '.rmvb', '.mkv', '.wmv', '.flv'],
  document: ['.doc', '.docx', '.xls', '.xlsx', '.ppt', '.pptx', '.pdf', '.txt', '.tif', '.tiff'],
  getAll(){
      return [...this.image, ...this.video, ...this.document]
  },
  getDatas(){
      return [...this.image, ...this.document]
  },
};
