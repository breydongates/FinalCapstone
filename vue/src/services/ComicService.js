import axios from 'axios';


export default {
    
    addComic(newComic) {
        return axios.post('/comics', newComic);
    },
    viewAllComics() {
        return axios.get('/comics');
    },
}