<template>
  <div class="group-heading">Group 1</div>
  <div class="chat-messages">
    <template v-for="chat in chatList" :key="chat.chatId">
      <ChatItem :chat="chat" />
    </template>
  </div>

  <div class="row new-message">
    <div class="col-md-11">
      <!-- Wang Editor -->
      <WangEditor ref="wangEditor"/>
      <!-- END - Wang Editor-->
    </div>
    <div class="col-md new-message-btn">
      <a href="#" class="btn" @click="sendMessage">Send</a>
    </div>
  </div>
</template>

<script>
import { defineComponent } from "vue";
import ChatItem from "./ChatItem.vue";
import chatList from "../models/chatList";
import ChatModel from "../models/ChatModel";
import WangEditor from "./WangEditor.vue";

export default defineComponent({
  components: {
    ChatItem,
    WangEditor
  },
  data() {
    return {
      chatList: [],
      messageContent: "",
      chatItem: ChatModel,
      editorData: "<p>Your initial content here.</p>",
    };
  },
  watch: {
    editorData(newVal) {
      this.messageContent = newVal;
    },
  },
  methods: {
    getTimeIn12HourFormat() {
      const now = new Date();
      const hours = now.getHours() % 12 || 12; // Ensure 12-hour format without leading zero
      const minutes = now.getMinutes().toString().padStart(2, "0"); // Add leading zero if needed
      const meridiem = now.getHours() >= 12 ? "PM" : "AM";

      return `${hours}:${minutes} ${meridiem}`;
    },
    handleEditorInput(value) {
      // Update editorData when the "input" event occurs
      //this.editorData = event.editor.getData();
      this.messageContent = value;
    },
    sendMessage() {
      
      console.log(this.$refs.wangEditor);

      // console.log(this.editor);
      // this.chatItem = new ChatModel();
      // this.chatItem.chatId = 1;
      // this.chatItem.userId = 1;
      // this.chatItem.userName = "Xalo";
      // this.chatItem.userStatus = "Active";
      // this.chatItem.message = this.editorData;
      // this.chatItem.timestamp = this.getTimeIn12HourFormat();

      // this.chatList.push(this.chatItem);
      // this.editorData = "";
    },
  },
  mounted() {
    this.chatList = chatList;
  },
});
</script>
