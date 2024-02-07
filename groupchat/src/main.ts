import 'bootstrap/dist/css/bootstrap.min.css';
import './assets/main.css'
import './assets/main.scss'


import { VueQueryPlugin } from 'vue-query';
import { createApp } from 'vue'
import App from './App.vue'

const vueQueryPluginOptions: VueQueryPluginOptions = {
    queryClientConfig: {
      defaultOptions: {
        queries: {
          refetchOnWindowFocus: false,
        },
      },
    },
  };

createApp(App)
.use(VueQueryPlugin, vueQueryPluginOptions)
.mount('#app')
