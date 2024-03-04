<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-md-3 login-page">
        <h3>Group Chat App</h3>
        <div class="form-container font-14">
          <input
            type="text"
            v-model="groupId"
            placeholder="Group ID"
            class="input-field"
          />
          <input
            type="text"
            v-model="subGroupId"
            placeholder="Sub Group ID"
            class="input-field"
          />
          <input
            type="text"
            v-model="uuid"
            placeholder="UUID"
            class="input-field"
          />
          <a @click="submitForm" class="submit-button btn btn-outline-primary"
            >Join Chat</a
          >
        </div>
        <div class="row mt-5 font-14">
          <h5>Default Values</h5>
          <div class="col-md-12"><label>Sub Group Id: </label> 1</div>
          <div class="col-md-12">
            <label>UUID: </label> {{ uuidConst }}
            <a @click="copyUUID()" class="btn copy-text" title="copy"
              ><i class="fa-regular fa-copy"></i
            ></a>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { defineComponent } from "vue";
import { useStore } from "vuex";
import { useRouter } from "vue-router";

export default defineComponent({
  data() {
    return {
      groupId: "",
      subGroupId: "",
      uuid: "",
      store: useStore(),
      router: useRouter(),
      uuidConst: "25eed9ad-fb34-4879-8ed9-5a4caf83e5a0",
    };
  },
  methods: {
    submitForm() {
      this.store.commit("setLoginSubGroupId", this.subGroupId);
      this.store.commit("setLoginUUID", this.uuid);

      this.router.push({
        path: "/chat",
        query: {
          subGroupId: this.subGroupId,
          uuid: this.uuid,
        },
      });
    },
    copyUUID() {
      navigator.clipboard.writeText(this.uuidConst);
    },
  },
  mounted() {},
});
</script>

<style scoped>

.font-14{
  font-size: 14px;
}

.login-page {
  background-color: #ffffff;
  border-radius: 10px;
  box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
  margin: auto;
  margin-top: 5%;
  padding: 20px;
  text-align: center;
  /* width: 50%; */
  padding: 2em;
}

.form-container {
  display: flex;
  flex-direction: column;
  gap: 5px;
  margin-top: 10px;
}

.input-field {
  padding: 10px;
  border: 1px solid #ccc;
  border-radius: 5px;
  width: 80%;
  margin: auto;
  margin-top: 10px;
  outline: none;
  border: none;
  border-radius: 0;
  border-bottom: 1px solid gainsboro;
}

.submit-button {
  margin: auto;
  margin-top: 10px;
  width: 80%;
  font-size: 14px;
  /* width: -moz-fit-content;
  width: -webkit-fit-content;
  width: fit-content; */
}

.submit-button:hover {
  background-color: #0056b3;
}

label {
  font-weight: bold;
}

.copy-text {
  margin-left: 0.5em;
  cursor: pointer;
  padding: 0;
}
</style>
