<template>  
  <li class="user-item">
      <div class="row">
        <div class="col-lg-3 user-icon">
          <img v-bind:src="user.userPhoto" alt="user Icon" />
        </div>
        <div class="col-lg-7 user-detail">
          <span class="user-name">{{ user.nickName }}</span>
          <br />
          <span class="user-online-status">
            <span class="status-active"> </span>
            Active
          </span>
        </div>
        <div class="col-lg-2 private-message">
            <a href="#" class="btn"><i class="fas fa-paper-plane" title="Send Message"></i></a>
        </div>
      </div>
    </li>
</template>

<script>
import { defineComponent } from "vue";
import UserModel from "../models/UserModel";

export default defineComponent({
  props: {
    user: UserModel,
  },
  data() {
    return {};
  },
  mounted() {},
});
</script>
