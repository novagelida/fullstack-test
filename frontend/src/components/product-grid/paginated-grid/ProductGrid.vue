<template>
    <div class="product-grid">
        <product-card :product=product v-for="product in productList" :key="product.id"
        @product-flagged="incrementComparisonListCount"
        @product-deflagged="decrementComparisonListCount" />
    </div>
</template>
<script>
export default {
computed:{
        productList() {
            return this.$store.state.productViewContext.productList;
        }
    },
    data() {
        return {
            comparisonListCount: 0
        }
    },
    methods: {
        incrementComparisonListCount: function(){
            this.comparisonListCount++;

            if (this.comparisonListCount>= 3)
                this.$store.commit('enableComparison');

        },
        decrementComparisonListCount: function(){
            this.comparisonListCount--;

            if (this.comparisonListCount< 3)
                this.$store.commit('disableComparison');

        }
    }
}
</script>
<style scoped>
div .product-grid
{
    display: grid;
    grid-template-columns: repeat(3, 291px);
    grid-template-rows: repeat(4, 327px);
    padding-bottom: 78px;
    column-gap: 30px;
    row-gap: 35px;
    border-bottom: 1px solid #0000001A;
}
</style>