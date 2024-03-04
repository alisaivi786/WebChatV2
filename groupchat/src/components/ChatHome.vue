<script lang="ts">
import { ref, onBeforeMount } from "vue";
import { useStore } from "vuex";
import UserList from "./UserList.vue";
import ChatMain from "./ChatMain.vue";

export default {
  name: "ChatHome",
  components: {
    UserList,
    ChatMain,
  },
  setup() {
    const groupId = ref(
      new URL(window.location.href).searchParams.get("groupId") ?? "1"
    );
    const subGroupId = ref(
      new URL(window.location.href).searchParams.get("subGroupId") ?? "1"
    );
    const userId = ref(
      new URL(window.location.href).searchParams.get("userId") ?? "500"
    );
    const uuid = ref(
      new URL(window.location.href).searchParams.get("uuid") ??
        "25eed9ad-fb34-4879-8ed9-5a4caf83e5a0"
    );

    const isUserLoaded = ref(false);
    const lightsOutEnabled = ref(false);
    const store = useStore();    

    onBeforeMount(async () => {
      await store.dispatch("fetchAccessToken");
      await store.dispatch("fetchCurrentUserDetails", uuid.value);
      isUserLoaded.value = true;
    });

    return {
      groupId,
      subGroupId,
      userId,
      uuid,
      isUserLoaded,
      lightsOutEnabled,
    };
  },
};
</script>

<template>
    <div class="form-check form-switch theme-switch">
      <input
        class="form-check-input"
        type="checkbox"
        role="switch"
        id="flexSwitchCheckDefault"
        v-model="lightsOutEnabled"
      /> <span :class="{ 'text-light': lightsOutEnabled}">
        <!-- <i class="fa-solid fa-sun"></i> -->
      </span>
    </div>
    <div class="container-fluid chat-app-main" :class="{ 'dark-body': lightsOutEnabled}">
      <div class="row" v-if="isUserLoaded">
        <div class="col-md-9 chat-main p-0">
          <ChatMain :groupId="groupId" :subGroupId="subGroupId" />
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
</template>
