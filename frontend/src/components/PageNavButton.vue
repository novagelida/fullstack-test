<template>
    <div class="page-nav-button">
        <i v-if="isLeft" class="icon-arrow-left chevron nav-button"></i>
        <span class="label" :class="{'left': isLeft, 'right': isRight}">{{printLabel()}}</span>
        <i v-if="isRight" class="icon-arrow-right chevron nav-button"></i>
    </div>
</template>
<script>
export default {
    props: {
        isLeft:Boolean, isRight: Boolean
    },
    methods:{
        printLabel: function() {
            if (this.isLeft)
                return "Prev";

            if (this.isRight)
                return "Next";
        }
    }
}
</script>
<style>
div .page-nav-button
{
    color: #00000080;
    margin: auto;
    cursor: pointer;
}
div .page-nav-button .chevron.nav-button
{
    top: -1px;
    position: relative;
}
div .page-nav-button .left
{
    margin-left: 10px;
}
div .page-nav-button .right
{
    margin-right: 10px
}
</style>