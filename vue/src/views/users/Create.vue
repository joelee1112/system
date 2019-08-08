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
          <label class="col-sm-3 control-label text-sm-right pt-2">暱稱
            <span class="required">*</span>
          </label>
          <div class="col-sm-9">
            <input type="text" v-model="form.name" class="form-control" required v-focus />
          </div>
        </div>
        <div class="form-group row">
          <label class="col-sm-3 control-label text-sm-right pt-2">使用者名稱
            <span class="required">*</span>
          </label>
          <div class="col-sm-9">
            <input type="text" v-model="form.username" class="form-control" required />
          </div>
        </div>
        <div class="form-group row">
          <label class="col-sm-3 control-label text-sm-right pt-2">密碼
            <span class="required">*</span>
          </label>
          <div class="col-sm-9">
            <input type="password" v-model="form.password" class="form-control" required />
          </div>
        </div>
        <div class="form-group row">
          <label class="col-sm-3 control-label text-sm-right pt-2">Email
            <span class="required">*</span>
          </label>
          <div class="col-sm-9">
            <input type="text" v-model="form.email" class="form-control" required />
          </div>
        </div>
        <div class="form-group row">
          <label class="col-sm-3 control-label text-sm-right pt-2">角色</label>
          <div class="col-sm-9 pt-2">
            <tree @change="setRoles" />
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
import { create } from "mixins";
import tree from "./tree";
export default {
  components: { tree },
  mixins: [create],
  methods: {
    setRoles(a) {
      this.form.roles = a;
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
        roles: []
      }
    };
  }
};
</script>
