import http from './http-common';
import axios from 'axios';

let PATH=`http://localhost:8080/ebuy`;
const getAllCountries = () => {
    return http.get(`${PATH}/getAllCountries`);
  };

  const getAllStates = (country) => {
    if (country.trim()==="US") {
    return http.get(`${PATH}/getAllStates`);
    }
  };



export default {
    getAllCountries,
    getAllStates
  };