<script lang="ts">
import { ref, onBeforeMount  } from "vue";
import { useStore } from 'vuex';
import UserList from "./UserList.vue";
import ChatMain from "./ChatMain.vue";

export default {
  name: "ChatHome",
  components: {
    UserList,
    ChatMain
  },
  setup() {
    const groupId = ref(new URL(window.location.href).searchParams.get("groupId") ?? "1");
    const subGroupId = ref(new URL(window.location.href).searchParams.get("subGroupId") ?? "1");
    const userId = ref(new URL(window.location.href).searchParams.get("userId") ?? "500");
    const uuid = ref(new URL(window.location.href).searchParams.get("uuid") ?? "f3b7b4fe-ca82-459b-8235-3d33757894d7");
    
    const isUserLoaded = ref(false);
    const store = useStore();

    onBeforeMount(async () => {      
      await store.dispatch('fetchAccessToken');
      await store.dispatch("fetchCurrentUserDetails", uuid.value);
      isUserLoaded.value = true;
    });

    return {
      groupId,
      subGroupId,
      userId,
      uuid,
      isUserLoaded
    };
  },
};
</script>

<template>
  <main>
    <div class="container-fluid chat-app-main">
      <div class="row" v-if="isUserLoaded">
        <div class="col-md-9 chat-main p-0">
          <ChatMain
            :groupId="groupId"
            :subGroupId="subGroupId"
          />
        </div>
        <div class="col-md-3 p-0 user-list d-md-block">
          <UserList
            :uuid="uuid"
            :userId="userId"
            :groupId="groupId"
            :subGroupId="subGroupId"
          />
        </div>
      </div>
    </div>
  </main>
</template>
