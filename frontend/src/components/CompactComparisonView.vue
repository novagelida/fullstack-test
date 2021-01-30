<template>
    <div class="compact-comparison-view">
        <product-card :product=getProductById(id) class="comparing-item" v-for="id  in productIds" :key="id" />
    </div>
</template>
<script>
import ProductCard from './product-grid/paginated-grid/product-card/ProductCard.vue';
export default {
  components: { ProductCard },
    computed: {
        productIds(){
            return this.$store.state.productViewContext.comparisonList;
        }
    },
    methods: {
        getProductById: function(id) {
            return this.$store.state.productViewContext.productList[id];
        }
    }
}
</script>
<style>
div .compact-comparison-view
{
    height: 320px;
    display: flex;
    justify-content: center;
    justify-items: center;
}
.comparing-item:nth-child(even) {
    margin-left: 30px;
    margin-right: 30px;
}
.comparing-item .favourite-badge
{
    display:none;
}
.comparing-item .compare-product
{
    display:none;
}
button 
{
    height: 30px;
    width: 50px;
    background: green;
}
</style>