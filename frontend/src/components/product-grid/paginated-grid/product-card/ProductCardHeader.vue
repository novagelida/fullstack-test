<template>
    <div class="product-card-header">
        <!-- abbiamo solo un boiler? -->
        <img :src=getImgUrl(image) >
        <!-- discount-badge è optional -->
        <discount-badge :active=promo :promo-text=promoText />
        <favourite-badge :product-id=productId :class="{'promo' : promo}" />
    </div>
</template>
<script>
import DiscountBadge from './DiscountBadge.vue';
import FavouriteBadge from './FavouriteBadge.vue';

export default {
    components: {
        DiscountBadge,
        FavouriteBadge
    },
    props: {productId: String, promo: Boolean, promoText: String, image: String},
    methods: {
        getImgUrl: function (imageName) {
            return require ('@/assets/'+ imageName);
        }
    }
}
</script>
<style>
div .product-card-header img
{
    background-color:rgba(0, 0, 0, 0.03);
}
div .product-card-header
{
    height: 180px;
}
</style>
