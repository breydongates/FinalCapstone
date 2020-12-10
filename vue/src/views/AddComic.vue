<template>
  <div> 
      <h1> Add a comic </h1>
     <create-comic />
  </div>
</template>

<script>
import CreateComic from "@/components/CreateComic.vue";

export default {
    name: "add-comic",
    components: {
       CreateComic,
    }


}
</script>

<style>

</style>