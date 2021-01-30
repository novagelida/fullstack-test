<template>
    <div class="compare-product">
        <custom-checkbox class="compare-product-cbox"
            :initially-checked=false
            cbox-id="compare-cbox" 
            label="CONFRONTA"
            :invert=true
            @value-changed="onValueChanged" />
    </div>
</template>
<script>
export default {
    methods: {
        onValueChanged: function(isChecked) {
            if (isChecked)
                this.$emit('flagged-for-comparison');
            else
                this.$emit('deflagged-for-comparison');
        }
    }
}
</script>
<style>
.compare-product-cbox
{
    margin-top: 0;
    text-align: right;
    font: normal normal 900 12px/22px "Avenir Black";
    letter-spacing: 0.6px;
    color: #0000004D;
}
</style>