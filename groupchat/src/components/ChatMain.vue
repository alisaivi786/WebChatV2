<template>
  <div class="group-heading">Group 1</div>
  <div class="chat-messages" ref="chatMessages" id="chatMessages">
    <template v-for="chat in chatList.slice().reverse()" :key="chat.chatId">
      <ChatItem :chat="chat" />
    </template>
    <span v-if="isLoading">Loading...</span>
    <span v-else-if="isError">Error: {{ error.message }}</span>
  </div>
  <div class="row align-items-center p-3 new-message-row">
    <div class="col-lg-12">
      <WangEditor ref="wangEditor" class="wang-editor" />
    </div>
    <div class="col-lg-12">
      <a href="#" class="btn send-message-btn" @click="sendMessage">Send</a>
    </div>
  </div>
</template>

<script>
import { defineComponent, ref } from "vue";
import { useInfiniteQuery } from "vue-query";
import * as signalR from "@microsoft/signalr";
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
      totalPage: 1,
      isLoading: false,
      isError: false,
    };
  },
  setup() {
    const totalPage = ref(1);
    const chatList = ref([]);

    const scrollToBottom = () => {
      requestAnimationFrame(() => {
        const chatMessages = document.getElementById("chatMessages");
        chatMessages.scrollTo({
          top: chatMessages.scrollHeight,
          behavior: "smooth",
        });
      });
    };

    const isUserAtBottom = () => {
      const chatMessages = document.getElementById("chatMessages");
      return (
        chatMessages.scrollHeight - chatMessages.clientHeight <=
        chatMessages.scrollTop + 1
      );
    };

    const fetchMessages = async ({ pageParam = 1 }) => {
      console.log("fetchMessages", 'pageParam', pageParam, 'totalPage', totalPage.value);
      if (pageParam > totalPage.value) return [];
      if (pageParam === 1) {
        // First page request, get all messages
        try {
          const response = await getAllMessages(pageParam);
          chatList.value = response.data.list;
          totalPage.value = response.data.totalPage;

          scrollToBottom();

          return response.data.list;
        } catch (error) {
          console.error("Error fetching messages:", error);
          return [];
        }
      } else {
        // Fetch next page
        try {
          const response = await getAllMessages(pageParam);
          chatList.value.push(...response.data.list); // Append new data to the existing list
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
          // Calculate the next page number
          return allPages.length + 1;
        },
      });
    }

    const {
      data,
      error,
      fetchNextPage,
      hasNextPage,
      isFetching,
      isFetchingNextPage,
      isLoading,
      isError,
    } = useMessagesInfiniteQuery();

    const handleScroll = () => {
      const chatMessages = document.getElementById("chatMessages");
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
      });

      console.log("messagePayload", messagePayload);

      this.chatService
        .sendMessage(messagePayload)
        .then(() => {
          this.$refs.wangEditor.valueHtml = "";
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

        const messageObj = JSON.parse(message);

        this.chatItem = new ChatModel({
          Content: messageObj.Content,
          SentTime: messageObj.SentTime,
          GroupId: messageObj.GroupId,
          Group: messageObj.Group,
          UserId: messageObj.UserId,
          User: messageObj.User,
          Id: messageObj.Id,
          DateCreated: messageObj.DateCreated,
          CreatedBy: messageObj.CreatedBy,
          DateModified: messageObj.DateModified,
          ModifiedBy: messageObj.ModifiedBy,
          IsActive: messageObj.IsActive,
        });

        this.chatList.push(this.chatItem);

        this.scrollToBottom();
      });
    });
  },
});
</script>
