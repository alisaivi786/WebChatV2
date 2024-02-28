import { createStore } from 'vuex';
import { getAuthAccessToken } from '../services/authService';
import { getSubGroupById } from '../services/groupService';
import { getAllUsers, getCurrentUserDetails } from '../services/userService';
import UserModel from "../models/UserModel";

// Define the initial state
interface State {
  accessToken: string | null;
  userList: UserModel[];
  loggedInUser: Object;
  groupData: Object;
  loginSubGroupId: String;
  loginUUID: String;
}

// Create a new Vuex store instance
const store = createStore<State>({
  state: {
    accessToken: '',
    userList: [],
    loggedInUser: Object,
    groupData: Object,
    loginSubGroupId: '',
    loginUUID: '',
  },
  mutations: {
    setAccessToken(state, token: string) {
      state.accessToken = token;
    },
    setUserList(state, userList: UserModel[]) {
      state.userList = userList;
    },
    setLoggedInUser(state, user) {
      state.loggedInUser = user;
    },
    setGroupData(state, groupData) {
      state.groupData = groupData;
    },
    setLoginSubGroupId(state, loginSubGroupId) {
      state.loginSubGroupId = loginSubGroupId;
    },
    setLoginUUID(state, loginUUID) {
      state.loginUUID = loginUUID;
    },
  },
  actions: {
    async fetchAccessToken({ commit, state }) {
      // Fetch access token only if not already available
      if (!state.accessToken) {
        const userId = "500";
        const userName = "9188888888666";
        const password = "lF4r1045+MOKlS+/piVoLWSshoM=";

        try {
          const res = await getAuthAccessToken(userId, userName, password);
          const token = res.data.token;
          commit('setAccessToken', token);
        } catch (error) {
          console.error(error);
        }
      }
    },
    async fetchSubGroupById({ commit, state }, subGroupId) {
      try {
        if (!('subGroupId' in state.groupData) && state.accessToken) {
          const subGroupData = await getSubGroupById(subGroupId, state.accessToken);
          commit('setGroupData', subGroupData.data);
        }
      } catch (error) {
        console.error(error);
        throw error; // Rethrow the error to handle it in the component if needed
      }
    },
    async fetchAllUsers({ commit, state }, { subGroupId }) {
      // Fetch access token only if not already available
      if (state.userList.length == 0 && state.accessToken) {
        try {
          const res = await getAllUsers(subGroupId, state.accessToken);
          const userList = res.data.list;
          commit('setUserList', userList);
        } catch (error) {
          console.error(error);
        }
      }
    },
    async fetchCurrentUserDetails({ commit, state }, uuid) {
      try {
        if (!state.accessToken) return;

        const res = await getCurrentUserDetails(uuid, state.accessToken);
        const loggedInUser = new UserModel(
          0,
          '',
          res.nickName,
          0,
          '',
          res.userId,
          res.userName,
          res.userPhoto
        );
        commit('setLoggedInUser', loggedInUser);
      } catch (error) {
        console.error(error);
      }
    },
  },
});

export default store;
