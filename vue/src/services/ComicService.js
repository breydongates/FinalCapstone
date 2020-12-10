import axios from 'axios';


export default {
    
    addComic(newComic) {
        return axios.post('/Comics', newComic);
    },
    viewAllComics() {
        return axios.get('/Comics');
    },
}