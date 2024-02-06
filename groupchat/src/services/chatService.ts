import * as signalR from "@microsoft/signalr";
import { API_BASE_URL } from '../store/constants.js';

export class ChatService {
  connection: signalR.HubConnection;

  constructor() {
    this.connection = new signalR.HubConnectionBuilder()
      .withUrl(API_BASE_URL + "/chatHub")
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

  setupReceiveMessageHandler(callback: (message: any) => void) {
    this.connection.on("ReceiveMessage", callback);
  }

  async sendMessage(messagePayload: string) {
    try {
      await this.connection.invoke("SendMessageAsync", messagePayload);
      console.log("Message sent successfully.");
    } catch (error) {
      console.error("Error sending message:", error);
      throw error; // Rethrow the error for handling in the Vue component if needed
    }
  }

  async getAllMessages() {
    // Implement fetching all messages logic
  }
}
