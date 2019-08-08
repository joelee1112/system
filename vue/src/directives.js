import Vue from 'vue'

Vue.directive('focus', {
  inserted(el) {
    $(el).attr('autofocus', true);
    el.focus()
  }
})

Vue.directive('modalFocus', {
  inserted(el) {
    $(el).on('show.bs.modal', a => {
      setTimeout(() => {
        $(el).find('[autofocus]')[0].focus();
      }, 500);
    })
  }
})

Vue.directive('date', {
  bind(el) {
    $(el).datepicker({
      format: 'yyyy/mm/dd'
    });
  }
})
