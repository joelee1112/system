<template>
  <section class="card">
    <header class="card-header">
      <div class="card-actions">
        <a href="#" class="card-action card-action-toggle" data-card-toggle=""></a>
      </div>
      <h2 class="card-title">{{$root.subTitle}}</h2>
    </header>
    <div class="card-body">
      <tree ref="tree" />
    </div>
    <popup ref="popup" title="設定內容" @submit="submit">
      <div class="form-group row">
        <label class="col-sm-3 control-label text-sm-right pt-2">
          <span class="required">*</span>
          名稱
        </label>
        <div class="col-sm-9">
          <input type="text" v-model="form.title" class="form-control" required v-focus />
        </div>
      </div>
      <div class="form-group row">
        <label class="col-sm-3 control-label text-sm-right pt-2">
          <span class="required">*</span>
          Url
        </label>
        <div class="col-sm-9">
          <input type="text" v-model="form.url" class="form-control" />
        </div>
      </div>
      <div class="form-group row">
        <label class="col-sm-3 control-label text-sm-right pt-2">Html
        </label>
        <div class="col-sm-9">
          <html-editor v-model="form.html" />
        </div>
      </div>
      <div class="form-group row">
        <label class="col-sm-3 control-label text-sm-right pt-2">
          資料發布日期
        </label>
        <div class="col-sm-9">
          <input type="text" v-model="form.postTime" class="form-control" />
        </div>
      </div>
      <div class="form-group row">
        <label class="col-sm-3 control-label text-sm-right pt-2">
          上架時間
        </label>
        <div class="col-sm-9">
          <input type="text" v-model="form.beginTime" class="form-control" />
        </div>
      </div>
      <div class="form-group row">
        <label class="col-sm-3 control-label text-sm-right pt-2">
          下架時間
        </label>
        <div class="col-sm-9">
          <input type="text" v-model="form.endTime" class="form-control" />
        </div>
      </div>
      <div class="form-group row">
        <label class="col-sm-3 control-label text-sm-right pt-2">
          照片
        </label>
        <div class="col-sm-9">
          <input ref="imgFile" type="file" accept="image/*" @change="getImg()" class="form-control" />
        </div>
      </div>
      <div class="form-group row" v-if="form.imageUrl">
        <label class="col-sm-3 control-label text-sm-right pt-2">
          照片預覽
        </label>
        <div class="col-sm-9">
          <img :src="form.imageUrl">
          <a @click="form.imageUrl=''">刪除</a>
        </div>
      </div>
      <div class="form-group row">
        <label class="col-sm-3 control-label text-sm-right pt-2">
          檔案
        </label>
        <div class="col-sm-9">
          <input ref="uploadFile" type="file" @change="getFile()" class="form-control" />
        </div>
      </div>
      <div class="form-group row" v-if="form.fileUrl">
        <label class="col-sm-3 control-label text-sm-right pt-2">
          檔案預覽
        </label>
        <div class="col-sm-9">
          <a target="_blank" style="color:blue;" :href="form.fileUrl">{{this.fileName}}</a>
          <a @click="form.fileUrl=''">刪除</a>
        </div>
      </div>
      <div class="form-group row">
        <label class="col-sm-3 control-label text-sm-right pt-2">
          是否顯示於上方
        </label>
        <div class="col-sm-9 pt-2">
          <label><input checked="checked" v-model="form.isTop" type="radio" :value="true"> 是　</label>
          <label><input checked="checked" v-model="form.isTop" type="radio" :value="false"> 否　</label>
        </div>
      </div>
      <div class="form-group row">
        <label class="col-sm-3 control-label text-sm-right pt-2">
          是否顯示於下方
        </label>
        <div class="col-sm-9 pt-2">
          <label><input checked="checked" v-model="form.isFooter" type="radio" :value="true"> 是　</label>
          <label><input checked="checked" v-model="form.isFooter" type="radio" :value="false"> 否　</label>
        </div>
      </div>
      <div class="form-group row">
        <label class="col-sm-3 control-label text-sm-right pt-2">
          是否啟用
        </label>
        <div class="col-sm-9 pt-2">
          <label><input checked="checked" v-model="form.isEnable" type="radio" :value="true"> 是　</label>
          <label><input checked="checked" v-model="form.isEnable" type="radio" :value="false"> 否　</label>
        </div>
      </div>
      <div class="form-group row">
        <label class="col-sm-3 control-label text-sm-right pt-2">
          訪客是否能觀看
        </label>
        <div class="col-sm-9 pt-2">
          <label><input checked="checked" v-model="form.isAgent" type="radio" :value="true"> 是　</label>
          <label><input checked="checked" v-model="form.isAgent" type="radio" :value="false"> 否　</label>
        </div>
      </div>
    </popup>
  </section>
</template>

<script>
import tree from "./tree";
import popup from "shared/popup";
import { contents, permissions } from "resource";
import htmlEditor from "shared/ckeditor";
export default {
  components: { tree, popup, htmlEditor },
  data() {
    return {
      permissions: [],
      form: {
        id: null,
        title: "",
        url: "",
        permissions: [],
        html: "",
        postTime: "",
        beginTime: "",
        endTime: "",
        isTop: "",
        isFooter: "",
        isEnable: "",
        isAgent: "",
        imgFile: null,
        uploadFile: null,
        imageUrl: "",
        fileUrl: ""
      }
    };
  },
  computed: {
    fileName: function() {
      let fileName = "";
      if (this.form.fileUrl != null) {
        let [host, name] = this.form.fileUrl.split("Uploads//");
        fileName = name;
      }
      return fileName;
    }
  },
  methods: {
    getImg() {
      this.form.imgFile = this.$refs.imgFile.files[0];
    },
    getFile() {
      this.form.uploadFile = this.$refs.uploadFile.files[0];
    },
    clearForm() {
      this.form.id = null;
      this.form.title = "";
      this.form.url = "";
      this.form.html = "";
      this.form.postTime = "";
      this.form.beginTime = "";
      this.form.endTime = "";
      this.form.isTop = "";
      this.form.isFooter = "";
      this.form.isEnable = "";
      this.form.isAgent = "";
      this.form.imgFile = null;
      this.$refs.imgFile.value = null;
      this.form.uploadFile = null;
      this.$refs.uploadFile.value = null;
      this.form.imageUrl = "";
      this.form.fileUrl = "";
    },
    edit(id) {
      this.clearForm();
      contents.get({ id: id }).then(a => {
        Object.assign(this.form, Object.assign({ html: "" }, a.body));
        this.$refs.popup.show();
      });
    },
    submit() {
      let PostDatas = new FormData();
      PostDatas.append("title", this.form.title);
      PostDatas.append("url", this.form.url);
      PostDatas.append("html", this.form.html);
      PostDatas.append("postTime", this.form.postTime);
      PostDatas.append("beginTime", this.form.beginTime);
      PostDatas.append("endTime", this.form.endTime);
      PostDatas.append("isTop", this.form.isTop);
      PostDatas.append("isFooter", this.form.isFooter);
      PostDatas.append("isEnable", this.form.isEnable);
      PostDatas.append("isAgent", this.form.isAgent);
      PostDatas.append("imageUrl", this.form.imageUrl);
      PostDatas.append("fileUrl", this.form.fileUrl);
      PostDatas.append("imgFile", this.form.imgFile);
      PostDatas.append("uploadFile", this.form.uploadFile);

      contents.update({ id: this.form.id }, PostDatas).then(a => {
        let text = this.form.title;
        this.$refs.popup.hide();
        this.$refs.tree.rename(this.form.id, text);
      });
    }
  }
};
</script>
