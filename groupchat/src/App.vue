<script setup lang="ts">


import GroupsList from "./components/GroupsList.vue";
import ChatMain from "./components/ChatMain.vue";
import InfiniteScroll from "./components/InfiniteScroll.vue";

</script>

<template>
  <header>
    <div class="wrapper">
    </div>
  </header>
  <main>
    <div class="container-fluid">
      <InfiniteScroll />
    </div>
    <!-- Main app code goes here -->
    <div class="container-fluid chat-app-main mt-5">
      <div class="row">
        <div class="col-md-3 group-list p-0">
          <i class="fa-solid fa-user"></i>
          <!-- <GroupsList /> -->
        </div>
        <div class="col-md-9 p-0 chat-main">
          <!-- <ChatMain /> -->
        </div>
      </div>
    </div>
  </main>
</template>
