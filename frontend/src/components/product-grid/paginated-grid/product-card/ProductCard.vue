<template>
<div class="product-card">
    <product-card-header product-id=productId
        :promo=isPromo
        :promo-text=promoText
        image="boiler.png" />
    <product-card-body :promo="isPromo"
        :price=price
        :old-price=oldPrice
        :description=description
        :brand=brand
        :name=name
        :type=type
        :power=power
        :poweredBy=poweredBy
        :usage=usage />
    <product-card-footer
        :product-id=productId
        @product-flagged="$emit('product-flagged')"
        @product-deflagged="$emit('product-deflagged')"/>
    </div>
</template>
<script>
import ProductCardHeader from './ProductCardHeader.vue';
import ProductCardBody from './ProductCardBody.vue';
import ProductCardFooter from './ProductCardFooter.vue';

export default {
    props: ['product'],
    computed: {
        productId() { return this.product.id; },
        isPromo() { return this.product.promo; },
        promoText() { return this.product.discountDisclaimer; },
        price() {return this.product.price; },
        oldPrice() { return this.product.oldPrice; },
        description() { return this.product.includes; },
        brand() { return this.product.brand; },
        name() { return this.product.modelName; },
        type() { return this.product.type; },
        power() { return this.product.wattPower; },
        poweredBy() { return this.product.poweredBy; },
        usage() { return this.product.usage; }
    },
    components:{
        ProductCardHeader,
        ProductCardBody,
        ProductCardFooter
    }
}
</script>
<style>
page-controls
{
    color: #00000080;
    display: flex;
    flex-direction: row;
    height: 36px;
    margin-top: 30px;
}
page-counter
{
    font: normal normal 900 12px/22px "Avenir Black";
    letter-spacing: 0.6px;
    color: #00000080;
}
page-counter span
{
    display: inline-flex;
    height: 36px;
    width: 36px;
    text-align: center;
}
page-counter .active
{
    color: white;
    background: #5738FF 0% 0% no-repeat;
    border-radius: 70px;
}
nav-page-button .active
{
    color: #5738FF;
}
</style>