<template>
  <section class="panel">
    <header class="panel-heading">
      <div class="panel-actions">
        <a href="#" class="panel-action panel-action-toggle" data-panel-toggle></a>
      </div>
      <h2 class="panel-title">{{$root.subTitle}}</h2>
    </header>
    <div class="panel-body">
      <tree ref="tree" />
    </div>
    <popup ref="popup" title="角色內容" @submit="submit">
      <div class="form-group">
        <label class="col-sm-3 control-label">
          <span class="required">*</span>
          名稱
        </label>
        <div class="col-sm-9">
          <input type="text" v-model="form.name" class="form-control" required v-focus />
        </div>
      </div>
      <div class="form-group">
        <label class="col-sm-3 control-label">功能</label>
        <div class="col-sm-9 checkbox">
          <functions ref="functions" @change="change" />
        </div>
      </div>
    </popup>
  </section>
</template>

<script>
import tree from "./tree";
import functions from "./functions";
import popup from "shared/popup";
import { groups } from "resource";
export default {
  components: { tree, popup, functions },
  data() {
    return {
      form: {
        id: null,
        name: null,
        menus: [],
        pages: [],
        apis: []
      }
    };
  },
  methods: {
    edit(id) {
      groups.get({ id: id }).then(a => {
        Object.assign(this.form, a.body);
        this.$refs.popup.show();
        this.$refs.functions.deselectAll();
        this.$refs.functions.selection(a.body.menus);
        this.$refs.functions.selection(a.body.pages);
        this.$refs.functions.selection(a.body.apis);
      });
    },
    submit() {
      groups.update({ id: this.form.id }, this.form).then(a => {
        this.$refs.popup.hide();
        this.$refs.tree.rename(this.form.id, this.form.name);
        this.$parent.$refs.menu.load();
      });
    },
    change(list) {
      Object.assign(this.form, list);
    }
  }
};
</script>
