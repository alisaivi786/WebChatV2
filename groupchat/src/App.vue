<script setup lang="ts">


import UserList from "./components/UserList.vue";
import ChatMain from "./components/ChatMain.vue";
import InfiniteScroll from "./components/InfiniteScroll.vue";

</script>

<template>
  <header>
    <div class="wrapper">
    </div>
  </header>
  <main>
    <!-- <div class="container-fluid">
      <InfiniteScroll />
    </div> -->
    <!-- Main app code goes here -->
    <div class="container-fluid chat-app-main mt-5">
      <div class="row">
        <div class="col-md-9 chat-main p-0">
          <ChatMain />
        </div>
        <div class="col-md-3 p-0 user-list">
          <UserList />
        </div>
      </div>
    </div>
  </main>
</template>