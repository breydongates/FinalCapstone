<!-- Main Application Template. 
     Note that you have classes from bootstrap available to you.
     See https://getbootstrap.com/docs/4.5/getting-started/introduction/ for reference on bootstrap -->
<template>
<body>
  <div> <!-- If you start to get random styling you don't like, remove container from this div -->
    <div id="nav">
      <router-link class="nav-item" v-bind:to="{ name: 'home' }">
        <i class="fas fa-home"></i> <!-- This is a font awesome icon -->
        Home 
      </router-link>
      <router-link
        class="nav-item"
        v-bind:to="{ name: 'register' }"
        v-if="!$store.state.token">&nbsp;|&nbsp;Register</router-link>
      <router-link
        class="nav-item"
        v-bind:to="{ name: 'login' }"
        v-if="!$store.state.token">
        &nbsp;|&nbsp;Login
      </router-link>
      <router-link
        class="nav-item"
        v-bind:to="{ name: 'logout' }"
        v-if="$store.state.token">
        &nbsp;|&nbsp;Logout
      </router-link>
    </div>
    <router-view />
    <div>
      <home />
    </div>
  </div>
  
</body>
</template>

<script>
import Home from '@/components/Home.vue';

export default {
  components: {
    Home
  },
  
}
</script>

<!-- Application-Wide Styles go here. 
     Any valid CSS or SCSS is allowable here. See https://sass-lang.com/documentation/style-rules for info on SCSS -->
<style lang="scss">
html {
  color: red;
  background-image: url(assets/updatedBackground.jpg);
  background-size: cover;
  font-family: 'Comic Sans', cursive;
  
};


#nav {
   background-color:#fff;
  border:solid 2px #000;
  margin:0;
  padding:3px 10px;
  left:-6px;
  position:absolute;
  top:-2px;
  transform:skew(-15deg);
};

.home {
   background-color:#fff;
  border:solid 2px #000;
  margin:0;
  padding:3px 10px;
   bottom:-2px;
  position:absolute;
  right:-6px;
  transform:skew(-15deg);
};
 #app {
  background-color:#fff;
  border:solid 2px #000;
  border-radius:12px;
  display:inline-block;
  margin:.5em;
  padding:.5em 1em;
  position:absolute;
  top: 10rem;
  left: 10rem;
  bottom: 10rem;
  right: 10rem;
  
};
#app:before {
  border:solid 12px transparent;
  border-left:solid 12px #000;
  border-top:solid 12px #000;
  bottom:-24px;
  content:"";
  height:0;
  left:24px;
  position:absolute;
  transform:skew(-15deg);
  width:0;
};
#app:after {
  border:solid 10px transparent;
  border-left:solid 10px #fff;
  border-top:solid 10px #fff;
  bottom:-19px;
  content:"";
  height:0;
  left:27px;
  position:absolute;
  transform:skew(-15deg);
  width:0;
};
li {
   list-style: none;
};
li::before{
   content: '';
   display: inline-block;
   height: 1em;
   width: 1em;
background-image: url(assets/Boom.png);
background-size: contain;
background-repeat: no-repeat;
border-radius: 50%;
};
h1 {
    text-align: center;
};




</style>