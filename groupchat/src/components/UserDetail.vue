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
      <div class="col-md-2">
        <div class="card shadow-sm">
          <img
            :src="$store.state.loggedInUser.userPhoto"
            class="card-img-top rounded-circle"
            alt="User Photo"
          />
          <div class="card-body text-center">
            <h5 class="card-title mb-0">
              {{ $store.state.loggedInUser.userName }}
            </h5>
          </div>
        </div>
      </div>
      <div class="col-md-9">
        <h4>Member Name</h4>
        <p>{{ $store.state.loggedInUser.userName }}</p>
        <h4>Nickname</h4>
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
      <div class="col-md-2">
        <div class="card shadow-sm">
          <img
            :src="$store.state.loggedInUser.userPhoto"
            class="card-img-top rounded-circle"
            alt="User Photo"
          />
          <div class="card-body text-center">
            <input type="file" class="form-control" @change="handleFileChange($event)" />
          </div>
        </div>
      </div>
      <div class="col-md-9">
        <h4>Member Name</h4>
        <input type="text" class="mb-3 form-control" v-model="userName" />
        <h4>Nickname</h4>
        <input type="text" class="form-control" v-model="nickName" />
      </div>
      <div class="col-md-1">
        <div class="d-flex justify-content-center mb-3">
          <button class="btn btn-outline-success" @click="saveChanges">
            Save
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { defineComponent } from "vue";
import UserModel from "../models/UserModel";

export default defineComponent({
  data() {
    return {
      loggedInUser: UserModel,
      editing: false,
      userPhoto: "",
      userName: "",
      nickName: "",
    };
  },
  methods: {
    async getCurrentUserDetails() {
      try {
        await this.$store.dispatch('fetchAccessToken');
        await this.$store.dispatch("fetchCurrentUserDetails", this.$route.params.uuid);
      } catch (error) {
        console.error(error);
      }
    },
    toggleEdit() {
      this.editing = !this.editing;
      if (this.editing) {
        // Initialize input values with current user details
        this.userPhoto = this.$store.state.loggedInUser.userPhoto;
        this.userName = this.$store.state.loggedInUser.userName;
        this.nickName = this.$store.state.loggedInUser.nickName;
      }
    },
    handleFileChange(event) {
      // Update editedUser with the selected file
      const file = event.target.files[0];
      if (file) {
        this.editedUser.userPhoto = URL.createObjectURL(file);
      }
    },
    async saveChanges() {
      // Perform API call with updated details
      const updatedDetails = {
        userPhoto: this.userPhoto,
        userName: this.userName,
        nickName: this.nickName,
      };
      try {
        // Call API with updated details
       // await this.$store.dispatch("updateUserDetails", updatedDetails);
        // Update local user details
        this.$store.state.loggedInUser.userPhoto = this.userPhoto;
        this.$store.state.loggedInUser.userName = this.userName;
        this.$store.state.loggedInUser.nickName = this.nickName;
        // Toggle editing mode off
        this.editing = false;
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
/* Add any custom styles here */
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
</style>
