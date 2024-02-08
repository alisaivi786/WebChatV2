export class UserItem {
    userId: number;
    userName: string;
    groupId: number;
    groupName: string;
    userIcon: string;
    timestamp: string;

    constructor(
        userId: number,
        userName: string,
        groupId: number,
        groupName: string,
        userIcon: string,
        timestamp: string,
    ) {
        this.userId = userId;
        this.userName = userName;
        this.groupId = groupId;
        this.groupName = groupName;
        this.userIcon = userIcon;
        this.timestamp = timestamp;
    }
}
