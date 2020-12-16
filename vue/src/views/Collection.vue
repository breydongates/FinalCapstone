<template>
  <div class="yourCollections">
      <h1> Your Collections </h1>
      <div style="overflow-y:auto">
      <view-collection />
      </div>
  </div>
</template>

<script>
import ViewCollection from "@/components/ViewCollection";

export default {
    components : {
        ViewCollection
    }
};
</script>

<style>


</style>