<template>
    <div class="favourite-badge" @click="toggleSelection">
        <i class="icon-preferiti" v-show=!selected></i>
        <i class="icon-preferiti_filled" v-show=selected></i>
    </div>
</template>
<script>
export default {
    props: ['productId'],
    data(){
        return {
            selected: false
        }
    },
    methods: {
        toggleSelection: function() {
            this.selected = !this.selected;

            if (this.selected)
                localStorage.setItem('fav-'+this.productId, this.productId);

            if (!this.selected)
                localStorage.removeItem('fav-'+this.productId);
        }
    }
}
</script>
<style>
div .favourite-badge{
    width: 17px;
    height: 17px;
    position: relative;
    color: #00000033;
    left: 259px;
    font-size: 17px;
    top: -169px;
    cursor: pointer;
}
div .favourite-badge.promo
{
    top: -195px;
}
div .favourite-badge .icon-preferiti_filled
{
    color: #e42020;
}
</style>