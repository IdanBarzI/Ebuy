import { createSlice } from "@reduxjs/toolkit";
import products from "../../mocks/products";
const initialAreaState = {
  showCart: false,
  products: [],
  productsCopy: [],
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
      state.products = action.payload;
      state.productsCopy = action.payload;
    },
    AddProduct(state, action) {
      console.log(action.payload.bogo);
      state.products = state.products.map((p) => {
        if (p.id === action.payload.id) {
          if (!action.payload.bogo) {
            state.totalPrice += p.price;
          }
          p.quntity ? p.quntity++ : (p.quntity = 1);
          state.totalQuantity++;
        }
        return p;
      });
    },
    SubProduct(state, action) {
      state.products = state.products.map((p) => {
        if (p.id === action.payload && p.quntity > 0) {
          p.quntity--;
          state.totalPrice -= p.price;
          state.totalQuantity--;
        }
        return p;
      });
    },
    filterByText(state, action) {
      console.log(action.payload.value);
      state.textFilters[action.payload.index - 1].text = action.payload.value;
      state.products = state.productsCopy.map((product) => {
        const filtered = state.textFilters.filter((filter) => {
          return String(product[filter.name])
            .toLocaleLowerCase()
            .includes(filter.text.toLocaleLowerCase());
        });
        if (filtered.length >= state.textFilters.length) {
          return product;
        } else {
          return null;
        }
      });
    },
    clearFilters(state, action) {
      state.textFilters = state.textFilters.map((filter) => {
        filter.text = "";
        return filter;
      });
      state.products = state.productsCopy;
    },
  },
});

export const cartActions = cartSlice.actions;

export default cartSlice.reducer;
