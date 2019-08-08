<template>
  <div class="div-row">
    <div class="operater" @mouseenter="menushow" @mouseleave="menuhide">
      <i>Row</i>
      <i class="menu">
        <i class="fa fa-plus" @click="addcolumn" title="新增Columns" ></i>
        <i class="fa fa-broom" @click="clear" title="清空" ></i>
        <i class="fa fa-times" @click="remove" title="刪除" ></i>
        <i class="fa fa-arrow-circle-o-up" v-if="prevshow" @click="prev" title="上移" ></i>
        <i class="fa fa-arrow-circle-o-down" v-if="nextshow" @click="next" title="下移" ></i>
      </i>
    </div>
    <column v-for="(col, i) in row.childs" :level="level" :key="i" :width="col.width" :sort="i" :count="row.childs.length" :col="col" @ColumnChange="onColumnChange"></column>
    <div style="clear:both"></div>
  </div>
</template>

<script>
import column from "./column";
import { action } from "@/views/layouts/enum";
import { mixin } from "@/views/layouts/mixin";
export default {
  name: "row",
  mixins: [mixin],
  props: ["row","level","sort", "count"],
  components: { column },
  beforeCreate() {
    this.$options.components.column = require("./column.vue").default;
  },
  methods:{
    addcolumn: function(event) {
      this.resizewith(true);
      this.ReturnValue(action.normal);
    },
    resizewith: function(isInsert) {
      let fixcount = 0;
      let fixwidth = 0;

      /* 計算值 */
      for(let col of this.row.childs)
      {
        if (col.widthfix) 
        {
          fixcount++;
          fixwidth = parseInt(fixwidth) + parseInt(col.width);
        }
      }
      let count = (this.row.childs == null ? 0 : this.row.childs.length) - fixcount;
      let width = (100 - fixwidth) / (count + (isInsert ? 1 : 0));

      /* 重新給值 */
      for (let i = 0; i < this.row.childs.length;i++)
      {
        if (!this.row.childs[i].widthfix)
        {
          this.row.childs[i].width = width;
        }
      }

      /* 新增 */
      if (isInsert)
      {
        let newcol = this.row.childs == null ? { childs: [{childs:[]}] } : {childs:[]};
        newcol.type = 'column';
        newcol.width = width;
        newcol.widthfix = false;
        this.row.childs.push(newcol);
      }
    },
    clear: function(event){
      this.row.childs = [];
      this.ReturnValue(action.normal);
    },
    onColumnChange: function(vsort, vdata, actiontype){
      switch(actiontype)
      {
        case action.normal:
          this.row.childs[vsort] = vdata;
          break;
        case action.remove:
          this.row.childs.splice(vsort, 1);
          break;
        case action.moveprev:
          this.row.childs = this.swap(this.row.childs, vsort, vsort - 1);
          break;
        case action.movenext:
          this.row.childs = this.swap(this.row.childs, vsort, vsort + 1);
          break;
      }
      this.resizewith(false);
      this.ReturnValue(action.normal);
    },
    ReturnValue: function(actiontype){
        this.$emit((this.level == 1) ? 'ChangeData' : 'RowChange', this.sort, this.row, actiontype);
    }
  }
};
</script>
