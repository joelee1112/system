<template>
  <div class="modal fade">
    <div class="modal-dialog modal-dialog-centered modal-80" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title">{{title}}</h5>
          <button
            type="button"
            class="close"
            data-dismiss="modal"
            aria-label="Close"  
          >
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <form @submit="submit($event)" class="form-horizontal" ref="form">
          <div class="modal-body">
            <slot></slot>
          </div>
          <div class="modal-footer">
            <button type="submit" class="btn btn-primary btn-sm">Submit</button>
            <button
              type="button"
              class="btn btn-default btn-sm"
              data-dismiss="modal"
            >Cancel</button>
          </div>
        </form>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  props: ["title"],
  mounted() {
    $(this.$refs.form).validate();
    $(this.$el).on("show.bs.modal", a => this.$emit("show"));
    $(this.$el).on("hide.bs.modal", a => this.$emit("hide"));
  },
  methods: {
    show() {
      $(this.$el).modal({ backdrop: "static", keyboard: false });
    },
    submit(e) {
      $(".loading").show();
      e.preventDefault();
      if ($(this.$refs.form).valid()) {
        this.$emit("submit");
        this.hide();
      }else{
         $(".loading").hide();
      }
    },
    hide() {
      $(this.$el).modal("hide");
    },
   
  }
};
</script>

<style>
.modal-80 {
  max-width: 80%;
}
</style>
