<template>
<div class="custom-checkbox-label">
    <label :for=cboxId v-if=label>{{label}}</label>
    <label :for=cboxId v-if=innerHtml v-html="innerHtml">{{innerHtml}}</label>
</div>
</template>
<script>
export default {
    props: ['label', 'innerHtml', 'cboxId']
}
</script>
<style>
div .custom-checkbox-label label
{
    margin-left: 10px;
    line-height: 22px;
    cursor: pointer;
}
div .inverted .custom-checkbox-label label
{
    margin-right: 10px;
    line-height: 22px;
}
</style>