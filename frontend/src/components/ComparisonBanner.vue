<template>
    <transition name="scroll">
        <div class="comparison-banner" v-if=show>
            <div class="comparison-button" @click=showComparisonModal :class="{active: buttonActive}">
                <span v-if="!buttonActive" >Seleziona tre oggetti da paragonare</span>
                <span v-if="buttonActive" >Clicca per paragonare</span></div>
        </div>
    </transition>
</template>
<script>
export default {
    computed: {
        show() {
            return this.$store.state.productViewContext.comparisonBannerDisplayed;
        },
        buttonActive() {
            return this.$store.state.productViewContext.comparisonEnabled;
        }
    },
    methods: {
        showComparisonModal: function(){
            if (this.buttonActive)
                this.$store.commit('showComparisonModal');
        }
    }
}
</script>
<style>
div .comparison-banner
{
    position: fixed;
    width: 100%;
    height: 70px;
    bottom: 0;
    left: 0;
    background: #FD6600;
    opacity: 0.9;
    display: flex;
    align-items: center;
    justify-content: center;
    align-content: center;
}
.comparison-banner .comparison-button
{
    cursor: pointer;
}
.comparison-banner .comparison-button.active
{
    color: #5738FF;
    font: normal normal 900 18px/18px "Avenir Book";
}

.scroll-enter-active {
  transition: all .3s ease;
}
.scroll-leave-active {
  transition: all .8s cubic-bezier(1.0, 0.5, 0.8, 1.0);
}
.scroll-enter, .scroll-leave-to
{
  transform: translateY(70px);
  opacity: 0;
}
</style>