<template>
    <div v-cloak class="powered-by-filter">
        <h1>ALIMENTAZIONE</h1>
        <custom-checkbox 
            :initially-checked=false
            cbox-id="electricity-cbox" 
            label="Elettrica (11)" />
        <!-- TYPO NELL\'ORIGINALE? -->
        <custom-checkbox 
            :initially-checked=false
            cbox-id="gas-cbox" 
            label="Metano 1)" />
    </div>
</template>