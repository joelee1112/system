<template>
  <div></div>
</template>

<script>
import { groups } from "resource";
export default {
  mounted() {
    return groups.functions().then(a => {
      $(this.$el)
        .jstree({
          plugins: ["types", "checkbox"],
          core: {
            data: a.data,
            themes: {
              name: "default",
              variant: "small"
            }
          },
          sort: function(a, b) {
            let types = { menu: 1, page: 2, api: 3 };
            return types[this.get_type(a)] > types[this.get_type(b)] ? 1 : -1;
          },
          types: {
            defatul: {
              valid_children: ["menu"]
            },
            menu: {
              valid_children: ["menu", "page"],
              icon: "fa fa-folder text-warning"
            },
            page: {
              valid_children: ["page", "api"],
              icon: "fa fa-file text-primary"
            },
            api: { valid_children: [], icon: "fa fa-link text-danger" }
          }
        })
        .on("ready.jstree", (e, data) => {
          let list = data.instance.get_checked(true);
          this.emit(list);
        })
        .on("select_node.jstree deselect_node.jstree", (e, data) => {
          let list = data.instance.get_checked(true);
          this.emit(list);
        });
    });
  },
  methods: {
    deselectAll() {
      $(this.$el).jstree("close_all");
      $(this.$el).jstree("deselect_all");
    },
    selection(list) {
      var jstree = $(this.$el).jstree(true);
      list.forEach(a => {
        jstree.select_node(a);
      });
    },
    emit(list) {
      let menus = [],
        pages = [],
        apis = [];
      list.forEach(a => {
        switch (a.type) {
          case "menu":
            menus.push(a.id);
            break;
          case "page":
            pages.push(a.id);
            break;
          case "api":
            apis.push(a.id);
            break;
        }
      });
      this.$emit("change", { menus, pages, apis });
    }
  }
};
</script>
