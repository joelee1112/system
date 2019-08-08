<template>
  <div class="modal fade" tabindex="-1" role="dialog">
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal" aria-label="Close" style="color:white;">
            <span aria-hidden="true">&times;</span>
          </button>
          <h4 class="modal-title">
            <slot name="header"></slot>
          </h4>
        </div>
        <div class="modal-body form-horizontal">
          <slot name="body"></slot>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-danger" @click="$emit('close')" data-dismiss="modal">Close</button>
          <button type="button" class="btn btn-primary" @click="$emit('save')" data-dismiss="modal">Save Changes</button>
        </div>
      </div>
      <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
  </div>
  <!-- /.modal -->
</template>
<script>
export default {
  name: "modal",
  methods: {
    open() {
      $(".modal").modal("show");
    },
    close() {
      $(".modal").modal("hide");
    }
  }
};
</script>
<style>
  .cke_contents {
    background-color: black;
  }
</style>
