import React from "react";
import { useSelector, useDispatch } from "react-redux";
import { productsActions } from "../../../store/Products";
import "./index.scss";

const Filters = () => {
  const cartData = useSelector((state) => state.products);
  const dispatch = useDispatch();
  return (
    <div className="filters">
      {cartData.textFilters.map((filter) => (
        <input
          key={filter.index}
          placeholder={`${ filter.name.toString().charAt(0).toUpperCase() +  filter.name.toString().slice(1)}`}
          value={filter.text}
          onChange={(e) =>
            dispatch(
              productsActions.filterByText({
                index: filter.index,
                value: e.target.value,
              })
            )
          }
        />
      ))}
      <button onClick={() => dispatch(productsActions.clearFilters())}>
        Clear
      </button>
    </div>
  );
};

export default Filters;
