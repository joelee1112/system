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
          <label class="col-sm-3 control-label text-sm-right pt-2">名稱
            <span class="required">*</span>
          </label>
          <div class="col-sm-9">
            <input type="text" v-model="form.title" class="form-control" required v-focus />
          </div>
        </div>
        <editor @change="change" :id="$route.params.id" />
      </div>
      <footer class="card-footer text-right">
        <button class="btn btn-primary btn-sm">Submit</button>
        <button class="btn btn-default btn-sm" @click="back($event)">Cancel</button>
      </footer>
    </section>
  </form>
</template>

<script>
import { forms } from "resource";
import { edit } from "mixins";
import editor from "./editor";
export default {
  mixins: [edit],
  components: { editor },
  data() {
    return {
      resource: forms,
      form: {
        title: null
      }
    };
  },
  methods: {
    change(a) {
      this.form.value = JSON.stringify(a);
    }
  }
};
</script>
