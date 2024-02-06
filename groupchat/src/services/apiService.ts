import { API_BASE_URL } from '../store/constants.js';

export async function getAllMessages(pageParam) {
    const url = API_BASE_URL + "/api/Message/GetMessages"; // Replace URL with your actual API endpoint
    const requestBody = {
      timestamp: 9999999999,
      random: "stringstringstringstringstringst",
      signature: "string",
      pageSize: 20,
      pageNo: pageParam
    };
  
    try {
      const response = await fetch(url, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(requestBody),
      });
  
      if (!response.ok) {
        throw new Error(`Failed to fetch messages: ${response.statusText}`);
      }
  
      const data = await response.json();
      return data; // Return the fetched data
    } catch (error) {
      throw new Error(`Error fetching messages: ${error.message}`);
    }
  }
  