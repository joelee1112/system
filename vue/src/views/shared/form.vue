<template>
    <form @submit="submit">
        <slot/>
    </form>
</template>

<script>
export default {
  mounted() {
    $(this.$el).validate();
  },
  methods: {
    submit() {
      if ($(this.$el).valid()) {
        this.$emit("submit");
      }
      return false;
    }
  }
};
</script>

<style>
</style>
