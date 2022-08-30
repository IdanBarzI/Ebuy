import React, { useState, useEffect } from "react";
import { useSelector, useDispatch } from "react-redux";
import { useNavigate } from "react-router-dom";
import { cartActions } from "../../../../../store/Cart";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import cover from "../../../../../assets/images/E-buy.png";
import {
  faAdd,
  faSubtract,
  faArrowRight,
} from "@fortawesome/free-solid-svg-icons";
import "./index.scss";

const CartDrawer = () => {
  const [show, setShow] = useState(false);
  const navigate = useNavigate();

  const cartData = useSelector((state) => state.cart);
  const dispatch = useDispatch();
  console.log(cartData);

  useEffect(() => {
    let timeoutId = setTimeout(() => {
      setShow(true);
    }, 1000);

    return () => {
      clearTimeout(timeoutId);
    };
  }, []);
  return (
    <>
      <div className="cart-page">
        <div
          className={` ${
            cartData.showCart
              ? `cart-overlay-show`
              : show
              ? `cart-overlay-hide`
              : "cart-overlay-hide-fast"
          }`}
          onClick={() => dispatch(cartActions.ToggelCart())}
        />
        <div
          className={`cart-drawer ${
            cartData.showCart
              ? ` cart-drawer-show`
              : show
              ? ` cart-drawer-hide`
              : "cart-drawer-hide-fast"
          }`}
        >
          {cartData.products.map((p) => {
            if (p && p.quntity > 0) {
              return (
                <div key={p.id} className="product">
                  <img src={cover} />
                  <div className="product-details">
                    <h1>{p.title}</h1>
                    <h3>Author: {p.author}</h3>
                    <p>Price: {p.price}$</p>
                    <div className="actions">
                      <FontAwesomeIcon
                        icon={faAdd}
                        color="rgb(32, 117, 3)"
                        onClick={() => dispatch(cartActions.AddProduct(p.id))}
                      />
                      <p>{p.quntity}</p>
                      <FontAwesomeIcon
                        icon={faSubtract}
                        color="rgb(177, 3, 3)"
                        onClick={() => dispatch(cartActions.SubProduct(p.id))}
                      />
                    </div>
                  </div>
                </div>
              );
            }
          })}
          <h1>Total Price: {cartData.totalPrice}$</h1>
          <button
            disabled={cartData.totalQuantity <= 0}
            onClick={() => navigate("/checkout")}
          >
            <p>CheckOut</p>
            <FontAwesomeIcon icon={faArrowRight} />
          </button>
          <div className="input-error">
            {cartData.totalQuantity <= 0 &&
              "You Need to have at least one item in yout cart to checkout"}
          </div>
        </div>
      </div>
    </>
  );
};

export default CartDrawer;
