import 'bootstrap/dist/css/bootstrap.min.css';
import './assets/main.css'
import { VueQueryPlugin } from 'vue-query';
import { createApp } from 'vue'
import App from './App.vue'

createApp(App)
.use(VueQueryPlugin)
.mount('#app')
