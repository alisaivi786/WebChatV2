import 'bootstrap/dist/css/bootstrap.min.css';
import './assets/main.css'
import './assets/main.scss'


import ElementPlus from 'element-plus';
import { VueQueryPlugin } from 'vue-query';
import { createApp } from 'vue'
import App from './App.vue'

createApp(App)
.use(VueQueryPlugin, ElementPlus)
.mount('#app')
