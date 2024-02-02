<template>
  <div>
    {{ users ? users.pages[0].results.length : "no data" }}
    <div v-if="users">
      <ul>
        <li v-for="user in users.pages[0].results" :key="user.id.value">
          <img :src="user.picture.thumbnail" alt="user thumbnail" />
          <p>{{ user.name.first }} {{ user.name.last }}</p>
        </li>
      </ul>
      <div ref="infiniteScrollTrigger" class="infinite-scroll-trigger"></div>
    </div>
  </div>
</template>

<script>
import { useInfiniteQuery } from "vue-query";
import { ref, onMounted, watch, watchEffect  } from "vue";

export default {
  name: "InfiniteScroll",
  setup() {
    const currentPage = ref(1);
    const infiniteScrollTrigger = ref(null);
    const fetchNextPageFunction = ref(null);

    const {
      data: users,
      fetchNextPage,
      hasNextPage,
      isFetchingNextPage,
    } = useInfiniteQuery(
      "users",
      async ({ pageParam = 1 }) => {
        const response = await fetch(
          `https://randomuser.me/api/?page=${pageParam}&results=20&seed=abc`
        );
        return response.json();
      },
      {
        getNextPageParam: (lastPage, allPages) => {
          return allPages.length + 1;
        },
      }
    );

    console.log("users 1111", users);

    const infiniteScrollHandler = () => {
      console.log("infiniteScrollHandler");
      if (hasNextPage.value && !isFetchingNextPage.value) {
        console.log("fetching");
        fetchNextPage.value();
      }
    };

    onMounted(() => {
      console.log('mounted');
    });

    watchEffect(() => {
      console.log("fetched");
      if (infiniteScrollTrigger.value) {
        const observer = new IntersectionObserver(
          (entries) => {
            if (entries[0].isIntersecting) {
              infiniteScrollHandler();
            }
          },
          { threshold: 1 }
        );
        observer.observe(infiniteScrollTrigger.value);
      }
    });


    console.log(users);
    return { users, infiniteScrollTrigger };
  },
};
</script>
