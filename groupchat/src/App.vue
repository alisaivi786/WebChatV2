<script setup lang="ts">
  import UserList from "./components/UserList.vue";
  import ChatMain from "./components/ChatMain.vue";
</script>

<template>
  <main>
    <div class="container-fluid chat-app-main">
      <div class="row">
        <div class="col-md-9 chat-main p-0">
          <ChatMain />
        </div>
        <div class="col-md-3 p-0 user-list d-md-block">
          <UserList />
        </div>
      </div>
    </div>
  </main>
</template>
