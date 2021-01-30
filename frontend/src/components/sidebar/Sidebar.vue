<template>
    <div v-cloak class="sidebar">
        <category-filter />
        <availability-filter class="sidebar-filter" />
        <brand-filter class="sidebar-filter" />
        <types-filter class="sidebar-filter" />
        <powered-by-filter class="sidebar-filter" />
        <power-filter class="sidebar-filter" />
        <usage-filter class="sidebar-filter" />
        <reviews-filter class="sidebar-filter" />
    </div>
</template>
<script>
import UsageFilter from './filters/UsageFilter.vue';
import TypesFilter from './filters/TypesFilter.vue';
import ReviewsFilter from './filters/ReviewsFilter.vue';
import PowerFilter from './filters/PowerFilter.vue';
import PoweredByFilter from './filters/PoweredByFilter.vue';
import CategoryFilter from './filters/CategoryFilter.vue';
import BrandFilter from './filters/BrandFilter.vue';
import AvailabilityFilter from './filters/AvailabilityFilter.vue';

export default {
    components: {
        AvailabilityFilter,
        UsageFilter,
        TypesFilter,
        ReviewsFilter,
        PowerFilter,
        PoweredByFilter,
        CategoryFilter,
        BrandFilter
    },
}
</script>
<style scoped>
div .sidebar
{
    display: inline-block;
    height: 1575px;
    width: 270px;
    padding-right: 20px;
    border-right: 1px solid #0000001A;
    margin-top: 40px;
}
div .category-filter
{
    height: 166px;
    border-bottom: 1px solid #0000001A
}
div .sidebar-filter
{
    padding-top: 30px;
    display: block;
    width: 100%;
}
</style>