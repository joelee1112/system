<template>
  <div class="nano">
    <div class="nano-content">
      <nav id="menu" class="nav-main" role="navigation">
        <ul class="nav nav-main">
          <item v-for="item in list" :key="item.id" :item="item"></item>
        </ul>
      </nav>
    </div>
  </div>
</template>

<script>
import { my } from "@/resource";
import item from "./item";
import { menu } from "@/assets/theme";

export default {
  components: { item },
  data() {
    return {
      list: []
    };
  },
  mounted() {
    this.load();
  },
  watch: {
    $route() {
      this.update();
    }
  },
  methods: {
    load() {
      my.functions().then(a => {
        this.list = [
          {
            text: "首頁",
            url: "/",
            type: "page",
            icon: "fa-home",
            isActive: false,
            children: []
          },
          ...a.body
        ];
        this.$nextTick(menu);
        this.update();
      });
    },
    update() {
      let self = this;
      let name = this.$route.name;
      let deep = 0;
      let list = [];
      let flag = true;
      let pages = [];
      let operations = [];

      (function setActive(a, i) {
        if (!a) return false;
        let result = false;
        a.forEach(b => {
          if (["operation", "api"].includes(b.type)) return;
          b.isActive = false;
          if (b.url == (name || "/") || setActive(b.children, i + 1)) {
            result = true;
            if (deep === 0) self.$root.subTitle = b.text;
            if (deep === 1) self.$root.title = b.text;
            deep++;
            b.isActive = true;
            if (flag) list.push(b);
            if (i == 0) flag = false;
            if (operations.length < 1)
              operations = b.children.filter(c => c.type == "operation");
          }
          if (b.type == "page") pages.push(b.url);
        });
        return result;
      })(this.list, 0);

      if (!pages.includes(this.$route.name)) this.$router.push("/404");
      this.$store.commit("operations", operations);
console.log(operations)
      this.$emit("update", list.reverse());
    }
  }
};
</script>
