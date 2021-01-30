<template>
    <div class="page-controls">
        <page-nav-button :isLeft=true />
        <div class="page-counter">
            <div class="spacer active"><span>1</span></div>
            <div class="spacer"><span>2</span></div>
            <div class="spacer"><span>3</span></div>
        </div>
        <page-nav-button class="active rigt-button" :isRight=true />
    </div>
</template>
<script>
import PageNavButton from '../../PageNavButton.vue'
export default {
  components: { PageNavButton },
    
}
</script>
<style>
div .page-controls
{
    padding-top: 30px;
    height: 36px;
    display: flex;
    text-align: center;
    font: normal normal 900 12px/22px "Avenir Black";
    letter-spacing: 0.6px;
    color: #00000080;
}
div .page-controls .spacer.active
{
    color: white;
    border-radius: 50%;
    background: #5738FF 0% 0% no-repeat padding-box;
}
div .page-controls .spacer
{
    display: inline-block;
    height: 36px;
    width: 36px;
}
div .page-counter
{
    line-height: 36px;
    flex: 2 0 auto;
    margin: auto;
}
div .page-controls .right-button
{
    flex: 3 0 auto;
}
.spacer span{
    cursor:pointer;
}
</style>