<template>
    <div class="comicCard">  
        <section>
            Title: <b> {{Comic.title}} </b>
            Publisher: <b> {{Comic.publisher}} </b>          
           Description: <b> {{Comic.description}} </b>
        </section> 

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