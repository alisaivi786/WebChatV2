import 'bootstrap/dist/js/bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import './assets/main.css'
import './assets/main.scss'

import type { VueQueryPluginOptions } from 'vue-query';
import { VueQueryPlugin } from 'vue-query';
import { createApp } from 'vue'
import { createRouter, createWebHistory } from 'vue-router';
import App from './App.vue'
import ChatHome from './components/ChatHome.vue';
import UserDetail from './components/UserDetail.vue';
import LoginPage from './components/LoginPage.vue';
import store from './store/store';

const routes = [
  {
    path: '/', // Define root path
    component: LoginPage,
    children: []
  },
  {
    path: '/chat',
    component: ChatHome
  },
  {
    path: '/user/:uuid',
    component: UserDetail
  },
  {
    path: '/login',
    component: LoginPage
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes
});

(async (VueQueryPluginOptions) => {  
  // Create the Vue app instance
  const app = createApp(App);
  
  // Use Vue Query Plugin
  app.use(VueQueryPlugin, VueQueryPluginOptions);
  
  // Use Vuex store
  app.use(store);

  app.use(router);
  
  // Mount the app to the DOM
  app.mount('#app');
})();