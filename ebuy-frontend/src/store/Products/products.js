import { createSlice } from "@reduxjs/toolkit";

const initialAreaState = {
  products: [],
  productsCopy: [],
  textFilters: [
    { index: 1, name: "author", text: "" },
    { index: 2, name: "title", text: "" },
    { index: 3, name: "keywords", text: "" },
    { index: 4, name: "category", text: "" },
  ],
};
const productsSlice = createSlice({
  name: "products",
  initialState: initialAreaState,
  reducers: {
    SetProducts(state, action) {
      state.products = action.payload;
      state.productsCopy = action.payload;
      console.log("first");
    },
    filterByText(state, action) {
      state.textFilters[action.payload.index - 1].text = action.payload.value;
      state.products = state.productsCopy.filter((product) => {
        const filtered = state.textFilters.filter((filter) => {
          console.log(
            String(product[filter?.name])
              .toLocaleLowerCase()
              .includes(filter.text.toLocaleLowerCase())
          );
          return String(product[filter?.name])
            .toLocaleLowerCase()
            .includes(filter.text.toLocaleLowerCase());
        });
        if (filtered.length >= state.textFilters.length) {
          return true;
        }
      });
    },
    AddProduct(state, action) {
      state.products = [...state.products, action.payload.product];
      state.productsCopy = [...state.products];
    },
    SubProduct(state, action) {
      state.textFilters = state.textFilters.map((filter) => {
        filter.text = "";
        return filter;
      });
      state.products = state.productsCopy;
      state.products = state.products.filter((p) => {
        if (p.id === action.payload.id) {
          return false;
        }
        return true;
      });
      state.productsCopy = [...state.products];
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

export const productsActions = productsSlice.actions;

export default productsSlice.reducer;
