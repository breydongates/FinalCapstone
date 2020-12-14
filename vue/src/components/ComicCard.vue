<template>
    <div>  
        <h1>{{collections.name}}</h1>
        <h2>
            {{Comic.title}}
            {{Comic.publisher}}           
            {{Comic.description}}
        </h2> 

    </div>
</template>

<script>
export default {
    props: {
        Comic: Object,        
    }

}
</script>

<style>

</style>