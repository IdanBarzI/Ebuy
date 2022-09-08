import React from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faCartShopping } from "@fortawesome/free-solid-svg-icons";
import { useSelector, useDispatch } from "react-redux";
import { cartActions } from "../../../../store/Cart";

const Cart = () => {
  const cartData = useSelector((state) => state.cart);
  const dispatch = useDispatch();

  return (
    <>
      <FontAwesomeIcon
        icon={faCartShopping}
        onClick={() => dispatch(cartActions.ToggelCart())}
      />
      <p>{cartData.totalQuantity}</p>
    </>
  );
};

export default Cart;
