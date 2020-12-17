<template>
<body>
  <div class="yourCollections">
    <h1> Add a New Collection </h1>
       <div class="inner">
        <create-collection />
       </div>
  </div>
</body>
</template>

<script>
import CreateCollection from "@/components/CreateCollection.vue";


export default {
    components: {
        CreateCollection,
    }
}
</script>

<style>
.inner{
  margin-top:15%;
}


</style>