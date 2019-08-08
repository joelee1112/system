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
    <popup ref="popup" title="角色內容" @submit="submit">
      <div class="form-group row">
        <label class="col-sm-3 control-label text-sm-right pt-2">
          <span class="required">*</span> 名稱
        </label>
        <div class="col-sm-9">
          <input type="text" v-model="form.name" class="form-control" required v-focus />
        </div>
      </div>
      <div class="form-group row">
        <label class="col-sm-3 control-label text-sm-right pt-2">
          <span class="required">*</span> 業管機關
        </label>
        <div class="col-sm-9">
          <checkboxlist v-model="form.authoritys" />

          <!-- <label class="form-check-inline" v-for="(item, key, index) in authoritys" :key="index">
            <input
              type="checkbox"
              name="authority"
              class="form-check-input"
              v-model="form.authoritys"
              :value="key"
            />
            {{item}}
          </label>-->
        </div>
      </div>
      <div class="form-group row">
        <label class="col-sm-3 control-label text-sm-right pt-2">功能</label>
        <div class="col-sm-9 pt-2">
          <functions ref="functions" @change="change" />
        </div>
      </div>
    </popup>
  </section>
</template>

<script>
import checkboxlist from "shared/checkboxList/cbxbaseAuthority";
import tree from "./tree";
import functions from "./functions";
import popup from "shared/popup";
import { roles, roleAuthority } from "resource";
export default {
  components: { tree, popup, functions, checkboxlist },
  data() {
    return {
      form: {
        id: null,
        name: null,
        authoritys: []
      },
      function: {
        menus: [],
        pages: [],
        operations: [],
        apis: []
      }
    };
  },
  methods: {
    edit(id) {
      roleAuthority.get({id:id}).then(a => {
        this.form.authoritys = a.body;
      });
      Promise.all([roles.get({ id: id }), roles.functions({ id: id })]).then(
        ([a, b]) => {
          Object.assign(this.form, a.body);
          Object.assign(this.function, b.body);
          this.$refs.popup.show();
          this.$refs.functions.deselectAll();
          this.$refs.functions.selection(b.body.menus);
          this.$refs.functions.selection(b.body.pages);
          this.$refs.functions.selection(b.body.operations);
          this.$refs.functions.selection(b.body.apis);
        }
      );
    },
    submit() {
      Promise.all([
        roles.update({ id: this.form.id }, this.form),
        roles.updateFunctions({ id: this.form.id }, this.function),
        roleAuthority.save(this.form)
      ]).then(a => {
        this.$refs.popup.hide();
        this.$refs.tree.rename(this.form.id, this.form.name);
        this.$parent.$refs.menu.load();
        $(".loading").hide();
      });
    },
    change(list) {
      Object.assign(this.function, list);
    }
  }
};
</script>
