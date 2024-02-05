<template>  
  <li class="user-item">
      <div class="row">
        <div class="col-md user-icon">
          <img v-bind:src="user.userIcon" alt="user Icon" />
        </div>
        <div class="col-md user-detail">
          <span class="user-name">{{ user.userName }}</span>
          <br />
          <span class="user-online-status">
            <span class="status-active"> </span>
            Active
          </span>
        </div>
        <div class="col-md private-message">
            <a href="" class="btn">Private Message</a>
        </div>
      </div>
    </li>
</template>

<script>
import { defineComponent } from "vue";

export default defineComponent({
  props: {
    user: Object,
  },
  data() {
    return {};
  },
  mounted() {},
});
</script>
