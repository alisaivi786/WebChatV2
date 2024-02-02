import type { ChatItem } from "./ChatItem";

const chatList: ChatItem[] = [
    {
        chatId: 1,
        userId: 1,
        userName: "Joe",
        userStatus: "active",
        message: "Hi! How are you? What about our next meeting?",
        timestamp: "12:04 PM",
    },
    {
        chatId: 2,
        userId: 2,
        userName: "Mary",
        userStatus: "active",
        message: "Hello! You wouldn’t need extensive training to be able to use Hevo",
        timestamp: "12:04 PM",
    },
    {
        chatId: 3,
        userId: 2,
        userName: "Mary",
        userStatus: "active",
        message: "Next meeting tomorrow 10:00 AM",
        timestamp: "12:04 PM",
    },
    {
        chatId: 4,
        userId: 2,
        userName: "Mary",
        userStatus: "active",
        message: "For a reliable and fault-free data migration from your applications, companies employ the use of ETL solutions like Hevo Data. While extracting and integrating several heterogeneous sources into your Data Warehouse like Amazon Redshift, Google BigQuery, Snowflake, or Firebolt is also a big task, Hevo makes everything easier using its No-Code Data Pipeline creation tools.",
        timestamp: "12:04 PM",
    },
    {
        chatId: 5,
        userId: 1,
        userName: "Joe",
        userStatus: "active",
        message: "Great! Let's discuss the next project then",
        timestamp: "12:04 PM",
    },
];

export default chatList;