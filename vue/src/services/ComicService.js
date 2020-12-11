import axios from 'axios';


export default {
    
    addComic(newComic) {
        return axios.post('/Comics', newComic);
    },
    viewComicsByCollection(collectionId) {
        return axios.get(`/Comics/${collectionId}`);
    },

}