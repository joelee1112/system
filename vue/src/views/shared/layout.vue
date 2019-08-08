<template>
  <section class="body">
    <div class="loading">
      <div class="letter-holder">
        <div class="l-1 letter">L</div>
        <div class="l-2 letter">o</div>
        <div class="l-3 letter">a</div>
        <div class="l-4 letter">d</div>
        <div class="l-5 letter">i</div>
        <div class="l-6 letter">n</div>
        <div class="l-7 letter">g</div>
        <div class="l-8 letter">.</div>
        <div class="l-9 letter">.</div>
        <div class="l-10 letter">.</div>
      </div>
    </div>
    <!-- start: header -->
    <header class="header">
      <div class="logo-container">
        <router-link to="/" class="logo">
          <img src="assets/images/logo.png" height="35" alt="Porto Admin">
        </router-link>
        <div class="d-md-none toggle-sidebar-left" data-toggle-class="sidebar-left-opened" data-target="html" data-fire-event="sidebar-left-opened">
          <i class="fas fa-bars" aria-label="Toggle sidebar"></i>
        </div>
      </div>

      <!-- start: search & user box -->
      <div class="header-right">

        <span class="separator"></span>

        <div id="userbox" class="userbox">
          <a href="#" data-toggle="dropdown">
            <figure class="profile-picture">
              <img :src="pictureUrl" class="rounded-circle">
            </figure>
            <div class="profile-info">
              <span class="name">{{name}}</span>
              <span class="role">{{systemName}}</span>
            </div>

            <i class="fa custom-caret"></i>
          </a>

          <div class="dropdown-menu">
            <ul class="list-unstyled mb-2">
              <li class="divider" v-if="system"></li>
              <li v-for="item in system" :key="item.id">
                <a role="menuitem" tabindex="-1" @click="switchSystem(item.id)"><i class="fa fa-arrow-right"></i> 切換到 {{item.text}}</a>
              </li>
              <li class="divider"></li>
              <li>
                <a role="menuitem" tabindex="-1" @click="logout">
                  <i class="fas fa-power-off"></i> Logout
                </a>
              </li>
            </ul>
          </div>
        </div>
      </div>
      <!-- end: search & user box -->
    </header>
    <!-- end: header -->
    <div class="inner-wrapper">
      <!-- start: sidebar -->
      <aside id="sidebar-left" class="sidebar-left">
        <div class="sidebar-header">
          <div class="sidebar-title">Navigation</div>
          <div class="sidebar-toggle d-none d-md-block" data-toggle-class="sidebar-left-collapsed" data-target="html" data-fire-event="sidebar-left-toggle">
            <i class="fas fa-bars" aria-label="Toggle sidebar"></i>
          </div>
        </div>
        <menus ref="menu" @update="menuUpdate" />
      </aside>
      <!-- end: sidebar -->
      <section role="main" class="content-body">
        <header class="page-header">
          <h2>{{$root.title}}</h2>

          <div class="right-wrapper text-right mr-3">
            <breadcrumbs :list="breadcrumbs" />
          </div>
        </header>
        <router-view></router-view>
      </section>
    </div>
  </section>
</template>

<script>
import signInHelper from "@/helpers/signInHelper";
import Menus from "shared/menus";
import breadcrumbs from "shared/breadcrumbs";
import { theme, panel } from "@/assets/theme";
import { authentication, my } from "resource";
import store from "@/store";
export default {
  data() {
    return {
      title: null,
      breadcrumbs: [],
      system: [],
      name: null,
      pictureUrl: "assets/images/!logged-user.jpg",
      systemName: null
    };
  },
  components: { Menus, breadcrumbs },
  methods: {
    logout() {
      authentication.signOut();
      signInHelper.signOut();
    },
    menuUpdate(list) {
      this.breadcrumbs = list;
    },
    switchSystem(id) {
      signInHelper.switch(id);
    }
  },
  mounted() {
    theme();
    panel();
    signInHelper.refreshToken();
    my.info().then(a => {
      this.name = a.body.name;
      this.systemName = a.body.systemName;
      if (a.body.pictureUrl) this.pictureUrl = a.body.pictureUrl;
    });
    my.system().then(a => {
      this.system = a.body;
    });
  },
  updated() {
    panel();
  }
};
</script>

<style>
a {
  cursor: pointer;
}
</style>
