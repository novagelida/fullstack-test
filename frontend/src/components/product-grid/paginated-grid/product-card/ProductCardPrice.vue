<template>
    <div class="product-card-price" :class="{discount : discount}">
        <div class="prices">{{price | price}}<span v-if="oldPrice" class="old-price">{{oldPrice | price}}</span></div>
        <p class="description">{{description}}</p>
    </div>
</template>
<script>
export default {
    props: { discount: Boolean, oldPrice: Number, description: String, price: Number }
}
</script>
<style>
div .product-card-price
{
    font: normal normal 900 20px/27px "Avenir Black";
    border-bottom: 1px solid #0000001A;
    padding-bottom: 10px;
    color: #461E7D;
}
div .product-card-price .prices
{
    height: 27px;   
}
div .product-card-price.discount
{
    color: #FD6600;
}
div .product-card-price p.description
{
    height: 16px;
    line-height: 16px;
}
div .product-card-price p.description
{
    font: normal normal 900 12px "Avenir Black";
}
div .product-card-price .old-price
{
    margin-left: 10px;
    text-decoration: line-through;
    font: normal normal 900 12px/15px "Avenir Black";
    color: #0000004D;
}
</style>