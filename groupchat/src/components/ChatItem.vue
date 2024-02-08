<template>
  <div class="chat-detail">
    <div class="chat-user-info">
      <span class="chat-username">{{ chat.userName }}</span>
      <span class="status-in-active"> </span>
    </div>
    <div class="chat-message" v-html="chat.message"></div>
    <div class="chat-date">
      <i class="fa fa-clock-o clock-icon"></i>
      {{ getTimeIn12HourFormat(chat.time) }}
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
  methods: {
    getTimeIn12HourFormat(datetime) {
      const date = new Date(datetime);
      const hours = date.getHours() % 12 || 12; // Ensure 12-hour format without leading zero
      const minutes = date.getMinutes().toString().padStart(2, "0"); // Add leading zero if needed
      const meridiem = date.getHours() >= 12 ? "PM" : "AM";

      return `${hours}:${minutes} ${meridiem}`;
    },
    convertTime(datetime) {
      //console.log('datetime', datetime)
      const timestamp = datetime;
      const utcTimestamp = new Date(timestamp).toISOString();
      const date = utcTimestamp;

      const options = {
        timeZone: Intl.DateTimeFormat().resolvedOptions().timeZone,
        // You can specify other options here, such as dateStyle, timeStyle, etc.
      };

      const localTimestamp = date.toLocaleString(undefined, options);
      
      return localTimestamp;
    },
  },
  mounted() {},
});
</script>
