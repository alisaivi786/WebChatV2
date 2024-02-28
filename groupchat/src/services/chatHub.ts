import * as signalR from "@microsoft/signalr";

export class ChatHub {
  connection: signalR.HubConnection;

  constructor() {
    this.connection = new signalR.HubConnectionBuilder()
      .withUrl(`${import.meta.env.VITE_API_BASE_URL}/chatHub`)
      .withAutomaticReconnect()
      .build();
  }

  async startConnection() {
    try {
      await this.connection.start();
      //console.log("SignalR connection established.");
    } catch (error) {
      console.error("Error starting SignalR connection:", error);
    }
  }

  async joinGroup(subGroupId: string, userId: string) {
    try {
      await this.connection.invoke("JoinGroup", subGroupId, userId);
      console.log("Group joined successfully.");
    } catch (error) {
      console.error("Error joining the group:", error);
      throw error; // Rethrow the error for handling in the Vue component if needed
    }
  }

  setupReceiveMessageHandler(callback: (userId: number, message: any) => void) {
    this.connection.on("ReceiveMessage", callback);
  }

  async sendMessage(messagePayload: string) {
    try {
      console.log('sending message');
      if (this.connection.state !== signalR.HubConnectionState.Connected) {
        console.log('Connection not established. Trying to start connection...');
        await this.startConnection();
      }
      await this.connection.invoke("SendMessageAsync", messagePayload);
      console.log("Message sent successfully.");
    } catch (error) {
      console.error("Error sending message:", error);
      throw error;
    }
  }

  async getAllMessages() {
    // Implement fetching all messages logic
  }
}
