import Vue from 'vue'
import router from '@/router'
import { authentication } from "resource";
export default {
  signIn(token) {
    localStorage.setItem('token', token)
    localStorage.setItem('token.time', new Date())
    router.push('/');
  },
  signOut() {
    if (this.timeout) clearTimeout(this.timeout);
    localStorage.clear();
    router.push('/logout')
  },
  refreshToken() {
    var date = new Date(localStorage.getItem("token.time"));
    if (!date) return;
    this.timeout = setTimeout(() => {
      authentication.refresh().then(a => {
        localStorage.setItem("token", a.body);
        localStorage.setItem("token.time", new Date());
        Vue.http.headers.common['Authorization'] = 'Bearer ' + a.body;
        this.refreshToken();
      });
    }, 600000 - (new Date() - date));
  },
  switch(id) {
    authentication.switch({ id: id }).then(a => {
      localStorage.setItem('token', a.body)
      location.reload();
    })
  }
}
