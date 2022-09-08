import React from "react";
import CartDrawer from "../Layout/TopBar/Cart/CartDrawer";
import Card from "./Card";
import "./index.scss";
import Shipment from "./Shipment";

const Checkout = () => {
  return (
    <div className="checkout">
      <CartDrawer />
      <div>
        <Shipment />
        <Card />
      </div>
    </div>
  );
};

export default Checkout;
