export default class ChatModel {
    groupId: number;
    groupName: string;
    message: string;
    messageId: number;
    time: string;
    userId: number;
    userName: number;
  
    constructor(
        groupId: number,
        groupName: string,
        message: string,
        messageId: number,
        time: string,
        userId: number,
        userName: number
    ) {
      this.groupId = groupId;
      this.groupName = groupName;
      this.message = message;
      this.messageId = messageId;
      this.message = message;
      this.time = time;
      this.userId = userId;
      this.userName = userName;
    }
  }