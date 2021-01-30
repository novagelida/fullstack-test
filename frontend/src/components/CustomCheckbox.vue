<script>
import CustomCheckboxLabel from './CustomCheckboxLabel.vue';

export default {
    components: {
        CustomCheckboxLabel
    },
    props: {initiallyChecked:Boolean, cboxId:String, label:String, innerHtml:String, invert:Boolean},
    data: function() {
        return { isChecked: undefined };
    },
    computed: {
    },
    created: function () {
        this.isChecked = this.initiallyChecked;
    },
    methods: {
        toggleChecked: function()
        {
            this.isChecked = !this.isChecked;
            this.$emit('value-changed', this.isChecked);
        }
    }
}
</script>
<template>
    <div @click="toggleChecked()" class="stacked-checkbox" :class="{on: isChecked, inverted:invert}">
        <custom-checkbox-label v-if="invert" :cboxId=cboxId :label=label :innerHtml=innerHtml />
        <i class="custom-checkbox" :class="{'icon-check': isChecked}" :id=cboxId></i>
        <custom-checkbox-label v-if="!invert" :cboxId=cboxId :label=label :innerHtml=innerHtml />
    </div>
</template>
<style>
.stacked-checkbox
{
    display:flex;
    margin-top: 10px;
    height: 20px;
}
.custom-checkbox 
{
    display: inline-block;
    cursor: pointer;
    height: 16px;
    width: 16px;
    border: 2px solid #0000001A;
}
.stacked-checkbox.on .custom-checkbox
{
    display: inline-block;
    height: 20px;
    width: 20px;
    background: #5738FF;
    color: white;
    font-size: 12px;
    border: none;
}
.stacked-checkbox.on .custom-checkbox.icon-check:before
{
    position: relative;
    top: 5px;
    left: 4px;
}
.stacked-checkbox.inverted.on .custom-checkbox.icon-check:before
{
    left: -3px;
}
.stacked-checkbox.on label
{
    color: #5738FF;
}
.stacked-checkbox.on label i
{
    line-height: 0;
}
</style>