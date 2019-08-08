<template>
  <div />
</template>

<script>
import { roles } from "resource";
export default {
  methods: {
    edit(id) {
      this.$parent.edit(id);
    },
    rename(id, name) {
      var inst = $(this.$el).jstree(true);
      var node = inst.get_node(id);
      inst.set_text(node, name);
    }
  },
  mounted() {
    var self = this;
    roles.get().then(a => {
      $(this.$el)
        .jstree({
          core: {
            data: a.body,
            check_callback(op) {
              if (op === "delete_node") return confirm("確定要刪除嗎？");
            },
            themes: {
              name: "default",
              variant: "small"
            }
          },
          plugins: ["types", "contextmenu", "dnd"],
          types: {
            "#": {
              valid_children: ["root"]
            },
            root: {
              valid_children: ["role"]
            },
            role: {
              valid_children: ["role"],
              icon: "fas fa-users text-warning"
            }
          },
          contextmenu: {
            items: function(node) {
              var tmp = $.jstree.defaults.contextmenu.items();
              tmp.create.label = "新增";
              tmp.rename.label = "重新命名";
              tmp.remove.label = "移除";
              tmp.create.action = data => {
                var inst = $.jstree.reference(data.reference),
                  obj = inst.get_node(data.reference);
                inst.create_node(obj, { type: "role" }, "last");
              };
              tmp.edit = {
                label: "設定",
                separator_before: true,
                action(data) {
                  var inst = $.jstree.reference(data.reference),
                    obj = inst.get_node(data.reference);
                  self.edit(obj.id);
                }
              };
              if (this.get_type(node) === "root") {
                delete tmp.rename;
                delete tmp.remove;
                delete tmp.edit;
              }
              delete tmp.ccp;
              return tmp;
            }
          }
        })
        .on("create_node.jstree", (a, b) => {
          let parent = b.instance.get_node(b.node.parent);
          roles
            .save({
              name: b.node.text,
              parentId: parent.original.id,
              sequence: b.position
            })
            .then(a => {
              b.node.original.id = a.body.id;
              b.instance.set_id(b.node, a.body.id);
              b.instance.edit(b.node);
            });
        })
        .on("rename_node.jstree", (a, b) => {
          roles.rename({ id: b.node.id }, { name: b.text });
        })
        .on("delete_node.jstree", (a, b) => {
          roles.delete({ id: b.node.id });
        })
        .on("move_node.jstree", function(e, data) {
          var parent = data.instance.get_node(data.parent);
          var oldParent = data.instance.get_node(data.old_parent);
          roles.move({
            id: data.node.id,
            parentId: parent.original.id,
            position: data.position,
            oldParentId: oldParent.original.id,
            oldPosition: data.old_position
          });
        });
    });
  }
};
</script>

