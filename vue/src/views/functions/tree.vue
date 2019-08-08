<template>
  <div></div>
</template>

<script>
import { functions } from "resource";
import { alertError } from "@/functions";
export default {
  methods: {
    edit(id, type) {
      this.$parent.edit(id, type);
    },
    update() {
      this.$parent.update();
    },
    load() {
      functions.get().then(a => {
        $(this.$el).jstree(true).settings.core.data = a.body;
        $(this.$el)
          .jstree(true)
          .refresh();
      });
    }
  },
  mounted() {
    let self = this;
    $(this.$el)
      .jstree({
        plugins: ["state", "sort", "dnd", "types", "contextmenu"],
        core: {
          // data: a.body,
          check_callback(op) {
            if (op === "delete_node") return confirm("確定要刪除嗎？");
          },
          themes: {
            name: "default",
            variant: "small"
          }
        },
        sort: function(a, b) {
          let types = { menu: 1, page: 2, operation: 3, api: 4 };
          let type1 = types[this.get_type(a)];
          let type2 = types[this.get_type(b)];
          if (type1 != type2) return type1 > type2 ? 1 : -1;
        },
        contextmenu: {
          items: function(node) {
            var tmp = $.jstree.defaults.contextmenu.items();
            delete tmp.create.action;
            tmp.create.submenu = {
              menu: {
                label: "Menu",
                action: function(data) {
                  var inst = $.jstree.reference(data.reference),
                    obj = inst.get_node(data.reference);
                  inst.create_node(obj, { type: "menu" }, "last");
                }
              },
              page: {
                label: "Page",
                action: function(data) {
                  var inst = $.jstree.reference(data.reference),
                    obj = inst.get_node(data.reference);
                  inst.create_node(obj, { type: "page" }, "last");
                }
              },
              operation: {
                label: "Operation",
                action: function(data) {
                  var inst = $.jstree.reference(data.reference),
                    obj = inst.get_node(data.reference);
                  inst.create_node(obj, { type: "operation" }, "last");
                }
              },
              api: {
                label: "Api",
                action: function(data) {
                  var inst = $.jstree.reference(data.reference),
                    obj = inst.get_node(data.reference);
                  inst.create_node(obj, { type: "api" }, "last");
                }
              }
            };

            tmp.create.label = "新增";
            tmp.rename.label = "重新命名";
            tmp.remove.label = "移除";
            tmp.ccp.label = "動作";
            tmp.ccp.submenu.cut.label = "剪下";
            tmp.ccp.submenu.copy.label = "複製";
            tmp.ccp.submenu.paste.label = "貼上";

            tmp.edit = {
              label: "設定",
              separator_before: true,
              action(data) {
                var inst = $.jstree.reference(data.reference),
                  obj = inst.get_node(data.reference);
                self.edit(obj);
              }
            };

            if (this.get_type(node) === "root") {
              delete tmp.create.submenu.page;
              delete tmp.create.submenu.operation;
              delete tmp.create.submenu.api;
              delete tmp.rename;
              delete tmp.remove;
              delete tmp.edit;
              delete tmp.ccp.submenu.cut;
              delete tmp.ccp.submenu.copy;
            }
            if (this.get_type(node) === "menu") {
              delete tmp.create.submenu.operation;
              delete tmp.create.submenu.api;
            }
            if (this.get_type(node) === "page") {
              delete tmp.create.submenu.menu;
            }
            if (this.get_type(node) === "operation") {
              delete tmp.create.submenu.menu;
              delete tmp.create.submenu.page;
              delete tmp.create.submenu.operation;
            }
            if (this.get_type(node) === "api") {
              delete tmp.create;
              delete tmp.edit;
            }

            return tmp;
          }
        },
        types: {
          "#": {
            valid_children: ["root"]
          },
          root: {
            valid_children: ["menu"]
          },
          menu: {
            valid_children: ["menu", "page"],
            icon: "fas fa-folder text-warning"
          },
          page: {
            valid_children: ["page", "operation", "api"],
            icon: "fas fa-file text-primary"
          },
          operation: {
            valid_children: ["api"],
            icon: "fas fa-cog text-success"
          },
          api: { valid_children: [], icon: "fas fa-link text-danger" }
        }
      })
      .on("delete_node.jstree", function(e, data) {
        var parent = data.instance.get_node(data.node.parent);
        functions
          .delete(
            {
              id: data.node.id,
              type: data.node.type
            },
            {
              id: data.node.id,
              parentId: parent.original.id,
              parentType: parent.type
            }
          )
          .then(a => {
            self.update();
          })
          .catch(alertError);
      })
      .on("create_node.jstree", function(e, data) {
        var parent = data.instance.get_node(data.node.parent);
        functions
          .save(
            { type: data.node.type },
            {
              text: data.node.text,
              parentId: parent.original.id,
              parentType: parent.type,
              position: data.position
            }
          )
          .then(a => {
            data.node.original.id = a.body.id;
            data.instance.set_id(data.node, a.body.id);
            data.instance.edit(data.node);
            self.update();
          })
          .catch(alertError);
      })
      .on("rename_node.jstree", function(e, data) {
        var [text, url] = data.node.text.split(" /");
        functions
          .rename(
            {
              id: data.node.id,
              type: data.node.type
            },
            {
              id: data.node.id,
              text: text,
              url: url ? "/" + url : null
            }
          )
          .then(a => {
            self.update();
          })
          .catch(alertError);
      })
      .on("move_node.jstree", function(e, data) {
        var parent = data.instance.get_node(data.parent);
        var oldParent = data.instance.get_node(data.old_parent);
        functions
          .move(
            {
              id: data.node.id,
              type: data.node.type
            },
            {
              id: data.node.id,
              parentId: parent.original.id,
              parentType: parent.type,
              position: data.position,
              oldParentId: oldParent.original.id,
              oldParentType: oldParent.type,
              oldPosition: data.old_position
            }
          )
          .then(a => {
            self.update();
          })
          .catch(alertError);
      })
      .on("copy_node.jstree", function(e, data) {
        let newParent = data.instance.get_node(data.parent);
        let oldParent = data.instance.get_node(data.old_parent);
        functions
          .copy(
            {
              id: data.original.id,
              type: data.node.type
            },
            {
              id: data.original.id,
              type: data.node.type,
              parentId: newParent.original.id,
              parentType: newParent.type,
              oldParentId: oldParent.original.id,
              oldParentType: oldParent.type,
              position: data.position,
              oldPosition: data.old_position
            }
          )
          .then(a => {
            self.load();
            self.update();
          })
          .catch(alertError);
      });
    this.load();
  }
};
</script>
