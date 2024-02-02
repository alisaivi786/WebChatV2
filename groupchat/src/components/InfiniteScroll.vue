<template>
  <span v-if="isLoading">Loading...</span>
  <span v-else-if="isError">Error: {{ error.message }}</span>
  <div v-else>
    <span v-if="isFetching && !isFetchingNextPage">Fetching...</span>
    <ul v-for="(group, index) in data.pages" :key="index">
      <li v-for="user in group.results" :key="user.login.uuid">
        <img :src="user.picture.thumbnail" alt="user thumbnail" />
        <p>{{ user.name.first }} {{ user.name.last }}</p>
      </li>
    </ul>
  </div>
</template>


<script setup>
import { onMounted } from "vue";
import { useInfiniteQuery } from "vue-query";

const fetchProjects = async ({ pageParam = 1 }) => {
  const response = await fetch(`https://randomuser.me/api/?page=${pageParam}&results=20&seed=abc`);
  if (!response.ok) {
    throw new Error('Failed to fetch projects');
  }
  return response.json();
};

function useProjectsInfiniteQuery() {
  return useInfiniteQuery("projects", fetchProjects, {
    getNextPageParam: (lastPage) => lastPage.info.page + 1,
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
} = useProjectsInfiniteQuery();

const handleScroll = () => {
 // console.log('handleScroll', window.innerHeight + window.scrollY, document.body.offsetHeight, !isFetchingNextPage);
  if (window.innerHeight + window.scrollY >= document.body.offsetHeight && !isFetchingNextPage.value &&  hasNextPage) {
    //console.log('isFetchingNextPage', isFetchingNextPage.value);
    fetchNextPage.value();
  }
};

onMounted(() => {
  window.addEventListener("scroll", handleScroll);
});

</script>