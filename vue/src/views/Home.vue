<template>
  <div class="home">
    <h1>Home</h1>
    <p>You must be authenticated to see this</p>
    <router-link :to="{name: 'CreateCollection'}"> Create Collection </router-link>
    <router-link :to="{name: 'Collection'}"> View Collection </router-link>
    <p> Add Comic </p>
  </div>
</template>

<script>
export default {
  name: "home"
};
</script>
