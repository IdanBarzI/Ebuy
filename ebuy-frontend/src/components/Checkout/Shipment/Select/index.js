import React from "react";

const Select = (props) => {
  return (
    <select
      name={props.name}
      onChange={props.handleChange}
      onBlur={props.handleBlur}
      defaultValue={props.defaultValue}
    >
      {props.options.map((option) => {
        return <option>{option} </option>;
      })}
    </select>
  );
};

export default Select;
