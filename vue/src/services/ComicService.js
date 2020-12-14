import axios from 'axios';


export default {
    
    addComic(newComic) {
        return axios.post('/Comics', newComic);
    },
    viewComicsByCollection(collectionId) {
        return axios.get(`/Comics/${collectionId}`);
    },
    viewComicsByCharacter(collectionId) {
        return axios.post(`/statsRequest/character/${collectionId}`);
    },
    viewComicsByPublisher(collectionId) {
        return axios.post(`/statsRequest/publisher/${collectionId}`);
    }, 
    viewAllPublicComics(){
        return axios.get('/Comics');
    },
    viewPublicComicsByCharacter() {
        return axios.post('/statsRequest/character');
    },
    viewPublicComicsByPublisher() {
        return axios.post('/statsRequest/publisher');
    },
    viewUserComicsByCharacter(user) {
        return axios.post(`/statsRequest/character/${user}`);
    },
    viewUserComicsByPublisher(user) {
        return axios.post(`/statsRequest/publisher/${user}`);
    }

}