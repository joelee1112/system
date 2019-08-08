<template>
  <section class="body-sign">
    <div class="center-sign">
      <router-link to="/" class="logo float-left mt-3">
        <img src="assets/images/logo.png" height="54" alt="Porto Admin">
      </router-link>

      <div class="panel card-sign">
        <div class="card-title-sign mt-3 text-right">
          <h2 class="title text-uppercase font-weight-bold m-0">
            <i class="fas fa-user mr-1"></i> Forget Password
          </h2>
        </div>
        <div class="card-body">
          <form @submit="submit($event)">
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
                <label class="pull-left">Email</label>
              </div>
              <div class="input-group">
                <input name="pwd" type="email" class="form-control input-lg"  v-model="email">
                <span class="input-group-append">
                  <span class="input-group-text">
                    <i class="fa fa-envelope"></i>
                  </span>
                </span>
              </div>
            </div>

            <div class="row">
              <div class="col-sm-4 offset-sm-8 text-right">
                <button type="submit" class="btn btn-primary mt-2">Submit</button>
              </div>
            </div>
          </form>
        </div>
      </div>

      <p class="text-center text-muted mt-3 mb-3">&copy; Copyright 2019. All Rights Reserved.</p>
    </div>
  </section>
</template>

<script>
import { alertError } from "@/functions";
import { authentication } from "resource";
export default {
  data: () => ({
    username: null,
    email: null
  }),
  mounted() {},
  methods: {
    submit(e) {
      e.preventDefault();
      authentication.forgetPassword(this.$data).then(a => {
        this.$router.push("/");
      }, alertError);
    }
  }
};
</script>
