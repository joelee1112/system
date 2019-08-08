import {
  alertError
} from '@/functions'
export default {
  mounted() {
    $(this.$el).validate();
  },
  methods: {
    submit(e) {
      e.preventDefault();
      if ($(this.$el).valid()) {
        this.resource.save(this.form).then(
          a => {
            this.$router.push(".");
          }, alertError
        );
      }
    },
    back(e) {
      e.preventDefault();
      this.$router.go(-1);
    }
  }
}
