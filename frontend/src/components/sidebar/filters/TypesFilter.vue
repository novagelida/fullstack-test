
<template>
    <div v-cloak class="types-filter">
        <h1>TIPOLOGIA</h1>
        <custom-checkbox 
            :initially-checked=false
            cbox-id="condenser-cbox"
            label="A Condensazione (3)" />
        <custom-checkbox 
            :initially-checked=false
            cbox-id="open-chamber-cbox"
            label="Camera Aperta (7)"/>
        <custom-checkbox 
            :initially-checked=false
            cbox-id="closed-chamber-cbox"
            label="Camera Stagna (4)" />
    </div>
</template>