import axios from 'axios';


export default {

    viewAllPublicCollections(){
        return axios.get('/collections');
    },   
    
    viewAllCollectionsByUser() {
        return axios.get('/collections/user')
    },
    createCollection(newCollection) {
        return axios.post('/collections', newCollection);
    },
}