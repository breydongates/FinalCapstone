<template>

    <div class="collectionBubble">  
        <ul>

            Title: <b> {{Comic.title}} </b> <br />
            Publisher: <b> {{Comic.publisher}} </b> <br />       
           Description: <b> {{Comic.description}} </b>
           <!--Main Character: <b> {{Comic.mainCharacter}} </b>-->
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