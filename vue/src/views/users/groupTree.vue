<template>
  <div></div>
</template>

<script>
import { users } from "resource";
export default {
  // methods: {
  //   selection(list) {
  //     this.ready.then(a => {
  //       setTimeout(() => {
  //         var jt = $(this.$el).jstree(true);
  //         list.forEach(a => {
  //           jt.select_node(a);
  //         });
  //       }, 1000);
  //     });
  //   }
  // },
  mounted() {
    var self = this;
    users.groups({ id: this.$route.params.id }).then(a => {
      var tree = $(this.$el)
        .jstree({
          plugins: ["types", "checkbox"],
          core: {
            data: a.body,
            themes: {
              name: "default",
              variant: "small"
            }
          },
          types: {
            default: {
              icon: "fa fa-group text-warning"
            }
          },
          checkbox: {
            three_state: false
          }
        })
        .on("ready.jstree", (e, data) => {
          let list = data.instance.get_checked(null, tree);
          self.$emit("change", list);
        })
        .on("select_node.jstree deselect_node.jstree", (e, data) => {
          let list = data.instance.get_checked(null, tree);
          self.$emit("change", list);
        });
    });
  }
};
</script>
