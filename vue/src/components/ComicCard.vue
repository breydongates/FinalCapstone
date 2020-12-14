<template>

    <div class="comicCardBubble comicCardBubble-bottom-left">  
        <ul>

            Title: <b> {{Comic.title}} </b>
            Publisher: <b> {{Comic.publisher}} </b>          
           Description: <b> {{Comic.description}} </b>
        </ul> 


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