<template>
  <div class="layout-mgt layout-mgt-edit">
    <div class="layout-mgt-panel">
      <div>
        <div class="layout-mgt-panel-rows" v-for="(row, i) in rows" :key="i">
          <a class="btn-move text-primary">
            <i class="fa fa-arrows"></i>
          </a>
          <a class="btn-remove text-danger" v-on:click="removeRow(i)">
            <i class="fa fa-times"></i>
          </a>
          <ul v-sortable="row" class="layout-mgt-panel-controls">
            <li v-for="(item, i) in row.controls" class="layout-mgt-panel-control" :key="i">
              <label v-if="item.type=='Label'" v-on:click="edit(item, $event)">{{item.text}}</label>
              <label v-if="item.type=='TextBox'" v-on:click="edit(item, $event)"><input type="text" disabled v-bind:placeholder="item.text" /></label>
              <label v-if="item.type=='CheckBox'" v-on:click="edit(item, $event)"><input type="checkbox" disabled checked /> {{item.text}}</label>
              <label v-if="item.type=='RadioButton'" v-on:click="edit(item, $event)"><input type="radio" disabled checked /> {{item.text}}</label>
              <label v-if="item.type=='DropDownList'" v-on:click="edit(item, $event)">
                <select disabled class="form-control input-sm">
                  <option value="">{{item.text}}</option>
                </select>
              </label>
              <label v-if="item.type=='TextArea'" v-on:click="edit(item, $event)">
                <textarea disabled v-bind:placeholder="item.text"></textarea>
              </label>
            </li>
          </ul>
        </div>
      </div>
      <div class="modal fade">
        <div class="modal-dialog" role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h5 class="modal-title">{{editItem.type}}</h5>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <form @submit="submit($event)" class="form-horizontal" ref="form">
              <div class="modal-body">
                <div class="form-group row" v-for="(v, k) in editItem" v-if="!inArray(k,['type'])" :key="k">
                  <label class="col-sm-2 control-label text-sm-right pt-2" for="form-group row-input">
                    {{k}}
                    <a v-if="k=='options'" v-on:click="addOption(editItem)">
                      <i class="fa fa-plus"></i>
                    </a>
                  </label>
                  <div class="col-sm-10" v-if="!inArray(k,['options'])">
                    <input type="checkbox" v-model="editItem[k]" v-if="typeof(editItem[k])==='boolean'" />
                    <input type="text" class="form-control" v-model="editItem[k]" v-bind:placeholder="'請輸入'+k" v-else>
                  </div>
                  <div class="col-sm-10" v-else>
                    <label class="control-label text-sm-right pt-2" v-if="v.length<1">No options.</label>
                    <div class="form-group row options" v-for="(o, i) in v" :key="i">
                      <a class="btn-remove text-danger" v-on:click="removeOption(editItem, i)">
                        <i class="fa fa-times"></i>
                      </a>
                      <label class="col-sm-1 control-label text-sm-right pt-2">text</label>
                      <div class="col-sm-5">
                        <input type="text" class="form-control" placeholder="請輸入text" v-model="o.text">
                      </div>
                      <label class="col-sm-1 control-label text-sm-right pt-2">value</label>
                      <div class="col-sm-5">
                        <input type="text" class="form-control" placeholder="請輸入value" v-model="o.value">
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              <div class="modal-footer">
                <button type="button" class="btn btn-danger" v-on:click="removeControl(editItem)" data-dismiss="modal">Delete</button>
                <button type="submit" class="btn btn-default" data-dismiss="modal">Close</button>
              </div>
            </form>
          </div>
        </div>
      </div>
      <!-- /.modal -->
    </div>
    <div class="layout-mgt-tools">
      <h4>工具箱</h4>
      <ul>
        <li data-type="Label">
          <a>
            <i class="fas fa-pencil-alt"></i>Label</a>
        </li>
        <li data-type="TextBox">
          <a>
            <i class="fas fa-edit"></i>TextBox</a>
        </li>
        <li data-type="CheckBox">
          <a>
            <i class="fas fa-check-square"></i>CheckBox</a>
        </li>
        <li data-type="RadioButton">
          <a>
            <i class="far fa-dot-circle"></i>RadioButton</a>
        </li>
        <li data-type="DropDownList">
          <a>
            <i class="far fa-caret-square-down"></i>DropDownList</a>
        </li>
        <li data-type="TextArea">
          <a>
            <i class="far fa-square"></i>TextArea</a>
        </li>
      </ul>
      <div class="layout-mgt-panel-header">
        <a v-on:click="addRow" class="text-success">
          <i class="fas fa-plus"></i>Row</a>
      </div>
    </div>
  </div>
</template>
<script>
var editRowIndex, editControlIndex, self;
import { forms } from "resource";
export default {
  props: ["id", "name"],
  data: function() {
    return {
      rows: [],
      editItem: {}
    };
  },
  methods: {
    addRow: function() {
      this.rows.push({ controls: [] });
    },
    removeRow: function(i) {
      this.rows.splice(i, 1);
    },
    edit: function(item, e) {
      editControlIndex = $(e.target)
        .parent()
        .index();
      editRowIndex = $(e.target)
        .parent()
        .parent()
        .parent()
        .index();
      this.editItem = item;
      $(".modal", this.$el).modal("show");
    },
    removeControl: function(item) {
      this.rows[editRowIndex].controls.splice(editControlIndex, 1);
    },
    inArray: function(value, array) {
      return $.inArray(value, array) >= 0;
    },
    addOption: function(item) {
      item.options.push({ text: null, value: null });
    },
    removeOption: function(item, i) {
      item.options.splice(i, 1);
    }
  },
  watch: {
    rows: {
      deep: true,
      handler(a) {
        this.$emit("change", a);
      }
    }
  },
  mounted: function() {
    for (let i = 0; i < 6; i++) this.addRow();
    var el = this.$el;
    self = this;
    if (this.id) {
      forms.get({ id: this.id }).then(a => {
        self.rows = JSON.parse(a.body.value);
      });
    }
    $(".layout-mgt-tools li", el).draggable({
      connectToSortable: ".layout-mgt-panel ul",
      helper: "clone"
    });
    this.$nextTick(a => {
      $(".layout-mgt-panel-rows", el)
        .parent()
        .sortable({
          handle: ".btn-move",
          start: function(e, ui) {
            ui.item.startIndex = ui.item.index();
          },
          stop: function(e, ui) {
            var i = ui.item.index();
            var item = self.rows.splice(ui.item.startIndex, 1)[0];
            self.rows.splice(i, 0, item);
            return false;
          }
        });
    });
    $(".modal", el).on("shown.bs.modal", function() {
      $(this)
        .find("input:text:first")
        .select();
    });
    var tools = $(".layout-mgt-tools", el);
    var isFixed = false;
    $(document).scroll(function(e) {
      var top = $(this).scrollTop();
      if (top > 156 && !isFixed) {
        tools.addClass("layout-mgt-tools-fixed");
        isFixed = true;
      }
      if (top < 156 && isFixed) {
        tools.removeClass("layout-mgt-tools-fixed");
        isFixed = false;
      }
    });
  },
  directives: {
    sortable: {
      bind: function(el, binding, a, b) {
        var fromRowIndex = null,
          fromControlIndex = null;
        $(el).sortable({
          placeholder: "layout-mgt-sort-placeholder",
          connectWith: ".layout-mgt-panel-controls",
          start: function(e, ui) {
            if (!ui.item.is(".ui-draggable")) {
              fromRowIndex = ui.item
                .parent()
                .parent()
                .index();
              fromControlIndex = ui.item.index();
            }
          },
          stop: function(e, ui) {
            var item;
            var i = ui.item
              .parent()
              .parent()
              .index();
            var j = ui.item.index();
            if (fromRowIndex != null) {
              item = self.rows[fromRowIndex].controls.splice(
                fromControlIndex,
                1
              )[0];
            } else {
              var text = ui.item.text();
              var type = ui.item.data("type");
              item = { type: type };
              if (type != "Label") {
                item.name = "c" + $.now();
              }
              item.text = text;
              if ($.inArray(type, ["CheckBox", "RadioButton"]) >= 0) {
                item.value = item.name;
              }
              if (type == "DropDownList") {
                item.options = [];
              }
              if (type == "TextBox") {
                item.date = false;
              }
              if (type == "TextArea") {
                item.rows = 3;
              }
              self.edit(item, e);
            }
            self.rows[i].controls.splice(j, 0, item);
            fromRowIndex = fromControlIndex = null;
            editRowIndex = i;
            editControlIndex = j;
            if (ui.item.is(".ui-draggable")) {
              ui.item.remove();
            } else {
              return false;
            }
          }
        });
      }
    }
  }
};
</script>
<style>
.layout-mgt {
  /* background: #ccc; */
  min-height: 300px;
  position: relative;
  padding: 0;
}

.layout-mgt-panel-header {
  -moz-user-select: none;
  -ms-user-select: none;
  -webkit-user-select: none;
  user-select: none;
}

.layout-mgt-tools {
  position: absolute;
  right: 0;
  top: 0;
  background: #e0e0e0;
  padding: 0;
  width: 150px;
}

.layout-mgt-tools ul {
  list-style: none;
  padding: 0;
}

.layout-mgt-tools li {
  -moz-user-select: none;
  -ms-user-select: none;
  -webkit-user-select: none;
  user-select: none;
}

.layout-mgt-tools h4 {
  padding: 10px;
  margin: 0;
  text-align: center;
  background: #ccc;
}

.layout-mgt-tools a {
  color: #fff;
  display: block;
  padding: 5px 10px;
}

.layout-mgt-tools a:hover {
  background: #eee;
}

.layout-mgt-tools .fas,
.layout-mgt-tools .far {
  margin-right: 10px;
  width: 20px;
  text-align: right;
}

.layout-mgt-tools-fixed {
  position: fixed;
  top: 114px;
  right: 60px;
}

.layout-mgt-panel {
  /* background: #ccc; */
  height: 100%;
  margin-right: 150px;
  padding: 10px;
  padding-top: 0;
}
.layout-mgt-panel input,
.layout-mgt-panel textarea {
  background: #fff;
}
.layout-mgt-panel select {
  color: #999;
}

.layout-mgt-panel ul {
  margin: 0;
  list-style: none;
  min-height: 40px;
  background: #e0e0e0;
  padding: 0;
  margin: 5px 0 0 0;
}

.layout-mgt-panel ul:after {
  content: "";
  clear: both;
  display: block;
}

.layout-mgt-panel ul:first-child {
  margin: 0;
}

.layout-mgt-panel li {
  float: left;
  white-space: nowrap;
  line-height: 26px;
  padding: 5px 10px;
  border: 2px solid transparent;
  -moz-user-select: none;
  -ms-user-select: none;
  -webkit-user-select: none;
  user-select: none;
  color: #000;
}

.layout-mgt-panel li.layout-mgt-panel-control:hover {
  border: 2px solid #3c8dbc;
}

.layout-mgt-panel li input {
  line-height: normal;
}

.layout-mgt-panel li.layout-mgt-sort-placeholder {
  background: #ffd800;
  height: 40px;
  width: 10px;
  padding: 0;
}

.layout-mgt-panel li.ui-draggable-handle {
  padding: 0;
  line-height: normal;
  border: none;
}

.layout-mgt-panel li.ui-draggable-handle a {
  color: #000000;
  display: block;
  padding: 5px 10px;
}

.layout-mgt-panel li.ui-draggable-handle .fa {
  margin-right: 10px;
  width: 20px;
  text-align: right;
}

.layout-mgt-panel-rows {
  margin-top: 5px;
  position: relative;
  padding-left: 20px;
  padding-right: 15px;
}

.layout-mgt-panel-rows a.btn-move,
.layout-mgt-panel-rows a.btn-remove {
  position: absolute;
  left: 0;
  top: 0;
  line-height: 40px;
}

.layout-mgt-panel-rows a.btn-remove {
  left: auto;
  right: 0;
}

.layout-mgt-panel-control {
  position: relative;
}

.layout-mgt-panel-control label:after {
  content: "";
  display: block;
  height: 100%;
  width: 100%;
  /*background: #ccc;*/
  position: absolute;
  top: 0;
  left: 0;
}

.options {
  position: relative;
  padding: 0 15px 0 0;
}

.options .btn-remove {
  position: absolute;
  top: 0;
  line-height: 34px;
  right: 15px;
  z-index: 1;
}

.layout-mgt-display {
  min-height: inherit;
  background: none;
}

.layout-mgt-display .layout-mgt-panel {
  padding: 0;
  margin: 0;
  background: none;
}

.layout-mgt-display .layout-mgt-panel-rows {
  margin-top: 1px;
  padding: 0;
}

.layout-mgt-display .layout-mgt-panel li.layout-mgt-panel-control:hover {
  border: 2px solid transparent;
}

.layout-mgt-add .layout-mgt-panel ul {
  background: none;
}

.layout-mgt-add .layout-mgt-panel li {
  padding: 5px 10px 5px 0;
}

.layout-mgt-add .layout-mgt-panel select {
  color: #555;
}
</style>
