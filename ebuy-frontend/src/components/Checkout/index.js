import React from "react";
import CartDrawer from "../Layout/TopBar/Cart/CartDrawer";
import Card from "./Card";
import "./index.scss";
import Shipment from "./Shipment";

const Checkout = () => {
  return (
    <div className="checkout">
      <CartDrawer />
      <Shipment />
      <Card />
    </div>
  );
};

export default Checkout;
