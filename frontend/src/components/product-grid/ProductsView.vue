<template>
    <div v-cloak class="products-view">
        <sort-by />
        <paginated-grid :loading="isLoading" />
        <modal v-if="showComparisonModal" @close-modal="closeComparisonModal()">
            <h3 slot="header">Comparazione</h3>
            <compact-comparison-view slot="body"/>
        </modal>
    </div>
</template>
<script>
import SortBy from './SortBy.vue';
import PaginatedGrid from './paginated-grid/PaginatedGrid.vue';
import Modal from '../Modal';
import CompactComparisonView from '../CompactComparisonView.vue';

export default {
    components: {
        SortBy,
        PaginatedGrid,
        Modal,
        CompactComparisonView
    },
    computed: {
        showComparisonModal() {
            return this.$store.state.productViewContext.comparisonModalActive;
        },
        isLoading() {
            return Object.keys(this.$store.state.productViewContext.productList).length == 0;
        }
    },
    methods:{
        closeComparisonModal() {
            this.$store.commit('hideComparisonModal');
        }
    }
}
</script>
<style scoped>
div .products-view
{
    display: inline-block;
    width: 933px;
    padding-left: 30px;
    height: 100%;
}
</style>