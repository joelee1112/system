<template>
  <div class="cms-layout-editor">
    <div class="operater">
        <i class="fa fa-plus" v-on:click="addrow"></i>
      </div>
    <row v-for="(row, i) in childs" :level="1" :key="i" :sort="i" :count="childs.length" :row="row" @ChangeData="onChangeData"></row>
    <modal ref="modal" @save="save" @close="close">
      <h3 slot="header">編輯</h3>
      <div slot="body">
          <ckeditor v-if="modaltype == 0" v-model="value"></ckeditor>
          <div class="form-group" v-if="modaltype == 1">
            <label class="col-sm-2 control-label">寬度</label>
            <div class="col-sm-10"><input type="text" v-model="width" class="form-control"></div>
          </div>
      </div>
    </modal>
  </div>
</template>

<script>
import { layouts } from "resource";
import row from "./row";
import modal from "./modal";
import ckeditor from "./ckeditor";
import { modaltype, action } from "./enum";
import { mixin } from "./mixin";

export default {
  props: ["id", "name"],
  name: "Layout",
  components: { row, modal, ckeditor },
  mixins: [mixin],
  data() {
    return { childs: [],
      tempdata: this,
      value: '',
      width: 0,
      modaltype: modaltype.ckeditor
    };
  },
  mounted() {
    let self = this;
    this.initial();
  },
  computed: {
    output: function () {
        return JSON.stringify(this.childs);
    }
  },
  watch: {
    childs: {
      deep: true,
      handler(a) {
        this.$emit("change", a);
      }
    }
  },
  methods: {
    save() {
      this.close();
      if (this.modaltype == modaltype.ckeditor) {
        this.tempdata.save(this.value);
      }
      else {
        this.tempdata.save(this.width);
      }
    },
    openedit() {
      this.$refs.modal.open();

      if (this.modaltype == modaltype.ckeditor) {
        if (this.tempdata.row != null)
          this.value = this.tempdata.row.value;
      }
      else {
        this.width = this.tempdata.col.width;
        this.widthfix = this.tempdata.col.widthfix;
      }
    },
    close () {
      this.$refs.modal.close();
    },
    addrow: function(event) {
      let row = this.childs == null ? { childs: [{childs:[]}], type: 'row' } : {childs:[], type: 'row'};
      this.childs.push(row);
    },
    onChangeData(vsort, vdata, actiontype) {
      switch(actiontype)
      {
        case action.normal:
          this.childs[vsort] = vdata;
          break;
        case action.remove:
          this.childs.splice(vsort, 1);
          break;
        case action.moveprev:
          this.childs = this.swap(this.childs, vsort, vsort - 1);
          break;
        case action.movenext:
          this.childs = this.swap(this.childs, vsort, vsort + 1);
          break;
      }
    },
    initial() {
      this.childs = [];
      let row = { childs: [],type: 'row' };
      this.childs.push(row);

      if (this.id) {
        layouts.get({ id: this.id }).then(a => {
          this.childs = JSON.parse(a.body.value);
        });
      }
    }
  }
};
</script>

<style lang="scss">
$padding: 7px;
.cms-layout-editor {
  * {
    box-sizing: border-box;
  }
  .row-item {
    padding-top: 10px;
  }
  .div-row,.html,.com {
    background: rgb(104, 104, 104);
    margin-top: #{$padding};
    padding: #{$padding};
    &:first-child {
      margin-top: 0;
    }
    &::after {
      content: "";
      display: block;
      clear: both;
    }
  }
  .html {
    background: rgb(255, 102, 0);
  }
  .com {
    background: rgb(110, 221, 88);
  }
  .col {
    float: left;
    padding: #{$padding};
    padding-right: 0;
    .item {
      background: rgb(158, 158, 158);
      padding: #{$padding};
      padding-top: 10px + $padding;
      //height: 100%;
    }
  }
  .menu {
    display:none;
  }
  .menu {
    .fa:hover{
      cursor: pointer;
    }
  }
  .operater {
    text-align: left;
    padding-left: #{$padding};
  }
  .operater {
    .fa-broom {
      color:rgb(219, 216, 0);
    }
    .fa-broom:hover {
      color:rgb(248, 247, 168);
    }
    .fa-times {
      color:rgb(255, 0, 0);
    }
    .fa-times:hover {
      color:rgb(248, 96, 96);
    }
    .fa-html5 {
      color:rgb(255, 102, 0);
    }
    .fa-html5:hover {
      color:rgb(255, 156, 89);
    }
    .fa-wrench {
      color:rgb(29, 80, 36);
    }
    .fa-wrench:hover {
      color:rgb(78, 134, 85);
    }
  }
  .html-value {
    text-align: left;
  }
}
</style>
