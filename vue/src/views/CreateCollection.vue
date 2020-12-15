<template>
<body class="createCollection">
  <div>
      Add a New Collection 
        <create-collection />
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

.createCollection {
  display: flex;
  background-color:#fff;
  padding:20px;
  border-radius:30px;
  min-width:40px;
  max-width:220px;
  top: 40rem;
  left: 40rem;
  bottom: 5rem;
  right: 15rem;
  position:absolute;
  align-items:center;
  justify-content:center;
  text-align:center;
}
.createCollection:before,
.createCollection:after {
  content:"";
  background-color:#fff;
  border-radius:50%;
  display:block;
  position:absolute;
  z-index:-1;
}
.createCollection:before {
  width:44px;
  height:44px;
  top:-12px;
  left:28px;
  box-shadow:-50px 30px 0 -12px #fff;
}
.createCollection:after {
  bottom:-10px;
  right:26px;
  width:30px;
  height:30px;
  box-shadow:40px -34px 0 0 #fff,
             -28px -6px 0 -2px #fff,
             -24px 17px 0 -6px #fff,
             -5px 25px 0 -10px #fff;
  
}

</style>