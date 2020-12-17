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
   font-family: 'Comic Sans', cursive;
   font-size: 110%;
 background-color:#fff;
  border:solid 2px #000;
  border-radius:12px;
  display:inline-block;
  margin:5em;
  padding: 5em 1em;
  position: absolute;
  top: 50%;
  left: 30%;
  
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
#app::after{
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
}


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
  font-family: 'Comic Sans', cursive;
  font-size: 18px;
  line-height: 24px;
  width: 300px;
  background: #fff;
  border-radius: 40px;
  padding: 24px;
  text-align: center;
  color: #000;
  padding: 10px;
  margin-bottom: 5rem;
  margin-top: 7rem;
  border: 2px solid black;
  padding-inline-start: 65px;
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




#addComicButton{
  font-family: 'Comic Sans', cursive;
    background-color:#fff;
  border-top:solid 2px #000;
  border-right:solid 2px #000;
  margin:0;
  padding:8px 10px;
  padding-left:40px;
   bottom:-2px;
  position:absolute;
  left:-27px;
  transform:skew(-15deg);
};
.yourCollections{

  height: 60%;
  width:70%;
    border-radius: 12px;
  background-image: radial-gradient(circle, lightcoral, tomato);
  display: inline;
  flex-wrap: wrap;
  font-family: 'Comic Sans', cursive;
  justify-content: right;
  align-content: right;
  position:absolute;
  top: 15rem;
  left: 15rem;
  bottom: 5rem;
  right: 5rem;
  text-align: center;
  border: 15px solid white;
  box-shadow: 0 6px 6px -6px #000;
  color: black;
  
};
.yourCollections > h1 {
    background-color:#fff;
  border-right:solid 2px #000;
  border-bottom:solid 2px #000;
  margin:0;
  padding:3px 10px;
  left:-.7%;
  position:absolute;
  top:-1%;
  transform:skew(-15deg);
};
.yourCollections > ul {
  float:right; 
  margin-top: 5rem;
  margin-bottom: 5rem;
}


.collectionBubble {
background-color:#fff;
  border:solid 2px #000;
  border-radius:12px;
  margin-bottom: 3%;
  margin:1.5em;
  padding:.5em 1em;
  padding-left:4em;
  padding-right:4em;
  position: relative;
  padding-bottom: 2%;
};

.collectionBubble:before {
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
.collectionBubble::after{
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
}
.collectionBubbleAddComic {
background-color:#fff;
  border:solid 2px #000;
  border-radius:12px;
 
  margin:.5em;
  padding:.5em 1em;
  position: center;
  padding-bottom: 2%;
  
};

.collectionBubbleAddComic:before {
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
.collectionBubbleAddComic::after{
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
}

.collectionList{
  height: 85%;
  padding-top: 10%;
  padding-left: 60%;
  padding-top: 1%;
  padding-bottom: 10%;
}
.statsBox{
  font-family: 'Comic Sans', cursive;
     background-color:#fff;
  border-top:solid 2px #000;
  border-right:solid 2px #000;
  margin:0;
  padding:.1% 1%;
   bottom:-2px;
  position: absolute;
  left:-27px;
  padding-left:40px;
  transform:skew(-15deg);
}
li{
  list-style-type: none;
}



</style>