import Vue from 'vue'
import Vuex from 'vuex'
Vue.use(Vuex)
export default new Vuex.Store({
    state: {
        name: '',
        pictureUrl: 'assets/images/!logged-user.jpg',
        systemName: '',
        operations: [],
    },
    mutations: {
        name(state, value) {
            state.name = value;
        },
        pictureUrl(state, value) {
            state.pictureUrl = value;
        },
        systemName(state, value) {
            state.systemName = value;
        },
        operations(state, value) {
            state.operations = value;
        }
    }
})