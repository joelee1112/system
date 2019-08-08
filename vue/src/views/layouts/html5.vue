<template>
  <div class="html">
    <div class="operater" @mouseenter="menushow" @mouseleave="menuhide">
      <i>Html</i>
      <i class="menu">
        <i class="fa fa-edit" @click="open" title="開啟" ></i>
        <i class="fa fa-broom" @click="clear" title="清空" ></i>
        <i class="fa fa-times" @click="remove" title="刪除" ></i>
        <i class="fa fa-arrow-circle-o-up" v-if="prevshow" @click="prev" title="上移" ></i>
        <i class="fa fa-arrow-circle-o-down" v-if="nextshow" @click="next" title="下移" ></i>
      </i>
    </div>
    <div class="html-value" v-html="value"></div>    
  </div>
</template>

<script>
import { modaltype, action } from "@/views/layouts/enum";
import { mixin } from "@/views/layouts/mixin";
export default {
  name: "html5",
  mixins: [mixin],
  props: ["row", "level", "sort", "count"],
  data() {
    this.layouts = this.$root.$children[0].$children[0].$children[3].$children[0];
    return {
      value: this.row.value,
    };
  },
  created() {
    this.layouts.tempdata = this;
    this.layouts.modaltype = modaltype.ckeditor;
  },
  methods: {
    save(txt) {
      this.row.value = txt;
      this.value = txt;
      this.ReturnValue(action.normal);
    },
    clear: function() {
      this.value = "";
      this.row.value = "";
      this.ReturnValue(action.normal);
    },
    open: function() {
      this.layouts.tempdata = this;
      this.layouts.modaltype = modaltype.ckeditor;
      this.layouts.openedit();
    },
    ReturnValue: function(actiontype) {
      this.$emit("RowChange", this.sort, this.row, actiontype);
    }
  }
};
</script>