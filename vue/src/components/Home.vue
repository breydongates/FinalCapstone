<template>
  <div class="home">
    <h1>Comic Book Database</h1>
    <!-- CHANGE ME -->
    <router-link :to="{ name: 'CreateCollection' }">
     Create Collection
    </router-link>
    <router-link :to="{ name: 'Collection' }">
      &nbsp;|&nbsp;View Your Collections
    </router-link>
  </div>
</template>

<script>

export default {
  name: "home",
}
</script>
