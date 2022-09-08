import { configureStore } from "@reduxjs/toolkit";

import cartReducer from "./Cart";
import productsReducer from "./Products";
import checkoutReducer from "./Checkout";

const store = configureStore({
  reducer: {
    cart: cartReducer,
    products: productsReducer,
    checkout: checkoutReducer,
  },
});

export default store;
