import React from "react";
import { useSelector, useDispatch } from "react-redux";
import { cartActions } from "../../../store/Cart";
import "./index.scss";

const Filters = () => {
  const cartData = useSelector((state) => state.cart);
  const dispatch = useDispatch();
  console.log(cartData.textFilters);
  return (
    <div className="filters">
      {cartData.textFilters.map((filter) => (
        <input
          key={filter.index}
          placeholder={filter.name}
          value={filter.text}
          onChange={(e) =>
            dispatch(
              cartActions.filterByText({
                index: filter.index,
                value: e.target.value,
              })
            )
          }
        />
      ))}
      <button onClick={() => dispatch(cartActions.clearFilters())}>
        Clear
      </button>
    </div>
  );
};

export default Filters;
