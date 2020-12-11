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
  background: url(assets/squigglybubble.svg);
  font-family: SequentialistBB, cursive;
  font-size: 2.5vw;
  display: flex;
  justify-content: center;
  align-content: center;
  position:absolute;
  top: 15rem;
  left: 15rem;
  bottom: 5rem;
  right: 5rem;
  text-align: center;
  font-size: 2.4vw;
  font-style: italic;
  padding: 4% 6% 12% 0%;
};
#app.span {
  display:block;
  font-size: 3vw;
  font-weight: bold;
}

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
.comicCard {
  background-color: lightcoral;
  font-family: SequentialistBB, cursive;
  border: 2px solid lavender;
  border-radius: 10px;
  width: 250px;
  height: 550 px;
  margin: 20 px;
};

#comicView{
  border-radius: 12px;
  background-image: radial-gradient(circle, lightcoral, tomato);
  display: flex;
  justify-content: center;
  align-content: center;
  position:absolute;
  top: 15rem;
  left: 15rem;
  bottom: 5rem;
  right: 5rem;
  text-align: center;
  border: 4px solid white;
  color: black;
};
#comicView > h1{
    background-color:#fff;
  border:solid 2px #000;
  margin:0;
  padding:3px 10px;
  left:-6px;
  position:absolute;
  top:-2px;
  transform:skew(-15deg);
}; 
#comicView > ul {
   background-color:#fff;
  border:solid 2px #000;
  box-shadow:0 6px 6px -6px #000;
  display:inline-block;
  flex:1 1;
  height:200px;
  margin:1vmin;
  overflow:hidden;
  position:relative;
};
#comicView:nth-child(1){
  flex-basis: 200px;
};
#comicView:nth-child(2){
  flex-basis: 200px;
};
#comicView:nth-child(3){
  flex-basis: 200px;
};
#comicView:nth-child(4){
  flex-basis: 200px;
};

#addComicButton{
    background-color:#fff;
  border:solid 2px #000;
  margin:0;
  padding:3px 10px;
   bottom:-2px;
  position:absolute;
  right:-5px;
  transform:skew(-15deg);
};




</style>