export default class ChatModel {
    chatId: number;
    userId: number;
    userName: string;
    userStatus: string;
    message: string;
    timestamp: string;
  
    constructor(
      chatId: number,
      userId: number,
      userName: string,
      userStatus: string,
      message: string,
      timestamp: string
    ) {
      this.chatId = chatId;
      this.userId = userId;
      this.userName = userName;
      this.userStatus = userStatus;
      this.message = message;
      this.timestamp = timestamp;
    }
  }