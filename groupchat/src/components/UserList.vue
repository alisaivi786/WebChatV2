<template>
  <div class="users-list-main">
    <div class="user-item">
      <span class="chat-heading">Users</span>
    </div>
    <div class="d-flex justify-content-center" v-if="isLoading">
      <div class="spinner-border text-primary" role="status">
        <span class="visually-hidden">Loading...</span>
      </div>
    </div>
    <ul class="user-list-items">
      <template v-if="!isLoading">
        <template v-for="user in $store.state.userList" :key="user.userId">
          <template v-if="$store.state.loggedInUser.userId != user.userId">
            <UserItem :user="convertToUserModel(user)" />
          </template>
        </template>
      </template>
    </ul>
    <hr />
    <ul class="loggedin-user" v-if="$store.state.loggedInUser.nickName">
      <li>
        <div class="row">
          <div class="col-xl-3 text-center">
            <img
              v-bind:src="$store.state.loggedInUser.userPhoto"
              alt="User Icon"
            />
          </div>
          <div class="col-xl-4 p-0 text-center">
            <span class="username">{{
              $store.state.loggedInUser.nickName
            }}</span>
            <br />
            <span class="user-online-status">
              <span class="status-active"> </span>
              Active
            </span>
          </div>
          <div class="col-xl-5 dropdown dropup ml-auto text-center">
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
              <li>
                <a class="dropdown-item" :href="`/user/${uuid}`"
                  >View Profile</a
                >
              </li>
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
