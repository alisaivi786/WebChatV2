<template>
  <div class="group-heading">Group 1</div>
  <div class="chat-messages-col">
    <div class="chat-messages" ref="chatMessages" id="chatMessages">
      <template v-for="chat in chatList.slice().reverse()" :key="chat.chatId">
        <ChatItem :chat="chat" ref="messageRef" />
      </template>
      <span v-if="isLoading">Loading...</span>
      <span v-else-if="isError">Error: {{ error }}</span>
    </div>
    <div class="row align-items-center p-3 new-message-row">
      <div class="col-lg-12">
        <WangEditor ref="wangEditor" class="wang-editor" />
      </div>
      <div class="col-lg-12">
        <button class="btn send-message-btn" @click="sendMessage">Send</button>
      </div>
    </div>
  </div>
</template>

<script>
import { defineComponent, ref } from "vue";
import { useInfiniteQuery } from "vue-query";
import ChatItem from "./ChatItem.vue";
import ChatModel from "../models/ChatModel";
import WangEditor from "./WangEditor.vue";
import { getAllMessages } from "@/services/apiService";
import { ChatService } from "@/services/chatService";

export default defineComponent({
  components: {
    ChatItem,
    WangEditor,
  },
  data() {
    return {
      chatItem: ChatModel,
      chatService: new ChatService(),
      connection: Object,
      totalPage: 1
    };
  },
  setup() {
    const totalPage = ref(1);
    const chatList = ref([]);
    const scrollPosition = ref(0);
    let oldChatHeight = ref(0);

    const scrollToBottom = () => {
      requestAnimationFrame(() => {
        const chatMessages = document.getElementById("chatMessages");
        chatMessages.scrollTo({
          top: chatMessages.scrollHeight,
          behavior: "auto",
        });
      });
    };

    const scrollToPosition = () => {
      requestAnimationFrame(() => {
        const chatMessages = document.getElementById("chatMessages");
        chatMessages.scrollTo({
          top: chatMessages.scrollHeight - oldChatHeight.value,
          behavior: "auto",
        });
      });
    };

    const mapToChatModel = (data) => {
      return data.map((item) => {
        return new ChatModel(
          item.groupId,
          item.groupName,
          item.message,
          item.messageId,
          item.time,
          item.userId,
          item.userName
        );
      });
    };

    const fetchMessages = async ({ pageParam = 1 }) => {
      console.log(
        "fetchMessages",
        "pageParam",
        pageParam,
        "totalPage",
        totalPage.value
      );
      if (pageParam > totalPage.value) return [];

      oldChatHeight.value = chatMessages.scrollHeight;

      if (pageParam === 1) {
        try {
          const response = await getAllMessages(pageParam);
          chatList.value = mapToChatModel(response.data.list);
          totalPage.value = response.data.totalPage;

          scrollToBottom();

          return response.data.list;
        } catch (error) {
          console.error("Error fetching messages:", error);
          return [];
        }
      } else {
        try {
          const response = await getAllMessages(pageParam);
          chatList.value.push(...response.data.list);
          scrollToPosition(scrollPosition.value);
          return response.data.list;
        } catch (error) {
          console.error("Error fetching next page:", error);
          return [];
        }
      }
    };

    function useMessagesInfiniteQuery() {
      return useInfiniteQuery("messages", fetchMessages, {
        getNextPageParam: (lastPage, allPages) => {
          return allPages.length + 1;
        },
      });
    }

    const {
      fetchNextPage,
      hasNextPage,
      isFetchingNextPage,
      isLoading,
      isError,
    } = useMessagesInfiniteQuery();

    const handleScroll = () => {
      const chatMessages = document.getElementById("chatMessages");
      scrollPosition.value = chatMessages.scrollTop;
      if (
        chatMessages.scrollTop === 0 &&
        !isFetchingNextPage.value &&
        hasNextPage.value
      ) {
        fetchNextPage.value();
        window.scrollTo({
          top: 50,
          behavior: "smooth",
        });
      }
    };

    return { handleScroll, chatList, isLoading, isError, scrollToBottom };
  },
  methods: {
    addMessageToList(messageObj) {
      this.chatItem = new ChatModel(
        messageObj.GroupId,
        messageObj.GroupName,
        messageObj.Message,
        messageObj.MessageId,
        messageObj.Time,
        messageObj.UserId,
        messageObj.UserName
      );

      this.chatList.unshift(this.chatItem);

      this.scrollToBottom();
    },
    sendMessage() {
      const editorContent = this.$refs.wangEditor.valueHtml;

      if (!editorContent) {
        console.error("Editor content is empty.");
        return;
      }

      const messagePayload = JSON.stringify({
        From: this.chatService.connection.connectionId,
        To: "",
        Message: editorContent,
        GroupId: 1,
        GroupName: "TB-Admin",
        TimeUTC: new Date(Date.now()).toISOString(),
      });

      console.log("messagePayload", messagePayload);

      const messageObj = Object;
      messageObj.GroupId = 1;
      messageObj.GroupName = "TB-Admin";
      messageObj.Message = editorContent;
      messageObj.MessageId = 0;
      messageObj.Time = new Date().toISOString().replace("Z", "");
      messageObj.UserId = 1;
      messageObj.UserName = "Aymen";

      this.addMessageToList(messageObj);

      this.chatService
        .sendMessage(messagePayload)
        .then(() => {
          this.$refs.wangEditor.valueHtml = "";
          //this.$refs.wangEditor.editorRef.focus();
        })
        .catch((error) => {
          console.error("Error sending message:", error);
        });
    },
  },
  mounted() {
    const chatMessages = this.$refs.chatMessages;
    chatMessages.addEventListener("scroll", this.handleScroll);

    this.chatService.startConnection().then(() => {
      this.chatService.setupReceiveMessageHandler((message) => {
        console.log("Received message:", message);

        // const messageObj = JSON.parse(message);
        // this.addMessageToList(messageObj);
      });
    });
  },
});
</script>
