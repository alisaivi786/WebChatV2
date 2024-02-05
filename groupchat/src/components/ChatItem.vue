<template>
  <div class="chat-detail">
    <div class="chat-user-info">
      <span class="chat-username">{{ chat.userName }}</span>
      <span class="status-in-active"> </span>
    </div>
    <div class="chat-message" v-html="chat.message">
    </div>
    <div class="chat-date">
      <i class="fa fa-clock-o clock-icon"></i> {{ chat.timestamp }}
    </div>
  </div>
</template>

<script>
import { defineComponent } from "vue";

export default defineComponent({
  props: {
    chat: Object,
  },
  data() {
    return {};
  },
  mounted() {},
});
</script>
