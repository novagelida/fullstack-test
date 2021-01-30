import Vue from 'vue';
import App from './App.vue';
import {store} from './store.js';
import {priceFilter} from './priceFilter.js';

import CustomCheckbox from './components/CustomCheckbox.vue';
import ProductCard from './components/product-grid/paginated-grid/product-card/ProductCard.vue';

Vue.config.productionTip = false

Vue.component('custom-checkbox', CustomCheckbox);
Vue.component('product-card', ProductCard);

Vue.filter('price', priceFilter)

new Vue({
  render: h => h(App),
  store,
}).$mount('#app')