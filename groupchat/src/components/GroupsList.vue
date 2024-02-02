<template>
  <ul class="group-list-items">
    <li class="group-item">
      <span class="chat-heading">Chats</span>
    </li>
    <template v-for="group in groupsList" :key="group.groupId">
      <GroupItem :group="group" />
    </template>
    <li class="group-item loggedin-user">
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
import GroupItem from "./GroupItem.vue";
import { groupsList } from "../models/groupsList";

export default defineComponent({
  components: {
    GroupItem,
  },
  data() {
    return {
      groupsList: [],
      loggedInUser: {
        id: 1,
        username: "Pablo Escalo",
        userStatus: 1,
        userImage: "../src/assets/images/user.png",
      },
    };
  },
  mounted() {
    this.groupsList = groupsList;
  },
});
</script>
