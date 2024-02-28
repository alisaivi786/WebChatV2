// apiService.ts

export async function getAllMessages(subGroupId: string, uuid: string, pageParam: any, groupName: string, accessToken: string) {
  const url = `${import.meta.env.VITE_API_BASE_URL}/api/${import.meta.env.VITE_API_VERSION}/Message/GetMessages`;
  const requestBody = {
    GroupName: groupName,
    SubGroupId: subGroupId,
    UUID: uuid, // oldest message UUID
    timestamp: 9999999999,
    random: "stringstringstringstringstringst",
    signature: "string",
    pageSize: 20,
    pageNo: pageParam == 1 ? pageParam : 2,
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
      throw new Error(`Failed to fetch messages: ${response.statusText}`);
    }

    const data = await response.json();
    return data;
  } catch (error) {
    throw new Error(`Error fetching messages: ${error}`);
  }
}

export async function getRedisMessages(pageParam: any) {
  const url = `${import.meta.env.VITE_API_BASE_URL}/api/${import.meta.env.VITE_API_VERSION}/Message/GetRedisMessages`;
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
    return data;
  } catch (error) {
    throw new Error(`Error fetching messages: ${error}`);
  }
}
