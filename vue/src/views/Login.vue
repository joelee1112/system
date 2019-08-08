<template>
  <section class="body-sign">
    <div class="center-sign">
      <router-link to="/" class="logo float-left mt-3">
        <img src="assets/images/logo.png" height="54" alt="Porto Admin">
      </router-link>

      <div class="panel card-sign">
        <div class="card-title-sign mt-3 text-right">
          <h2 class="title text-uppercase font-weight-bold m-0">
            <i class="fas fa-user mr-1"></i> Sign In
          </h2>
        </div>
        <div class="card-body">
          <form @submit="login($event)">
            <div class="form-group mb-3" v-if="system">
              <label>System</label>
              <select v-model="systemId" class="form-control">
                <option value>請選擇</option>
                <option v-for="item in system" :key="item.id" :value="item.id">{{item.name}}</option>
              </select>
            </div>
            <div class="form-group mb-3">
              <label>Username</label>
              <div class="input-group">
                <input type="text" class="form-control input-lg" v-model="username" v-focus>
                <span class="input-group-append">
                  <span class="input-group-text">
                    <i class="fas fa-user"></i>
                  </span>
                </span>
              </div>
            </div>

            <div class="form-group mb-3">
              <div class="clearfix">
                <label class="pull-left">Password</label>
                <router-link to="/forgetPassword" class="pull-right">Forget Password</router-link>
              </div>
              <div class="input-group">
                <input name="pwd" type="password" class="form-control form-control-lg" v-model="password">
                <span class="input-group-append">
                  <span class="input-group-text">
                    <i class="fas fa-lock"></i>
                  </span>
                </span>
              </div>
            </div>

            <div class="row">
              <div class="col-sm-4 offset-sm-8 text-right">
                <button type="submit" class="btn btn-primary mt-2">Sign In</button>
              </div>
            </div>

            <span class="mt-3 mb-3 line-thru text-center text-uppercase">
              <span>or</span>
            </span>

            <div class="mb-1 text-center">
              <button class="btn btn-facebook mb-3 ml-1 mr-1" @click="fbLogin">
                Connect with
                <i class="fab fa-facebook-f"></i>
              </button>
            </div>

            <p class="text-center">
              Don't have an account yet?
              <a href="pages-signup.html">Sign Up!</a>
            </p>
          </form>
        </div>
      </div>

      <p class="text-center text-muted mt-3 mb-3">&copy; Copyright 2019. All Rights Reserved.</p>
    </div>
  </section>
</template>

<script>
import helper from "@/helpers/signInHelper";
import { alertError } from "@/functions";
import { authentication, system } from "resource";
export default {
  data: () => ({
    username: null,
    password: null,
    rememberMe: false,
    system: [],
    systemId: ""
  }),
  mounted() {
    system.get().then(a => {
      this.system = a.body;
    });
    window.fbAsyncInit = function() {
      FB.init({
        appId: "2104489519805923",
        cookie: true,
        xfbml: true,
        version: "v3.1"
      });
      FB.AppEvents.logPageView();
    };

    (function(d, s, id) {
      var js,
        fjs = d.getElementsByTagName(s)[0];
      if (d.getElementById(id)) {
        return;
      }
      js = d.createElement(s);
      js.id = id;
      js.src = "https://connect.facebook.net/en_US/sdk.js";
      fjs.parentNode.insertBefore(js, fjs);
    })(document, "script", "facebook-jssdk");
  },
  methods: {
    login(e) {
      e.preventDefault();
      authentication.signIn(this.$data).then(a => {
        helper.signIn(a.body);
      }, alertError);
    },
    fbLogin() {
      FB.login(
        a => {
          authentication
            .facebook({
              accessToken: a.authResponse.accessToken,
              systemId: this.systemId
            })
            .then(a => {
              helper.signIn(a.body);
            });
        },
        { scope: "email" }
      );
    }
  }
};
</script>
