<template>
  <div>
    <p>
        Total Number Of Comics: {{totalNumberOfComics}}
    </p>
    <form v-on:submit.prevent="filterByPublisher()">
        <label for="Publisher" >
            Search by Publisher name:
        </label>
        <input type="text" id="Publisher" name="Publisher" v-model="statRequest.Publisher" />   
        <button type="submit">
            Search By Publisher
        </button>
    </form>
    <p>
        Total Number of Comics by {{this.statRequest.Publisher}} is {{totalNumberOfComicsByPublisher}}
    </p>
      <form v-on:submit.prevent="filterByCharacter()">
        <label for="Character" >
            Search by Character name:
        </label>
        <input type="text" id="Character" name="Character" v-model="statRequest.Character" />   
        <button type="submit">
            Search By Character
        </button>
    </form>
    <p>
        Total Number of Comics with {{this.statRequest.Character}} is {{totalNumberOfComicsByCharacter}}
    </p>
  </div>

</template>

<script>
import CollectionService from '../services/CollectionService.js'

 
export default {
    data() {
        return {
            totalNumberOfComics: 0,
            
            totalNumberOfComicsByPublisher: 0,
            totalNumberOfComicsByCharacter: 0,
            statRequest: {
                CollectionId: 0,
                Publisher:"",
                Character:"",
            }
        }
    },   
    created() {
        CollectionService.getCountOfAllComics()
        .then((response) => {
            if(response.status === 200) {
                this.totalNumberOfComics = response.data.length;            
            }
        })


    },
    methods: {
        filterByPublisher() {
            CollectionService.viewAllComicsByPublisher(this.statRequest)
            .then((response) => {
                if(response.status === 200) {
                    this.totalNumberOfComicsByPublisher = response.data.length;
                }
            })
        },
        filterByCharacter() {
            CollectionService.viewAllComicsByCharacter(this.statRequest)
            .then((response) => {
                if(response.status === 200) {
                    this.totalNumberOfComicsByCharacter = response.data.length;
                }
            })
        }
        
    },

}
</script>

<style>

</style>