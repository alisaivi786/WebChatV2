export async function getAllUsers(subGroupId: number, accessToken: string) {
  const url = `${import.meta.env.VITE_API_BASE_URL}/api/${import.meta.env.VITE_API_VERSION}/GetChatGroupUsers`; 
  const requestBody = {
    SubGroupId: subGroupId,
    timestamp: 9999999999,
    random: "stringstringstringstringstringst",
    signature: "string",
    pageSize: 20,
    pageNo: 1
  };

  try {
    const response = await fetch(url, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
        "Authorization": `Bearer ${accessToken}`
      },
      body: JSON.stringify(requestBody),
    });

    if (!response.ok) {
      throw new Error(`Failed to fetch users: ${response.statusText}`);
    }

    const data = await response.json();
    return data;
  } catch (error) {
    throw new Error(`Error fetching users: ${error}`);
  }
}

export async function getCurrentUserDetails(uuid: string, accessToken: string) {
  const url = `${import.meta.env.VITE_API_BASE_URL}/api/${import.meta.env.VITE_API_VERSION}/User/GetCurrentUserDetails`; 
  const requestBody = {
    UUID: uuid
  };

  try {
    const response = await fetch(url, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
        "Authorization": `Bearer ${accessToken}`
      },
      body: JSON.stringify(requestBody),
    });

    if (!response.ok) {
      throw new Error(`Failed to fetch users: ${response.statusText}`);
    }

    const data = await response.json();
    return data.data;
  } catch (error) {
    throw new Error(`Error fetching users: ${error}`);
  }
}
