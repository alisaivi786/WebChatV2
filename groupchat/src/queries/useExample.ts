import { ref } from "vue";
import { useQuery } from "@tanstack/vue-query";

const peopleFetcher = async (page: Ref<number>) => {
    const response = await fetch(
        `https://randomuser.me/api/?page=${page.value}&results=20&seed=abc`
    );
    const data = await response.json();

    // fake delay
    await new Promise((resolve) => {
        setTimeout(() => resolve(true), 1000);
    });
    return data?.results || [];
};

const page = ref(1);
const { isLoading, isError, data, error, isFetching, isPreviousData } =
    useQuery({
        queryKey: ["people", page],
        queryFn: () => peopleFetcher(page),
        keepPreviousData: true,
    });

const nextPage = () => {
    if (!isPreviousData.value) {
        page.value = page.value + 1;
    }
};

const prevPage = () => {
    page.value = Math.max(page.value - 1, 1);
};

