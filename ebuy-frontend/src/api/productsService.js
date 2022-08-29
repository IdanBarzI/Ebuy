import http from './http-common';
import axios from 'axios';

let PATH=`http://localhost:8080/ebuy`;
const getAllProducts = () => {
    return http.get(`${PATH}/getAllProducts`);
  };

  const getFilteredBooks = (author, title, keywords, category) => {
    return http.get(`${PATH}/asset/${author}${title}${keywords}${category}`);
  };


export default {
    getAllProducts,
    getFilteredBooks
  };