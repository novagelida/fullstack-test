// OMG!!!!!!111 nesteded promises. We don't want that. That is horrible but...
// I was tired. I implemented this very quickly.
import axios from 'axios';

var basePath = './api';

export const fetchInitialData = function(store) {
    var login = '/login';

    axios.post(basePath + login, {
        userName: 'test',
        password: 'test'
    }).then(function(loginResponse){
        // This is also disgusting. Quite unsafe.
        if (!localStorage.getItem('accessToken'))
            localStorage.setItem('accessToken', loginResponse.data.token);
        retrieveData(loginResponse.data.token, store)
    }).catch(function(){
        retrieveData(localStorage.getItem('accessToken'), store)
    });
}

const retrieveData = function(token, store) {
    var getBoilers = '/boilers';
    axios.get(basePath+getBoilers, {
        headers: { Authorization: "Bearer " + token }
    })
    .then(function (response) {
        store.commit('setProductList', response.data.collection);
    }).catch(function (error) {
        window.alert("Errore nel recuperare i dati!");
        console.log(error);
    }); 
}