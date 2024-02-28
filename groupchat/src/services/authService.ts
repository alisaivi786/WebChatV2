export async function getAuthAccessToken(userId: string, userName: string, password: string,groupId: string,subGroupId: string) {
    const url = `${import.meta.env.VITE_API_BASE_URL}/api/${import.meta.env.VITE_API_VERSION}/Auth/AccessToken`; 
    const requestBody = {
      userName: userName,
      userId: userId,
      password: password,
      groupId: 1,
      subGroupId : 1

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
        throw new Error(`Failed to fetch token: ${response.statusText}`);
      }
  
      const data = await response.json();
      return data; // Return the fetched data
    } catch (error) {
      throw new Error(`Error fetching token: ${error}`);
    }
  }
  