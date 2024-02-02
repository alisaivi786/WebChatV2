<template>  
  <li class="group-item">
      <div class="row">
        <div class="col-md group-icon">
          <img v-bind:src="group.groupIcon" alt="Group Icon" />
        </div>
        <div class="col-md group-detail">
          <span class="group-name">{{ group.groupName }}</span>
          <br />
          <div class="last-message">{{ group.lastMessage }}</div>
        </div>
        <div class="col-md group-last-chat-time">{{ group.lastMessage }}</div>
      </div>
    </li>
</template>

<script>
import { defineComponent } from "vue";

export default defineComponent({
  props: {
    group: Object,
  },
  data() {
    return {};
  },
  mounted() {},
});
</script>
