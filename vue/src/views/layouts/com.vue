<template>
  <div class="com">
    <div class="operater" @mouseenter="menushow" @mouseleave="menuhide">
      <i>Vue</i>
      <i class="menu">
        <i class="fa fa-times" @click="remove" title="刪除" ></i>
        <i class="fa fa-arrow-alt-circle-up" v-if="prevshow" @click="prev" title="上移" ></i>
        <i class="fa fa-arrow-alt-circle-down" v-if="nextshow" @click="next" title="下移" ></i>
      </i>
    </div>
    <div class="html-value">
    </div>
  </div>
</template>

<script>
import { action } from "@/views/layouts/enum";
import { mixin } from "@/views/layouts/mixin";
export default {
  name: "com",
  props: ["row","level","sort","count"],
  mixins: [mixin],
  methods:{
    ReturnValue: function(actiontype){
        this.$emit('RowChange', this.sort, this.row, actiontype);
    }
  }
};
</script>