import Vue from 'vue'
import Resource from 'vue-resource'
import App from './views/App'
import router from './router'
import store from './store'
import './filters'
import './directives'

Vue.use(Resource)
Vue.config.productionTip = false
$.validator.setDefaults({ ignore: [":hidden"] });

new Vue({
  el: '#app',
  store,
  router,
  template: '<App/>',
  components: {
    App
  },
  data: {
    title: null,
    subTitle: null
  }
})
