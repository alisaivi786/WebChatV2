<template>
  <div v-if="chat" class="chat-detail-new" :class="[chat.isError ? 'chat-error' : '', chat.userId == currentUserId ? 'current-user' : '']">
    <div class="chat-user-img">
      <img v-if="!chat.userPhoto" src="../assets/images/default-user2.png" />
      <img v-if="chat.userPhoto" v-bind:src="chat.userPhoto" alt="user Icon" />
    </div>
    <div>
      <div class="chat-user-info">
        <span class="chat-username">{{ chat.nickName ?? "<no name>" }} </span>
        <!-- <span class="status-in-active"> </span> -->
      </div>
      <div class="chat-message" v-html="chat.message"></div>
      <div class="chat-date">
        <span v-if="chat.isError">Not sent - </span>
        {{ getTimeIn12HourFormat(convertToLocalDateTime(chat.time)) }}
      </div>
    </div>
  </div>
</template>

<script>
import { defineComponent } from "vue";
import ChatModel from "../models/ChatModel";

export default defineComponent({
  props: {
    chat: ChatModel,
    currentUserId: Number
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
    convertToLocalDateTime(datetime) {
      datetime += datetime.indexOf('Z') < 0 ? 'Z' : '';

      return new Date(datetime);
    }
  },
  mounted() {},
});
</script>
