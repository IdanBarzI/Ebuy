import React,{useRef} from "react";
import Loader from "../../../../../UiKit/Loader";
import "./index.scss";

const LanguageSelect = () => {
  return (
    <div>
      <select>
        <option>Hebrew </option>
        <option>English </option>
        <option>Deutsch </option>
        <option>Italiano </option>
      </select>
      <Loader/>
    </div>
  );
};

export default LanguageSelect;
