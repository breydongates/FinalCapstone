<!-- Main Application Template. 
     Note that you have classes from bootstrap available to you.
     See https://getbootstrap.com/docs/4.5/getting-started/introduction/ for reference on bootstrap -->
<template>
<body>
  <!-- If you start to get random styling you don't like, remove container from this div -->
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
#viewComic{
   display: inline-flex;
  flex-direction: row;
  flex-wrap: wrap;
}
.comicCardBubble {
  position: relative;
  font-family: sans-serif;
  font-size: 18px;
  line-height: 24px;
  width: 300px;
  background: #fff;
  border-radius: 40px;
  padding: 24px;
  text-align: center;
  color: #000;
  padding: 10px;
  margin-bottom: 10%;
  margin-top: 10%;
  border: 2px solid black;
};

.comicCardBubble-bottom-left:before {
  content: "";
  width: 0px;
  height: 0px;
  position: absolute;
  border-left: 24px solid #fff;
  border-right: 12px solid transparent;
  border-top: 12px solid #fff;
  border-bottom: 20px solid transparent;
  left: 32px;
  bottom: -24px;
  
}

#comicView{
  border-radius: 12px;
  background-image: radial-gradient(circle, lightcoral, tomato);
  display: flex;
  flex-wrap: wrap;
  font-family: 'Comic Sans', cursive;
  justify-content: left;
  align-content: left;
  position:absolute;
  top: 15rem;
  left: 15rem;
  bottom: 5rem;
  right: 5rem;
  text-align: center;
  border: 10px solid white;
  box-shadow: 0 6px 6px -6px #000;
  color: black;
  padding: 10%;
  margin: 5%;
};
#comicView > h1{
    background-color:#fff;
  border-left:solid 2px #000;
  border-bottom:solid 2px #000;
  margin:0;
  padding:3px 10px;
  right:-1%;
  position:absolute;
  top:-1%;
  transform:skew(-15deg);
}; 



#addComicButton{
    background-color:#fff;
  border:solid 2px #000;
  margin:0;
  padding:3px 10px;
   bottom:-2px;
  position:absolute;
  left:-5px;
  transform:skew(-15deg);
};
.yourCollections{
    border-radius: 12px;
  background-image: radial-gradient(circle, lightcoral, tomato);
  display: flex;
  flex-wrap: wrap;
  font-family: 'Comic Sans', cursive;
  justify-content: left;
  align-content: left;
  position:absolute;
  top: 15rem;
  left: 15rem;
  bottom: 5rem;
  right: 5rem;
  text-align: center;
  border: 10px solid white;
  box-shadow: 0 6px 6px -6px #000;
  color: black;
  padding: 10%;
  margin: 5%;
};
.yourCollections > h1 {
    background-color:#fff;
  border-left:solid 2px #000;
  border-bottom:solid 2px #000;
  margin:0;
  padding:3px 10px;
  right:-1%;
  position:absolute;
  top:-1%;
  transform:skew(-15deg);
};

.collectionBubble {
  position: relative;
  font-family: sans-serif;
  font-size: 18px;
  line-height: 24px;
  width: 300px;
  background: #fff;
  border-radius: 40px;
  padding: 24px;
  text-align: center;
  color: #000;
  padding: 10px;
  margin-bottom: 10%;
  margin-top: 10%;
  border: 2px solid black;
};

.collectionBubble-bottom-left:before {
  content: "";
  width: 0px;
  height: 0px;
  position: absolute;
  border-left: 24px solid #fff;
  border-right: 12px solid transparent;
  border-top: 12px solid #fff;
  border-bottom: 20px solid transparent;
  left: 32px;
  bottom: -24px;
  
}



</style>