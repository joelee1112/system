import {
  alertError
} from '@/functions'
export default {
  mounted() {
    $(this.$el).validate();
    this.ready = this.resource.get({
      id: this.$route.params.id
    });
    this.ready.then(a => {
      Object.assign(this.form, a.body);
    });
  },
  methods: {
    submit(e) {
      e.preventDefault();
      if ($(this.$el).valid()) {
        this.resource.update({
          id: this.$route.params.id
        }, this.form).then(
          a => {
            this.$router.push("..");
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
