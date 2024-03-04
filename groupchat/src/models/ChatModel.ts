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
  
    constructor(params: Partial<ChatModel>) {
      this.groupId = params.groupId ?? 0;
      this.groupName = params.groupName ?? '';
      this.subGroupId = params.subGroupId ?? 0;
      this.subGroupName = params.subGroupName ?? '';
      this.message = params.message ?? '';
      this.messageId = params.messageId ?? 0;
      this.time = params.time ?? '';
      this.userId = params.userId ?? 0;
      this.userName = params.userName ?? '';
      this.nickName = params.nickName ?? '';
      this.userPhoto = params.userPhoto ?? '';
      this.uuid = params.uuid ?? '';
      this.isError = false;
      this.isCurrentUser = params.isCurrentUser ?? false;
    }
  }