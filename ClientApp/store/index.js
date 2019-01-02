import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios';

Vue.use(Vuex, Axios)

// TYPES
const SET_LOADING_STATUS = 'SET_LOADING_STATUS'
const SET_BUCKET_OBJECTS = 'SET_BUCKET_OBJECTS'

// STATE
const state = {
  loadingStatus: 'Loading bucket objects...',
  bucketName: 'bucket-brainsquad-demo',
  bucketObjects: []
}

//
const getters = {
  countObjects: state => {
    return state.bucketObjects.length
  }
}

// MUTATIONS
const mutations = {
  SET_LOADING_STATUS(state, status) {
    state.loadingStatus = status
  },
  SET_BUCKET_OBJECTS(state, bucketObjects) {
    state.bucketObjects = bucketObjects
  }
}

// ACTIONS
const actions = ({
 async fetchBucketObjects(context) {
   context.commit(SET_LOADING_STATUS, 'Loading bucket objects...')
   await Axios.get('/api/bucket/ListObjects')
    .then(response => {
      context.commit(SET_LOADING_STATUS, 'notLoading')
      context.commit(SET_BUCKET_OBJECTS, response.data)
    })
    .catch(error => {
      console.log(error)
    })
 }
})

export default new Vuex.Store({
  state,
  getters,
  mutations,
  actions
})
