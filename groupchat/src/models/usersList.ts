import { UserItem } from "./userItem";
import userChat from "../assets/images/user-chat.jpg";
import chatIcon from "../assets/images/chat-icon.png";
import userIcon from "../assets/images/user-icon.png";

export const usersList: UserItem[] = [
    new UserItem(1, "user 1", 0, "", userChat, "11:18 AM"),
    new UserItem(2, "user 2", 0, "", chatIcon, "11:18 AM"),
    new UserItem(3, "user 3", 0, "", userIcon, "11:18 AM"),
];