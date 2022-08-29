import http from './http-common';
import axios from 'axios';

let PATH=`http://localhost:8080/ebuy`;
const getShipmentOption = () => {
    return http.get(`${PATH}/getShipmentOption`);
  };

const getCreditCardType = () => {
    return http.get(`${PATH}/getCreditCardType`);
  };
  
export default {
    getShipmentOption,
    getCreditCardType
  };