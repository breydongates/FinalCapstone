import axios from 'axios';


export default {

    viewAllCollections(){
        return axios.get('/collections');
    },    
    createCollection(newCollection) {
        return axios.post('/collections', newCollection);
    },
}