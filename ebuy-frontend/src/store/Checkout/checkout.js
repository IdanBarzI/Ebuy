import { createSlice } from "@reduxjs/toolkit";

const initialAreaState = {
  shipment: {
    shipmentOption: "Email",
    shipmentData: {},
  },
  card: {},
};
const checkoutSlice = createSlice({
  name: "checkout",
  initialState: initialAreaState,
  reducers: {
    submitShipmentChange(state, action) {
      state.shipment[action.payload.field] = action.payload.value;
    },
    setShipmentData(state, action) {
      console.log(action.payload.field);
      state.shipment.shipmentData[action.payload.field] = action.payload.value;
    },
  },
});

export const checkoutActions = checkoutSlice.actions;

export default checkoutSlice.reducer;
