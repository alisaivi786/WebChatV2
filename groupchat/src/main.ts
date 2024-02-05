import 'bootstrap/dist/css/bootstrap.min.css';
import './assets/main.css'
import './assets/main.scss'

import CKEditor from '@ckeditor/ckeditor5-vue'
import { VueQueryPlugin } from 'vue-query';
import { createApp } from 'vue'
import App from './App.vue'

createApp(App)
.use(VueQueryPlugin, CKEditor)
.mount('#app')
