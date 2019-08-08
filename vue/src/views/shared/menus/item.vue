<template>
  <li :class="{'nav-parent': item.children.length > 0 && item.type == 'menu', 'nav-expanded': item.isActive, 'nav-active': item.isActive}">
    <a v-if="item.type=='menu'">
      <i :class="'fa ' + (item.icon || 'fa-folder')"></i>
      <span>{{item.text}}</span>
    </a>
    <router-link v-else-if="item.url" :to="item.url">
      <i :class="'fa ' + (item.icon || 'fa-arrow-right')"></i>
      <span>{{item.text}}</span>
    </router-link>
    <a v-else>
      <i :class="'fa ' + (item.icon || 'fa-arrow-right')"></i>
      <span>{{item.text}}</span>
    </a>
    <ul class="nav nav-children" v-if="item.type == 'menu' && item.children.length > 0">
      <node v-for="child in item.children" :key="child.id" :item="child"></node>
    </ul>
  </li>
</template>

<script>
import item from "./item";
export default {
  name: "node",
  props: ["item"],
  components: { item }
};
</script>
