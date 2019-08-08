<template>
  <div />
</template>

<script>
import { picklists } from "resource";
import { alertError } from "@/functions";
export default {
  methods: {
    edit(id) {
      this.$parent.edit(id);
    },
    rename(id, name) {
      var inst = $(this.$el).jstree(true);
      var node = inst.get_node(id);
      inst.set_text(node, name);
    },
    update() {
      picklists.get().then(a => {
        $(this.$el).jstree(true).settings.core.data = a.body;
        $(this.$el)
          .jstree(true)
          .refresh();
      });
    }
  },
  mounted() {
    var self = this;
    $(this.$el)
      .jstree({
        core: {
          check_callback(op) {
            if (op === "delete_node") return confirm("確定要刪除嗎？");
          },
          themes: { variant: "small" }
        },
        plugins: ["types", "contextmenu", "dnd"],
        types: {
          "#": {
            valid_children: ["root"]
          },
          root: {
            valid_children: ["picklist"]
          },
          picklist: {
            valid_children: ["picklist"],
            icon: "fas fa-file-alt text-warning"
          }
        },
        contextmenu: {
          items: function(node) {
            var tmp = $.jstree.defaults.contextmenu.items();
            tmp.create.label = "新增";
            tmp.rename.label = "重新命名";
            tmp.remove.label = "移除";
            tmp.ccp.label = "動作";
            tmp.ccp.submenu.cut.label = "剪下";
            tmp.ccp.submenu.copy.label = "複製";
            tmp.ccp.submenu.paste.label = "貼上";
            tmp.create.action = data => {
              var inst = $.jstree.reference(data.reference),
                obj = inst.get_node(data.reference);
              inst.create_node(obj, { type: "picklist" });
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
              delete tmp.ccp.submenu.cut;
              delete tmp.ccp.submenu.copy;
            }
            return tmp;
          }
        }
      })
      .on("create_node.jstree", (a, b) => {
        let parent = b.instance.get_node(b.node.parent);
        let [text, url] = b.node.text.split(" /");
        let data = {
          title: text,
          parentId: parent.original.id,
          sequence: b.position
        };
        if (url) data.url = "/" + url;
        picklists.save(data).then(a => {
          b.node.original.id = a.body.id;
          b.instance.set_id(b.node, a.body.id);
          b.instance.edit(b.node);
        });
      })
      .on("rename_node.jstree", (a, b) => {
        let [title, url] = b.node.text.split(" /");
        let data = { title };
        if (url) data.url = "/" + url;
        picklists.rename({ id: b.node.id }, data);
      })
      .on("delete_node.jstree", (a, b) => {
        picklists.delete({ id: b.node.id });
      })
      .on("move_node.jstree", function(e, data) {
        var parent = data.instance.get_node(data.parent);
        var oldParent = data.instance.get_node(data.old_parent);
        picklists.move({
          id: data.node.id,
          parentId: parent.original.id,
          position: data.position,
          oldParentId: oldParent.original.id,
          oldPosition: data.old_position
        });
      })
      .on("copy_node.jstree", function(e, data) {
        let parent = data.instance.get_node(data.parent);
        picklists
          .copy({
            id: data.original.id,
            parentId: parent.original.id,
            position: data.position
          })
          .then(a => {
            self.update();
          })
          .catch(alertError);
      });
    this.update();
  }
};
</script>

