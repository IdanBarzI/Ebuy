import { createSlice } from "@reduxjs/toolkit";

const initialAreaState = {
  showCart: false,
  products: [],
  productsCopy: [],
  cartProducts: [],
  textFilters: [
    { index: 1, name: "author", text: "" },
    { index: 2, name: "title", text: "" },
    { index: 3, name: "keywords", text: "" },
    { index: 4, name: "category", text: "" },
  ],
  totalPrice: 0,
  totalQuantity: 0,
};
const cartSlice = createSlice({
  name: "cart",
  initialState: initialAreaState,
  reducers: {
    ToggelCart(state, action) {
      state.showCart = !state.showCart;
    },
    SetProducts(state, action) {
      state.productsCopy = action.payload;
    },
    AddProduct(state, action) {
      state.cartProducts = [
        ...state.cartProducts,
        ...state.productsCopy.filter((p) => {
          if (p.id === action.payload.id) {
            console.log(action.payload.bogo);
            p.bogo = false;
            if (action.payload.bogo) {
              console.log("isbogo");
              p.bogo = true;
            } else {
              state.totalPrice += p.price;
            }
            return true;
          }
        }),
      ];
      state.totalQuantity++;
    },
    SubProduct(state, action) {
      let flag = false;
      state.cartProducts = state.cartProducts.filter((p) => {
        console.log(p.bogo);
        if (flag || p.id !== action.payload.id) {
          return true;
        } else if (p.bogo) {
          state.totalPrice = state.totalPrice;
          flag = true;
        } else {
          state.totalPrice -= p.price;
          flag = true;
        }
      });
      state.totalQuantity--;
    },
  },
});

export const cartActions = cartSlice.actions;

export default cartSlice.reducer;
