export default class ChatModel {
    groupId: number;
    groupName: string;
    subGroupId: number;
    subGroupName: string;
    message: string;
    messageId: number;
    time: string;
    userId: number;
    userName: string;
    nickName: string;
    userPhoto: string;
    uuid: string;
    isError: Boolean;
    isCurrentUser: Boolean;
  
    constructor(
        groupId: number,
        groupName: string,
        subGroupId: number,
        subGroupName: string,
        message: string,
        messageId: number,
        time: string,
        userId: number,
        userName: string,
        nickName: string,
        userPhoto: string,
        uuid: string,
        isCurrentUser: Boolean
    ) {
      this.groupId = groupId;
      this.groupName = groupName;
      this.subGroupId = subGroupId;
      this.subGroupName = subGroupName;
      this.message = message;
      this.messageId = messageId;
      this.message = message;
      this.time = time;
      this.userId = userId;
      this.userName = userName;
      this.nickName = nickName;
      this.userPhoto = userPhoto;
      this.uuid = uuid;
      this.isError = false;
      this.isCurrentUser = isCurrentUser;
    }
  }