import Vue from 'vue'
import moment from 'moment'

Vue.filter('dateTime', function (value) {
  if (value) {
    return moment(String(value)).format('YYYY/MM/DD hh:mm')
  }
});
