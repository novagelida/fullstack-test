<template>
    <div v-cloak class="reviews-filter">
        <h1>RECENSIONI</h1>
        <custom-checkbox 
            :initially-checked=false
            cbox-id="1s-cbox" 
            innerHtml='
            <i class="icon-rating-on star"></i>
            <i class="icon-rating-on star"></i>
            <i class="icon-rating-on star"></i>
            <i class="icon-rating-on star"></i>
            <i class="icon-rating-on star"></i>
            (3)'/>
        <custom-checkbox 
            :initially-checked=true
            cbox-id="2s-cbox" 
            innerHtml='
            <i class="icon-rating-on star"></i>
            <i class="icon-rating-on star"></i>
            <i class="icon-rating-on star"></i>
            <i class="icon-rating-on star"></i>
            <i class="icon-rating-off star"></i>
            (14)'/>
        <custom-checkbox 
            :initially-checked=false
            cbox-id="3s-cbox" 
            innerHtml='
            <i class="icon-rating-on star"></i>
            <i class="icon-rating-on star"></i>
            <i class="icon-rating-on star"></i>
            <i class="icon-rating-off star"></i>
            <i class="icon-rating-off star"></i>
            (5)'/>
        <custom-checkbox 
            :initially-checked=false
            cbox-id="4s-cbox" 
            innerHtml='
            <i class="icon-rating-on star"></i>
            <i class="icon-rating-on star"></i>
            <i class="icon-rating-off star"></i>
            <i class="icon-rating-off star"></i>
            <i class="icon-rating-off star"></i>
            (1)'/>
        <custom-checkbox 
            :initially-checked=false
            cbox-id="5s-cbox" 
            innerHtml='
            <i class="icon-rating-on star"></i>
            <i class="icon-rating-of star"></i>
            <i class="icon-rating-off star"></i>
            <i class="icon-rating-off star"></i>
            <i class="icon-rating-off star"></i>
            (1)'/>      
    </div>
</template>