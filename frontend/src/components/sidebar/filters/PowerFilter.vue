<template>
    <div v-cloak class="power-filter">
        <h1>POTENZA NOMINALE (kW)</h1>
        <custom-checkbox 
            :initially-checked=false
            cbox-id="p1-cbox" 
            label="19.5 (1)" />
        <custom-checkbox 
            :initially-checked=false
            cbox-id="p2-cbox" 
            label="24 (5)" />
        <!--TYPO NELL\'ORIGINALE-->
        <custom-checkbox 
            :initially-checked=false
            cbox-id="p3-cbox" 
            label="da 30 a 34 (2)" />
    </div>
</template>