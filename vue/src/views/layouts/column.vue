<template>
  <div class="col" :style="{width:width + '%'}" >
    <div class="item">
      <div class="operater" @mouseenter="menushow" @mouseleave="menuhide">
        <i>Columns</i>
        <i class="menu">
          <i class="fa fa-plus" @click="addrow" title="新增Rows" ></i>
          <i class="fa fa-html5" @click="addhtml" title="新增Html" ></i>
          <i class="fa fa-wrench" @click="addcom" title="新增Components" ></i>
          <i class="fa fa-arrows-h" @click="editwidth" title="編輯寬度" ></i>
          <i class="fa fa-broom" @click="clear" title="清空" ></i>
          <i class="fa fa-times" @click="remove" title="刪除" ></i>
          <i class="fa fa-arrow-circle-o-left" v-if="prevshow" @click="prev" title="左移" ></i>
          <i class="fa fa-arrow-circle-o-right" v-if="nextshow" @click="next" title="右移" ></i>
        </i>
      </div>
      <div style="clear:both"></div>
      <div class="row-item" v-for="(row, i) in col.childs" :key="i">
        <row v-if="row.type == 'row'" :level="level + 1" :sort="i" :count="col.childs.length" :row="row" @RowChange="onRowChange"></row>
        <html5 v-if="row.type == 'editor'" :level="level + 1" :sort="i" :count="col.childs.length" :row="row" @RowChange="onRowChange"></html5>
        <com v-if="row.type == 'vue'" :level="level + 1" :sort="i" :count="col.childs.length" :row="row" @RowChange="onRowChange"></com>
      </div>
    </div>
  </div>
</template>

<script>
import html from "./html5";
import com from "./com";
import { modaltype, action, rowtype } from "@/views/layouts/enum";
import { mixin } from "@/views/layouts/mixin";
export default {
  props: ["count", "col", "level", "sort", "width"],
  mixins: [mixin],
  data() {
    this.layouts = this.$root.$children[0].$children[0].$children[3].$children[0];
    return {};
  },
  beforeCreate() {
    this.$options.components.com = require("./com.vue").default;
    this.$options.components.html5 = require("./html5.vue").default;
    this.$options.components.row = require("./row.vue").default;
  },
  methods: {
    addrow: function(event) {
      this.addelement(rowtype.row);
    },
    addhtml: function() {
      this.layouts.openedit();
      this.addelement(rowtype.editor);
    },
    addcom: function() {
      this.addelement(rowtype.vue);
    },
    addelement: function(type) {
      let row = this.col.childs == null ? { childs: [{childs:[]}] } : {childs:[]};
      row.type = type;
      this.col.childs.push(row);

      this.ReturnValue(action.normal);
    },
    editwidth: function() {
      this.layouts.tempdata = this;
      this.layouts.modaltype = modaltype.width;
      this.layouts.openedit();
    },
    clear: function(event){
      this.col.childs = [];
      this.ReturnValue(action.normal);
    },
    onRowChange: function(vsort, vdata, actiontype)
    {
      switch(actiontype)
      {
        case action.normal:
          this.col.childs[vsort] = vdata;
          break;
        case action.remove:
          this.col.childs.splice(vsort, 1);
          break;
        case action.moveprev:
          this.col.childs = this.swap(this.col.childs, vsort, vsort - 1);
          break;
        case action.movenext:
          this.col.childs = this.swap(this.col.childs, vsort, vsort + 1);
          break;
      }
      this.ReturnValue(action.normal);
    },
    save: function(width) {
      this.col.width = width;
      this.col.widthfix = true;
      this.ReturnValue(action.normal);
    },
    ReturnValue: function(actiontype){
      this.$emit('ColumnChange', this.sort, this.col, actiontype);
    }
  },
  mounted() {
    this.col = this.col || {};
    this.col.childs = this.col.childs || [];
  }
};
</script>
