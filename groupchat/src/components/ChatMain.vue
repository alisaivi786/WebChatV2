<template>
  <div class="group-heading">Group 1</div>
  <div class="chat-messages">
    <template v-for="chat in chatList" :key="chat.chatId">
      <ChatItem :chat="chat" />
    </template>
  </div>

  <div class="row new-message">
    <div class="col-md-10">
        <CKEditor />
    </div>
    <div class="col-md-2 new-message-btn">
      <a href="" class="btn">Send ></a>
    </div>
  </div>
</template>

<script>
import { defineComponent } from "vue";
import CKEditor from "./CKEditor.vue";
import ChatItem from "./ChatItem.vue";
import chatList from "../models/chatList";

export default defineComponent({
  components: {
    CKEditor,
    ChatItem,
  },
  data() {
    return {
      chatList: [],
    };
  },
  mounted() {
    this.chatList = chatList;
  },
});
</script>
