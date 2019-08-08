<template>
  <section class="card">
    <header class="card-header">
      <div class="card-actions">
        <a href="#" class="card-action card-action-toggle" data-card-toggle></a>
      </div>
      <h2 class="card-title">{{$root.subTitle}}</h2>
    </header>
    <div class="card-body">
      <tree />
    </div>
    <popup ref="popup" title="設定內容" @submit="submit">
      <div class="form-group row">
        <label class="col-sm-3 control-label text-sm-right pt-2">
          圖示代碼
        </label>
        <div class="col-sm-9">
          <input type="text" class="form-control" v-model="form.icon" v-focus />
        </div>
      </div>
    </popup>
  </section>
</template>

<script>
import tree from "./tree";
import popup from "shared/popup";
import { functions } from "resource";
import { alertError } from "@/functions";
export default {
  components: { tree, popup },
  data() {
    return {
      form: {
        id: null,
        icon: null
      }
    };
  },
  methods: {
    update() {
      this.$parent.$refs.menu.load();
    },
    edit(item) {
      this.$refs.popup.show();
      functions
        .get({
          id: item.id,
          type: item.type
        })
        .then(a => {
          this.form = a.body;
        });
    },
    submit() {
      functions
        .update(
          {
            id: this.form.id,
            type: this.form.type
          },
          this.form
        )
        .then(a => {
          this.update();
          this.$refs.popup.hide();
        })
        .catch(alertError);
    }
  }
};
</script>
