import axios from 'axios';


export default {
    
    addComic(newComic) {
        return axios.post('/comics', newComic);
    },
    view() {
        return axios.get('/comics');
    },
}