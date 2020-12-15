import axios from 'axios';


export default {

    viewAllPublicCollections(){
        return axios.get('/collections');
    },   
    
    viewAllCollectionsByUser() {
        return axios.get('/collections/user');
    },

    createCollection(newCollection) {
        return axios.post('/collections', newCollection);
    },
    getCountOfAllComics(){
        return axios.get('/collections/allComicsStats/count');
    },
    viewAllComicsByPublisher(statRequest) {
        return axios.post('/collections/allComicsStats/publisher', statRequest);
    },
    viewAllComicsByCharacter(statRequest) {
        return axios.post('/collections/allComicsStats/character', statRequest);
    },
    getNumOfComicsInCollection(CollectionId) {
        return axios.get('/collections/'+ CollectionId);
    },
    getComicsByPubInCollection(statRequest) {
        return axios.post('/collections/statsRequest/publisher', statRequest);
    },
    getComicsByCharInCollection(statRequest) {
        return axios.post('/collections/statsRequest/character', statRequest);
    }
   
}