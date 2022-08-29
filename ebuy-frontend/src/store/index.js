import { configureStore } from "@reduxjs/toolkit";

import cartReducer from "./Cart";
import checkoutReducer from "./Checkout";

const store = configureStore({
  reducer: {
    cart: cartReducer,
    checkout: checkoutReducer,
  },
});

export default store;
