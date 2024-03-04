// routes.ts

export interface Route {
    endpoint: string;
    method: string;
    body?: Record<string, any>;
}

export const getAuthAccessTokenRoute: Route = {
    endpoint: `/api/${import.meta.env.VITE_API_VERSION}/Auth/AccessToken`,
    method: 'POST',
};

export const getAllMessagesRoute: Route = {
    endpoint: `/api/${import.meta.env.VITE_API_VERSION}/Message/GetMessages`,
    method: 'POST',
    body: {
        GroupName: '',
        SubGroupId: '',
        UUID: '', // oldest message UUID
        timestamp: 9999999999,
        random: "stringstringstringstringstringst",
        signature: "string",
        pageSize: 20,
        pageNo: 1,
    },
};

export const getAllUsersRoute: Route = {
    endpoint: `/api/${import.meta.env.VITE_API_VERSION}/GetChatGroupUsers`,
    method: 'POST',
    body: {
        SubGroupId: 0,
        timestamp: 9999999999,
        random: "stringstringstringstringstringst",
        signature: "string",
        pageSize: 20,
        pageNo: 1,
    },
};

export const getCurrentUserDetailsRoute: Route = {
    endpoint: `/api/${import.meta.env.VITE_API_VERSION}/User/GetCurrentUserDetails`,
    method: 'POST',
    body: {
        UUID: '',
    },
};

export const getSubGroupByIdRoute: Route = {
    endpoint: `/api/${import.meta.env.VITE_API_VERSION}/SubGroup-Id/:subGroupId`,
    method: 'GET',
};

export const updateUserDetailsRoute: Route = {
    endpoint: `/api/${import.meta.env.VITE_API_VERSION}/User/UpdateUserDetails`,
    method: 'POST',
    body: {
        timestamp: 9999999999,
        random: "stringstringstringstringstringst",
        signature: "string",
        rowId: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        userName: "string",
        nickName: "string",
        userPhoto: "string"
    },
};

export const uploadImageRoute: Route = {
    endpoint: `/api/${import.meta.env.VITE_API_VERSION}/File/UploadFile?FileCode=1`,
    method: 'POST',
};