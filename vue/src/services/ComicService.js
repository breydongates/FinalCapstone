import axios from 'axios';


export default {
    
    addComic(newComic) {
        return axios.post('/Comics', newComic);
    },
    viewAllComicsByCollectionId() {
        return axios.get('/Comics');
    },
}