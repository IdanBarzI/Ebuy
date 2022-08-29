import http from './http-common';
import axios from 'axios';

let PATH=`http://localhost:8080/ebuy`;
const getRegisterUser = () => {
    return http.get(`${PATH}/gerRegisterUser`);
  };

  const saveCasualUser = (data) => {
    return http.post(`${PATH}/saveCasualUser`, data);
  };

  const registerClubMemberUser = (data) => {
    return axios.post(`${PATH}/registerClubMemberUser`, data);
  };


export default {
    getRegisterUser,
    saveCasualUser, 
    registerClubMemberUser
  };