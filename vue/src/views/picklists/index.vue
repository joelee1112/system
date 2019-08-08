<template>
  <section class="card">
    <header class="card-header">
      <div class="card-actions">
        <a href="#" class="card-action card-action-toggle" data-card-toggle></a>
      </div>
      <h2 class="card-title">{{$root.subTitle}}</h2>
    </header>
    <div class="card-body">
      <tree ref="tree" />
    </div>
    <popup ref="popup" title="Edit picklist" @submit="submit">
      <div class="form-group row">
        <label class="col-sm-3 control-label text-sm-right pt-2">
          <span class="required">*</span>
          Title
        </label>
        <div class="col-sm-9">
          <input type="text" v-model="form.title" class="form-control" required v-focus />
        </div>
      </div>
      <div class="form-group row">
        <label class="col-sm-3 control-label text-sm-right pt-2">
          <span class="required">*</span>
          Value
        </label>
        <div class="col-sm-9">
          <input type="text" v-model="form.value" class="form-control" />
        </div>
      </div>
      <div class="form-group row">
        <label class="col-sm-3 control-label text-sm-right pt-2">
          <span class="required">*</span>
          Status
        </label>
        <div class="col-sm-9 pt-2">
          <label class="form-check-inline form-check-label"><input type="radio" class="form-check-input" name="isActive" v-model="form.isActive" :value="true" />Active</label>
          <label class="form-check-inline form-check-label"><input type="radio" class="form-check-input" name="isActive" v-model="form.isActive" :value="false" />Inactive</label>
        </div>
      </div>
    </popup>
  </section>
</template>

<script>
import tree from "./tree";
import popup from "shared/popup";
import { picklists } from "resource";
export default {
  components: { tree, popup },
  data() {
    return {
      form: {
        id: null,
        title: null,
        value: null,
        isActive: true
      }
    };
  },
  methods: {
    edit(id) {
      picklists.get({ id: id }).then(a => {
        Object.assign(this.form, Object.assign({ value: null }, a.body));
        this.$refs.popup.show();
      });
    },
    submit() {
      picklists.update({ id: this.form.id }, this.form).then(a => {
        let text = this.form.title;
        if (this.form.url) text += " " + this.form.url;
        this.$refs.popup.hide();
        this.$refs.tree.rename(this.form.id, text);
      });
    }
  }
};
</script>
