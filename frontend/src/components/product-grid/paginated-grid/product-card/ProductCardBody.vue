<template>
    <div class="product-card-body">
        <div class="product-card-description">
            <p class="title-small">
                {{brand.toUpperCase()}}
            </p>
            <p>
                {{name}} - {{type == 'Condensing' ? type + ' Boiler' : type}}<br v-if=type>{{power}} kW {{poweredBy}}{{usage ? ' - ' + usage : ''}}
            </p>
        </div>
        <product-card-price :discount=promo :price=price :old-price=oldPrice :description=description />
    </div>
</template>
<script>
import ProductCardPrice from './ProductCardPrice.vue';

export default {
    components: { ProductCardPrice },
    props: { promo: Boolean,
    price: Number,
    oldPrice: Number,
    description: String,
    brand:String,
    name:String,
    type:String,
    power: Number,
    poweredBy:String,
    usage: String }

}
</script>
<style scoped>
.product-card-description .title-small
{
    margin-top: 10px;
    font: normal normal 900 12px/15px "Avenir Black";
    letter-spacing: 0.6px;
    height: 16px;
}
</style>
