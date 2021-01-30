<template>
    <div v-cloak class="availability-filter">
        <h1>SCEGLI PER</h1>
        <custom-checkbox 
            :initially-checked=true
            cbox-id="available-cbox" 
            label="Disponibili (24)" />
        <custom-checkbox 
            :initially-checked=true
            cbox-id="promo-cbox" 
            label="In promozione (13)" />
    </div>
</template>