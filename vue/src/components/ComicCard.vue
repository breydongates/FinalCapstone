<template>

    <div class="collectionBubble">  
        <ul>

            Title: <b> {{Comic.title}} </b> <br />
            Publisher: <b> {{Comic.publisher}} </b> <br />       
           Description: <b> {{Comic.description}} </b> <br />
           Main Character: <b> {{Comic.mainCharacter}} </b> <br />
           Issue Number: <b> {{Comic.edition}} </b> 
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