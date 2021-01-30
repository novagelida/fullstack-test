<template>
    <div v-cloak class="usage-filter">
        <h1>UTILIZZO</h1>
        <custom-checkbox 
            :initially-checked=false
            cbox-id="outside-cbox" 
            label="Esterno (4)" />
        <custom-checkbox 
            :initially-checked=false
            cbox-id="inside-cbox" 
            label="Interno (3)" />
        <!--TYPO NELL\'ORIGINALE-->
        <custom-checkbox 
            :initially-checked=false
            cbox-id="both-cbox" 
            label="Interno / Iterno (2)" />
    </div>
</template>