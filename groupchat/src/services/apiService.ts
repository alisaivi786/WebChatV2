// apiService.ts
import store from '../store/store';
import type { Route } from './routes';

export interface Params {
  [key: string]: any;
}

export async function apiService(route: Route, params: Params) {
  let url = `${import.meta.env.VITE_API_BASE_URL}${route.endpoint}`;
 
  // Dynamically append IDs or other parameters to the URL if they are part of the route
  for (const [key, value] of Object.entries(params)) {
     if (route.endpoint.includes(`:${key}`)) {
       url = url.replace(`:${key}`, value.toString());
     }
  }
 
  // Prepare the request body if the method is not GET
  let requestBody;
  if (route.method !== 'GET') {
     requestBody = {
       ...route.body,
       ...params,
     };
  }
 
  const accessToken = store.state.accessToken;
 
  try {
     const response = await fetch(url, {
       method: route.method,
       headers: {
         "Content-Type": "application/json",
         "Authorization": `Bearer ${accessToken}`
       },
       ...(requestBody && { body: JSON.stringify(requestBody) }), // Only include body for non-GET requests
     });
 
     if (!response.ok) {
       throw new Error(`Failed to fetch: ${response.statusText}`);
     }
 
     const data = await response.json();
     return data;
  } catch (error) {
     throw new Error(`Error fetching: ${error}`);
  }
 }

 export async function uploadApiService(route: Route, formData?: FormData) {
  const url = `${import.meta.env.VITE_UPLOAD_IMAGE_API_BASE_URL}${route.endpoint}`;
  const accessToken = store.state.accessToken;

  try {
      const response = await fetch(url, {
          method: route.method,
          headers: {
              Accept: "text/x-json",
              Authorization: `Bearer ${accessToken}`,
          },
          body: formData, // Directly use FormData
      });

      if (!response.ok) {
          throw new Error(`Failed to upload: ${response.statusText}`);
      }

      const data = await response.json();
      return data;
  } catch (error) {
      throw new Error(`Error uploading: ${error}`);
  }
}