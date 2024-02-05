<template>
  <ul class="user-list-items">
    <li class="user-item">
      <span class="chat-heading">Users</span>
    </li>
    <template v-for="user in usersList" :key="user.userId">
      <UserItem :user="user" />
    </template>
    <li class="user-item loggedin-user">
      <div class="row">
        <div class="col-md-3">
          <img v-bind:src="loggedInUser.userImage" alt="User Icon" />
        </div>
        <div class="col-md-9 p-0">
          <span class="username">{{ loggedInUser.username }}</span>
          <br />
          <span class="user-online-status">
            <span class="status-active"> </span>
            Active
          </span>
        </div>
      </div>
    </li>
  </ul>
</template>

<script>
import { defineComponent } from "vue";
import UserItem from "./UserItem.vue";
import { usersList } from "../models/usersList";

export default defineComponent({
  components: {
    UserItem,
  },
  data() {
    return {
      usersList: [],
      loggedInUser: {
        id: 1,
        username: "Pablo Escalo",
        userStatus: 1,
        userImage: "../src/assets/images/user.png",
      },
    };
  },
  mounted() {
    this.usersList = usersList;
  },
});
</script>

<style>

</style>