<template>
  <div class="group-heading">
    {{ $store.state.groupData.groupName }} - {{ $store.state.groupData.subGroupName }}
   <!-- Group Id : {{ groupId }} - {{ groupName }} - Sub group Id : {{ subGroupId }} - User Id : {{ userId }} -->
  </div>
  <div class="chat-messages-col">
    <div class="chat-messages" ref="chatMessages" id="chatMessages">
      <div class="chat-container" v-if="!isLoading && chatList.length == 0">
        <div class="chat-empty">No messages yet, start the conversation!</div>
      </div>
      <template v-for="(item, index) in chatList" :key="index">
        <div
          class="date-separator"
          :class="getDateClass(item)"
          v-if="isDifferentDate(index)"
        >
          {{ new Date(item.time).toDateString() }}
        </div>
        <ChatItem
          :chat="item"
          :currentUserId="$store.state.loggedInUser.userId"
          ref="messageRef"
          :id="index"
          class="chat-item"
        />
      </template>
      <div class="latest-message-caret">
        <i class="fa fa-angle-down"></i>
      </div>
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
import { useStore } from "vuex";
import { useInfiniteQuery } from "vue-query";
import { v4 as uuidv4 } from "uuid";
import ChatItem from "./ChatItem.vue";
import ChatModel from "../models/ChatModel";
import WangEditor from "./WangEditor.vue";
import { getAllMessages } from "@/services/apiService";
import { ChatHub } from "@/services/chatHub";

export default defineComponent({
  components: {
    ChatItem,
    WangEditor,
  },
  props: {
    groupId: String,
    groupName: String,
    subGroupId: String,
  },
  data() {
    return {
      chatItem: ChatModel,
      chatHub: new ChatHub(),
      connection: Object,
      totalPage: 1,
    };
  },
  setup(props) {
    const store = useStore();
    const totalPage = ref(1);
    const chatList = ref([]);
    const scrollPosition = ref(0);
    let oldChatHeight = ref(0);
    const isWindowFocused = ref(true);

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
      const formattedData = [];

      data.forEach((item) => {
        const chatModel = new ChatModel(
          item.groupId,
          item.groupName,
          item.subGroupId,
          item.subGroupName,
          item.message,
          item.messageId,
          item.time,
          item.userId,
          item.userName,
          item.nickName,
          item.userPhoto,
          item.uuid
        );

        formattedData.push(chatModel);
      });

      return formattedData;
    };

    const fetchMessages = async ({ pageParam = 1 }) => {
      if (!isWindowFocused.value) return [];

      // console.log(
      //   "fetchMessages",
      //   "pageParam",
      //   pageParam,
      //   "totalPage",
      //   totalPage.value
      // );
      // if (pageParam > totalPage.value) return [];

      oldChatHeight.value = chatMessages.scrollHeight;

      const accessToken = store.state.accessToken;

      if (pageParam === 1) {
        try {
          const response = await getAllMessages(         
            props.subGroupId,   
            "",
            pageParam,
            props.groupName,
            accessToken
          );
          chatList.value = mapToChatModel(response.data.list).reverse();
          totalPage.value = response.data.totalPage;

          setTimeout(() => {
            scrollToBottom();
          }, 100);

          return response.data.list;
        } catch (error) {
          console.error("Error fetching messages:", error);
          return [];
        }
      } else {
        try {
          const oldestMessage = getLastMessage();

          const response = await getAllMessages(    
            props.subGroupId,
            oldestMessage.uuid,
            pageParam,
            props.groupName,
            accessToken
          );
          chatList.value.unshift(
            ...mapToChatModel(response.data.list.reverse())
          );
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

      logTopVisibleElement();
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

    const logTopVisibleElement = () => {
      const container = document.getElementById("chatMessages");
      const messageElements = container.querySelectorAll(".chat-item");

      const containerTop = container.scrollTop;
      const containerBottom = containerTop + container.clientHeight;

      for (let i = 0; i < messageElements.length; i++) {
        const element = messageElements[i];
        const elementTop = element.offsetTop;
        const elementBottom = elementTop + element.offsetHeight - 90;

        if (elementBottom > containerTop && elementTop < containerBottom) {
          const currentDateClass = new Date(chatList.value[element.id].time)
            .toDateString()
            .replaceAll(" ", "-");

          const dateSeparatorElements =
            document.getElementsByClassName("date-separator");
          for (let i = 0; i < dateSeparatorElements.length; i++) {
            dateSeparatorElements[i].classList.remove("sticky-top");
          }

          const elements = document.getElementsByClassName(currentDateClass);
          for (let i = 0; i < elements.length; i++) {
            elements[i].classList.add("sticky-top");
          }

          return;
        }
      }
    };

    const addMessageToList = (messageObj) => {
      chatList.value.push(messageObj);
      scrollToBottom();
    };
    
    const getLastMessage = () => {
      if(chatList.value.length > 1)
        return chatList.value[0];
      else
        return new ChatModel();
    }

    const markChatAsFailed = (messageObj) => {
      let element = chatList.value.find(
        (item) => item.uuid === messageObj.uuid
      );

      if (element) {
        element.isError = true;
      }
    };

    return {
      handleScroll,
      chatList,
      isLoading,
      isError,
      scrollToBottom,
      addMessageToList,
      markChatAsFailed,
      isWindowFocused,
      getLastMessage,
    };
  },
  methods: {
    isDifferentDate(index) {
      if (index === 0) return true;
      const currentDate = new Date(this.chatList[index].time).toDateString();
      const prevDate = new Date(this.chatList[index - 1].time).toDateString();
      return currentDate !== prevDate;
    },
    getDateClass(item) {
      return new Date(item.time).toDateString().replaceAll(" ", "-");
    },    
    async getSubGroupDetail() {
      try {
        await this.$store.dispatch('fetchSubGroupById', this.subGroupId);
      } catch (error) {
        console.error(error);
      }
    },
    sendMessage() {
      const editorContent = this.$refs.wangEditor.valueHtml;

      if (
        this.$refs.wangEditor.editorRef.getText().trim() == "" &&
        this.$refs.wangEditor.valueHtml.indexOf("<img") < 0
      ) {
        console.error("Editor content is empty.");
        return;
      }

      const messageObj = new ChatModel(
        1, // GroupId
        this.groupName,
        this.subGroupId,
        "10 Minute", // sub group name
        editorContent,
        0, // MessageId
        new Date().toISOString(),//.replace("Z", ""), // Time
        this.$store.state.loggedInUser.userId, // UserId
        "Aymen", // Username
        "", // NickName
        "", // UserPhoto
        uuidv4(),
        true // isCurrentUser
      );
      this.addMessageToList(messageObj);

      const messagePayload = JSON.stringify({
        From: this.chatHub.connection.connectionId,
        To: "",
        Message: messageObj.message,
        GroupId: messageObj.groupId,
        GroupName: this.groupName,
        SubGroupId: messageObj.subGroupId,
        SubGroupName: messageObj.subGroupName,
        UserId: messageObj.userId,
        Time: messageObj.time,
        UUID: messageObj.uuid,
      });

      console.log("messagePayload", messagePayload);

      this.$refs.wangEditor.valueHtml = "";
      this.chatHub
        .sendMessage(messagePayload)
        .then(() => {
          //this.$refs.wangEditor.editorRef.focus();
        })
        .catch((error) => {
          this.markChatAsFailed(messageObj);
          console.error("Error sending message:", error);
        });
    },
  },
  mounted() {
    const chatMessages = this.$refs.chatMessages;
    chatMessages.addEventListener("scroll", this.handleScroll);

    this.chatHub.startConnection().then(() => {
      this.chatHub.joinGroup(this.subGroupId, this.$store.state.loggedInUser.userId.toString());

      this.chatHub.setupReceiveMessageHandler((userId, message) => {
        console.log("Received message:", message);

        const messageObj = JSON.parse(message);

        const found = this.chatList.some(
          (chat) => chat.uuid === messageObj.UUID
        );

        if (!found)
          this.addMessageToList(
            new ChatModel(
              messageObj.GroupId,
              messageObj.GroupName,
              messageObj.SubGroupId,
              messageObj.SubGroupName,
              messageObj.Message,
              messageObj.MessageId,
              messageObj.Time,
              messageObj.UserId,
              messageObj.UserName,
              messageObj.NickName,
              messageObj.UserPhoto,
              messageObj.UUID
            )
          );
      });

      this.chatHub.connection.on("ReceiveConnID", (connectionId) => {
        // Handle user connected event
        console.log("User connected:", connectionId);
      });
    });
    
    window.addEventListener("focus", () => {
        this.isWindowFocused = true;
      });

      window.addEventListener("blur", () => {
        this.isWindowFocused = false;
      });

    this.getSubGroupDetail();
  },
});
</script>
