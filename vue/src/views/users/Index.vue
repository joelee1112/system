<template>
  <section class="card">
    <header class="card-header">
      <div class="card-actions">
        <a href="#" class="card-action card-action-toggle" data-card-toggle=""></a>
      </div>
      <h2 class="card-title">{{$root.subTitle}}</h2>
    </header>
    <div class="card-body">
      <div class="mb-2">
        <router-link to="/users/create" class="btn btn-primary btn-sm">Add
          <i class="fa fa-plus"></i>
        </router-link>
      </div>
      <table class="table table-bordered table-striped mb-0">
        <thead>
          <tr>
            <th>名稱</th>
            <th>帳號</th>
            <th>Email</th>
            <th>建立時間</th>
            <th class="actions"></th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(item, i) in rows" :key="item.id">
            <td>{{item.name}}</td>
            <td>{{item.userName}}</td>
            <td>{{item.email}}</td>
            <td>{{item.createTime|dateTime}}</td>
            <td class="actions">
              <router-link :to="{name:'/users/edit/:id', params:{id:item.id}}" class="on-default edit-row">
                <i class="fas fa-pencil-alt"></i>
              </router-link>
              <a class="on-default remove-row" @click="remove(item.id, i)">
                <i class="fas fa-trash-alt"></i>
              </a>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  </section>
</template>

<script>
import { users } from "@/resource";
import { list } from "@/mixins";

export default {
  mixins: [list],
  data() {
    return {
      resource: users
    };
  }
};
</script>
