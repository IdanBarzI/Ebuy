import React, { useState, useEffect } from "react";
import { useSelector, useDispatch } from "react-redux";
import { useNavigate } from "react-router-dom";
import { cartActions } from "../../../../../store/Cart";
import { productsActions } from "../../../../../store/Products";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import cover from "../../../../../assets/images/E-buy.png";
import {
  faAdd,
  faSubtract,
  faArrowRight,
} from "@fortawesome/free-solid-svg-icons";
import "./index.scss";

const CartDrawer = () => {
  const cartData = useSelector((state) => state.cart);
  const dispatch = useDispatch();

  const [show, setShow] = useState(false);
  const navigate = useNavigate();

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
          {cartData.cartProducts.map((p) => {
            return (
              <div key={p.id} className="product">
                <div className="product-details">
                  <h1>{p.title}</h1>
                  <h3>Author: {p.author}</h3>
                  <p>Price: {p.bogo ? <>FREE</> : <>{p.price} $</>}</p>
                  <div className="actions">
                    {p.bogo ? (
                      <>BOGO</>
                    ) : (
                      <FontAwesomeIcon
                        icon={faSubtract}
                        size="lg"
                        color="rgb(177, 3, 3)"
                        onClick={() => {
                          dispatch(cartActions.SubProduct({ id: p.id }));
                          dispatch(productsActions.AddProduct({ product: p }));
                        }}
                      />
                    )}
                  </div>
                </div>
              </div>
            );
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
