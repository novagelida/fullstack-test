<template>
    <div class="discount-badge" v-if=active>
        {{promoText}}
    </div>
</template>
<script>
export default {
    props: {active: Boolean, promoText: String },
}
</script>
<style scoped>
.discount-badge
{
    height: 26px;
    width: 108px;
    position: relative;
    top: -175px;
    background: #FD6600;
    border-radius: 0px 3px 3px 0px;
    color:white;
    font-size:12px;
    text-align: center;
    line-height: 26px;
    font-weight: 900;
}
</style>