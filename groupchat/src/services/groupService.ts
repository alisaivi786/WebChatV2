// services/groupService.ts

export async function getSubGroupById(subGroupId: number, accessToken: string) {
  const url = `${import.meta.env.VITE_API_BASE_URL}/api/${import.meta.env.VITE_API_VERSION}/SubGroup-Id/${subGroupId}`; 
  try {
    const response = await fetch(url, {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
        "Authorization": `Bearer ${accessToken}`
      },
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