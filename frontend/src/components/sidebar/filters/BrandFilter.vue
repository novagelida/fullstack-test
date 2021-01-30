<template>
    <div v-cloak class="brand-filter">
        <h1>MARCHE</h1>
        <custom-checkbox 
            :initially-checked=true
            cbox-id="ariston-cbox" 
            label="Ariston (4)" />
        <custom-checkbox 
            :initially-checked=true
            cbox-id="baxi-cbox" 
            label="Baxi (8)" />
        <!-- TYPO NELL\'ORIGINALE? -->
        <custom-checkbox 
            :initially-checked=true
            cbox-id="ariston-2-cbox" 
            label="Ariston (12)" />
    </div>
</template>
<style scoped>

</style>
<script>
export default {
    props: [],
    data: function() {
        return {            

        }
    },  
    computed: {
        
    },  
    methods: {
        valueChanged: function(value){
            window.alert(value);
        }
    }
}
</script>