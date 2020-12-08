<template>
  <div class="home">
    <h1>Home</h1>
    <p>Project NAME</p> <!-- CHANGE ME -->
    <router-link :to="{name: 'CreateCollection'}"> Create Collection </router-link>
    <router-link :to="{name: 'Collection'}"> View Collection </router-link>
    <router-link :to="{name: 'AddComic'}"> Add Comic </router-link>
    <router-link :to="{name: 'Comic'}"> View Comics </router-link> 
    
  </div>
</template>

<script>
export default {
  name: "home"
};
</script>
