<template>
    <div class="paginated-grid">
        <loading-spinner :loading="loading" />
        <product-grid v-if="!loading"/>
        <page-controls v-if="!loading" />
    </div>
</template>
<script>
import ProductGrid from './ProductGrid.vue';
import PageControls from './PageControls.vue';
import LoadingSpinner from '../../LoadingSpinner.vue'

export default {
    props: ['loading'],
    components: {
        ProductGrid,
        PageControls,
        LoadingSpinner
    }
}
</script>
<style>
div .paginated-grid
{
    display: block;
    padding-top: 20px;
}
</style>