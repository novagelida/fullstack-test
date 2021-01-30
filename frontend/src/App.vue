<template>
  <div id="app">
    <sidebar />
    <products-view />
    <comparison-banner />
  </div>
</template>

<script>
import Sidebar from './components/sidebar/Sidebar.vue';
import ProductsView from './components/product-grid/ProductsView.vue';
import ComparisonBanner from './components/ComparisonBanner.vue';
import {fetchInitialData} from './dataFetching.js';
if (process.env.NODE_ENV!="production")
  var mockedResponse = require('./mockedResponse.js');

export default {
  name: 'App',
  components: {
    Sidebar,
    ProductsView,
    ComparisonBanner
  },
  mounted: function () {
      this.startUp();
  },
  methods: {
      startUp: function () {
          var self = this;
          if (process.env.NODE_ENV=="production")
          {
            fetchInitialData(self.$store);
          } else {
              window.alert("Sto usando dati mocked");
              setTimeout(() => self.$store.commit('setProductList', mockedResponse.mockedResponse.collection), 1500);
          }
      }
  }
}
</script>

<style>
@import './css/icon-definitons.css';
@import './css/fonts.css';

#app {
  display: inline-flex;
  background: white;
  height: 1615px;
  padding: 40px 93px 36px 93px;
  text-align: left;
  font: normal normal normal 15px/20px "Avenir Book";
  letter-spacing: 0px;
  color: #000000;
}
[v-cloak] {
    display: none;
}
p, h1
{
    margin-top: auto;
    margin-bottom: auto;
}
ul
{
    list-style-type: none;
    margin-top: auto;
    margin-bottom: auto;
    padding-left: 20px;
}
li
{
    margin-top: 10px;
}
h1
{
    font: normal normal 900 12px/20px "Avenir Black";
    letter-spacing: 0.6px;
    line-height: 16px;
    color: #000000;
}
h2
{
    margin-bottom: auto;
    color: #5738FF;
    font: normal normal normal 15px/20px "Avenir Book";
    margin-top: 10px;
}
.star
{
    margin-right: 2px;
    font-size: 12px;
    color: #461E7D;
}
.stacked-checkbox.on label .star
{
    line-height: 0;
    color: #5738FF;
}
.chevron
{
    font-size: 9px;
    cursor: pointer;
}
.chevron.right
{
    margin-left: 10px;
}
.chevron.left
{
    margin-right: 10px;
}
</style>
