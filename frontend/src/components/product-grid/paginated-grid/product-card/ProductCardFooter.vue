<template>
    <div class="product-card-footer">
        <rate-product />
        <compare-product
            @flagged-for-comparison="addToComparisonList"
            @deflagged-for-comparison="removeFromComparisonList"/>
    </div>
</template>
<script>
import RateProduct from "./RateProduct.vue";
import CompareProduct from "./CompareProduct.vue";

export default {
    components: {
        RateProduct,
        CompareProduct
    },
    props: ['product-id'],
    methods: {
        addToComparisonList: function() {
            this.$store.commit('addToComparisonList', this.productId);
            this.$emit('product-flagged');
        },
        removeFromComparisonList: function() {
            this.$store.commit('removeFromComparisonList', this.productId);
            this.$emit('product-deflagged');
        }
    }
}
</script>
<style>
div .product-card-footer
{
    display: flex;
    height: 28px;
    margin-top: 10px;
}
</style>