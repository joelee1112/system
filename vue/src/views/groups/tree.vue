<template>
  <div />
</template>

<script>
import { groups } from "resource";
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
    groups.get().then(a => {
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
            default: {
              valid_children: ["root"]
            },
            root: {
              valid_children: ["group"]
            },
            group: {
              valid_children: ["group"],
              icon: "fa fa-group text-warning"
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
                inst.create_node(obj, { type: "group" }, "last");
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
          if (b.parent.length < 10) b.parent = null;
          groups
            .save({
              name: b.node.text,
              parentId: b.parent,
              sequence: b.position
            })
            .then(a => {
              b.instance.set_id(b.node, a.body.id);
              b.instance.edit(b.node);
            });
        })
        .on("rename_node.jstree", (a, b) => {
          groups.rename({ id: b.node.id }, { name: b.text });
        })
        .on("delete_node.jstree", (a, b) => {
          groups.delete({ id: b.node.id });
        })
        .on("move_node.jstree", function(e, data) {
          var parent = data.instance.get_node(data.parent);
          var oldParent = data.instance.get_node(data.old_parent);
          if (parent.id == "#") parent.id = null;
          if (oldParent.id == "#") oldParent.id = null;
          if (parent.type == "#") parent.type = "menu";
          if (oldParent.type == "#") oldParent.type = "menu";
          groups.move({
            id: data.node.id,
            parentId: parent.type != "root" ? parent.id : null,
            position: data.position,
            oldParentId: oldParent.type != "root" ? oldParent.id : null,
            oldPosition: data.old_position
          });
        });
    });
  }
};
</script>

