<template>
  <div class="users-list-main">
    <div class="user-item">
      <span class="chat-heading">Users</span>
    </div>
    <ul class="user-list-items">
      <template v-if="isLoading">Loading...</template>
      <template v-if="!isLoading">
        <template v-for="user in $store.state.userList" :key="user.userId">
          <UserItem :user="convertToUserModel(user)" />
        </template>
      </template>
    </ul>
    <hr>
    <ul class="loggedin-user" v-if="$store.state.loggedInUser.nickName">
      <li>
        <div class="row">
          <div class="col-md-3 text-center">
            <img
              v-bind:src="$store.state.loggedInUser.userPhoto"
              alt="User Icon"
            />
          </div>
          <div class="col-md-4 p-0">
            <span class="username">{{
              $store.state.loggedInUser.nickName
            }}</span>
            <br />
            <span class="user-online-status">
              <span class="status-active"> </span>
              Active
            </span>
          </div>
          <div class="col-md-5 dropdown dropup ml-auto text-end">
            <button
              class="btn btn-outline-primary dropdown-toggle"
              type="button"
              id="dropdownMenuButton"
              data-bs-toggle="dropdown"
              aria-expanded="false"
            >
              Options
            </button>
            <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton">
              <li><a class="dropdown-item" :href="`/user/${uuid}`">View Profile</a></li>
              <li><a class="dropdown-item" href="/">Logout</a></li>
            </ul>
          </div>
        </div>
      </li>
    </ul>
  </div>
</template>

<script>
import { defineComponent } from "vue";
import UserItem from "./UserItem.vue";
import UserModel from "../models/UserModel";

export default defineComponent({
  components: {
    UserItem,
  },
  props: {
    uuid: String,
    userId: String,
    groupId: String,
    subGroupId: String,
  },
  data() {
    return {
      usersList: [],
      isLoading: false,
      loggedInUser: UserModel,
    };
  },
  methods: {
    async getAllUsers() {
      this.isLoading = true;
      await this.$store.dispatch("fetchAllUsers", {
        subGroupId: this.subGroupId,
      });
      this.isLoading = false;
    },
    convertToUserModel(user) {
      // Assuming user is in the expected format, create a UserModel instance
      return new UserModel(
        user.userId,
        user.userName,
        user.nickName,
        user.groupId,
        user.groupName,
        user.subGroupId,
        user.subGroupName,
        user.userPhoto
      );
    },
  },
  mounted() {
    this.getAllUsers();
  },
});
</script>

<style></style>
