<template>
    <ol class="breadcrumbs">
        <li>
            <router-link to="/">
                <i class="fa fa-home"></i>
            </router-link>
        </li>
        <li v-for="(item, index) in list" :key="item.id">
            <span v-if="item.url && index < list.length - 1">
                <router-link :to="item.url">{{item.text}}</router-link>
            </span>
            <span v-else>{{item.text}}</span>
        </li>
    </ol>
</template>

<script>
export default {
  props: ["list"]
};
</script>
