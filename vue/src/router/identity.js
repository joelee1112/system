import Vue from 'vue'
import router from '@/router'
export default {
  authorize() {
    router.beforeEach((to, from, next) => {
      if (to.meta.allowAnonymous === true) return next()
      if (!localStorage.getItem('token')) return next('/login')
      if (new Date() - new Date(localStorage.getItem("token.time")) >= 1200000) return next('/login')
      Vue.http.headers.common['Authorization'] = 'Bearer ' + localStorage.getItem('token')
      next()
    })
  }
}
