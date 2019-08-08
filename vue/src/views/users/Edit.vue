<template>
  <form class="form-horizontal" @submit="submit($event)">
    <section class="card">
      <header class="card-header">
        <div class="card-actions">
          <a href="#" class="card-action card-action-toggle" data-card-toggle></a>
        </div>
        <h2 class="card-title">{{$root.subTitle}}</h2>
      </header>
      <div class="card-body">
        <div class="form-group row">
          <label class="col-sm-3 control-label text-sm-right pt-2">暱稱 <span class="required">*</span></label>
          <div class="col-sm-9">
            <input type="text" v-model="form.name" class="form-control" required v-focus>
          </div>
        </div>
        <div class="form-group row">
          <label class="col-sm-3 control-label text-sm-right pt-2">使用者名稱</label>
          <div class="col-sm-9 pt-2">{{form.username}}</div>
        </div>
        <div class="form-group row">
          <label class="col-sm-3 control-label text-sm-right pt-2">Email</label>
          <div class="col-sm-9 pt-2">{{form.email}}</div>
        </div>
        <div class="form-group row">
          <div class="col-sm-6 row">
            <label class="col-sm-6 control-label text-sm-right pt-2">角色</label>
            <div class="col-sm-6 pt-2">
              <tree ref="tree" @change="setRoles" />
            </div>
          </div>
          <div class="col-sm-6 row">
            <label class="col-sm-3 control-label text-sm-right pt-2">群組</label>
            <div class="col-sm-9 pt-2">
              <groupTree ref="tree" @change="setGroups" />
            </div>
          </div>
        </div>
      </div>
      <footer class="card-footer text-right">
        <button class="btn btn-primary btn-sm">Submit</button>
        <button class="btn btn-default btn-sm" @click="back($event)">Cancel</button>
      </footer>
    </section>
  </form>
</template>

<script>
import { users } from "resource";
import { edit } from "mixins";
import tree from "./tree";
import groupTree from "./groupTree";
export default {
  components: { tree, groupTree },
  mixins: [edit],
  // mounted() {
  //   this.ready.then(a => {
  //     this.$refs.tree.selection(a.body.roles);
  //   });
  // },
  methods: {
    setRoles(roles) {
      this.form.roles = roles;
    },
    setGroups(groups) {
      this.form.groups = groups;
    }
  },
  data() {
    return {
      resource: users,
      form: {
        name: null,
        username: null,
        password: null,
        email: null,
        roles: [],
        groups: []
      }
    };
  }
};
</script>
