<template>
  <div class="user-detail container py-4 px-4">
    <h2 class="mb-4">User Detail</h2>
    <div v-if="!editing && !$store.state.loggedInUser.userName">
      <div class="d-flex justify-content-center">
        <div class="spinner-border text-primary" role="status">
          <span class="visually-hidden">Loading...</span>
        </div>
      </div>
    </div>
    <div v-else-if="!editing" class="row">
      <div class="col-md-3">
        <div class="card shadow-sm user-avatar">
          <img
            :src="$store.state.loggedInUser.userPhoto"
            class="card-img-top rounded-circle"
            alt="User Photo"
          />
        </div>
      </div>
      <div class="col-md-8">
        <h5>Member Name</h5>
        <p>{{ $store.state.loggedInUser.userName }}</p>
        <h5>Nickname</h5>
        <p>{{ $store.state.loggedInUser.nickName }}</p>
      </div>
      <div class="col-md-1">
        <div class="d-flex justify-content-center mb-3">
          <button class="btn btn-outline-primary" @click="toggleEdit">
            <i class="fas fa-edit"></i> Edit
          </button>
        </div>
      </div>
    </div>
    <div v-else class="row">
      <div class="col-md-3">
        <div class="card shadow-sm user-avatar">
          <img
            :src="$store.state.loggedInUser.userPhoto"
            class="card-img-top rounded-circle"
            alt="User Photo"
          />
          <div class="card-body text-center" v-if="!imageUploading">
            <input
              type="file"
              class="form-control"
              @change="handleFileChange($event)"
            />
          </div>
          <div class="d-flex justify-content-center mt-1" v-if="imageUploading">
            <div class="spinner-border text-primary" role="status">
              <span class="visually-hidden">Loading...</span>
            </div>
          </div>
        </div>
      </div>
      <div class="col-md-8">
        <h5>Member Name</h5>
        <input type="text" class="mb-3 form-control" v-model="userName" />
        <h5>Nickname</h5>
        <input type="text" class="form-control" v-model="nickName" />
      </div>
      <div class="col-md-1">
        <div class="d-flex justify-content-center mb-3">
          <button class="btn btn-outline-success" @click="saveChanges">
            Save
          </button>
        </div>
        <div class="d-flex justify-content-center mt-1" v-if="userUpdating">
            <div class="spinner-border text-primary" role="status">
              <span class="visually-hidden">Loading...</span>
            </div>
          </div>
      </div>
    </div>
  </div>
</template>

<script>
import { defineComponent } from "vue";
import UserModel from "../models/UserModel";
import { apiService, uploadApiService } from "../services/apiService";
import { uploadImageRoute, updateUserDetailsRoute } from "../services/routes";

export default defineComponent({
  data() {
    return {
      loggedInUser: UserModel,
      newUserAvatarURL: String,
      imageUploading: false,
      userUpdating: false,
      params: Object,
      editing: false,
      userPhoto: "",
      userName: "",
      nickName: "",
    };
  },
  methods: {
    async getCurrentUserDetails() {
      try {
        await this.$store.dispatch("fetchAccessToken");
        await this.$store.dispatch(
          "fetchCurrentUserDetails",
          this.$route.params.uuid
        );
      } catch (error) {
        console.error(error);
      }
    },
    toggleEdit() {
      this.editing = !this.editing;
      if (this.editing) {
        this.userPhoto = this.$store.state.loggedInUser.userPhoto;
        this.userName = this.$store.state.loggedInUser.userName;
        this.nickName = this.$store.state.loggedInUser.nickName;
      }
    },
    async handleFileChange(event) {
      this.imageUploading = true;
      const file = event.target.files[0];
      if (file) {
        const formData = new FormData();
        formData.append("file", file);

        try {
          const data = await uploadApiService(uploadImageRoute, formData);
          console.log("Image uploaded successfully:", data);
          this.newUserAvatarURL = data.data.url;
          this.$store.state.loggedInUser.userPhoto = this.newUserAvatarURL;
        } catch (error) {
          console.error("Error uploading image:", error);
        } finally {
          this.imageUploading = false;
        }
      }
    },
    async saveChanges() {
        this.userUpdating = true;
      this.params = {
        timestamp: 9999999999,
        random: "stringstringstringstringstringst",
        signature: "string",
        rowId: this.$store.state.loggedInUser.rowId,
        userName: this.userName,
        nickName: this.nickName,
        userPhoto: this.$store.state.loggedInUser.userPhoto,
      };

      try {
        await apiService(updateUserDetailsRoute, this.params);

        this.$store.state.loggedInUser.userName = this.userName;
        this.$store.state.loggedInUser.nickName = this.nickName;

        this.editing = false;
        this.userUpdating = false;
      } catch (error) {
        console.error(error);
      }
    },
  },
  mounted() {
    this.getCurrentUserDetails();
  },
});
</script>

<style scoped>
.user-detail {
  background-color: #ffffff;
  border-radius: 10px;
  box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
  margin-top: 5%;
}

.card {
  border-radius: 10px;
  box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
}

.card-title {
  font-size: 1.25rem;
  font-weight: 500;
}

.card-text {
  font-size: 0.9rem;
  color: #6c757d;
}
.user-avatar {
  padding: 1em;
}
</style>
