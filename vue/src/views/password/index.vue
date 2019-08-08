<template>
  <section class="panel">
    <form class="form-horizontal" @submit="submit($event)">
      <header class="panel-heading">
        <div class="panel-actions">
          <a href="#" class="panel-action panel-action-toggle" data-panel-toggle></a>
        </div>

        <h2 class="panel-title">{{$root.subTitle}}</h2>
      </header>
      <div class="panel-body">
        <div class="form-group">
          <label class="col-sm-3 control-label">舊密碼</label>
          <div class="col-sm-9">
            <input
              type="password"
              class="form-control"
              pattern="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,30}"
              v-model="password"
              required
            >
          </div>
        </div>
        <div class="form-group">
          <label class="col-sm-3 control-label">新密碼</label>
          <div class="col-sm-9">
            <input
              id="newPassword"
              type="password"
              class="form-control"
              placeholder="(請輸入8~30數字、大小寫英文及符號)"
              pattern="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,30}"
              v-model="newPassword"
              required
            >
          </div>
        </div>
        <div class="form-group">
          <label class="col-sm-3 control-label">確認新密碼</label>
          <div class="col-sm-9">
            <input
              id="passwordConfirm"
              type="password"
              class="form-control"
              placeholder="(請輸入8~30數字、大小寫英文及符號)"
              pattern="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,30}"
              v-model="confirmPassword"
              @change="passwordConfirm(confirmPassword)"
              required
            >
          </div>
        </div>
      </div>
      <footer class="panel-footer">
        <div class="row">
          <div class="col-sm-9 col-sm-offset-3">
            <button class="btn btn-primary">Submit</button>
          </div>
        </div>
      </footer>
    </form>
  </section>
</template>

<script>
import { alertError } from "@/functions";
import { password } from "resource";
export default {
  data() {
    return {
      password: null,
      newPassword: null,
      confirmPassword: null
    };
  },
  methods: {
    passwordConfirm(val) {
      var password = $("#newPassword"),
        passwordConfirm = document.getElementById("passwordConfirm");
      if (password.val() != val)
        passwordConfirm.setCustomValidity("密碼和確認密碼不相符");
      else passwordConfirm.setCustomValidity("");
    },
    submit(e) {
      e.preventDefault();
      password.update(this.$data).then(a => {
        alert("修改成功!");
        this.$router.push("/");
      }, alertError);
    }
  }
};
</script>
