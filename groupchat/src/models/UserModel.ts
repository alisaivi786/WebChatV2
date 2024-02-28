export default class UserModel {
    groupId: number;
    groupName: string;
    nickName: string;
    subGroupId: number;
    subGroupName: string;
    userId: number;
    userName: string;
    userPhoto: string;

    constructor(
        groupId: number,
        groupName: string,
        nickName: string,
        subGroupId: number,
        subGroupName: string,
        userId: number,
        userName: string,
        userPhoto: string
    ) {
        this.groupId = groupId;
        this.groupName = groupName;
        this.nickName = nickName;
        this.subGroupId = subGroupId;
        this.subGroupName = subGroupName;
        this.userId = userId;
        this.userName = userName;
        this.userPhoto = userPhoto;
    }
}
