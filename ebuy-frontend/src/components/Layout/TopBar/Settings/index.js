import React, { useEffect, useState } from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faCog } from "@fortawesome/free-solid-svg-icons";
import LanguageSelect from "./LanguageSelect";
import { useAuth } from "../../../../context/AuthContext";

import "./index.scss";
import Cart from "../Cart";

const Settings = (props) => {
  const { logoutFromSystem, logoutToHome } = useAuth();
  return (
    <div className="settings-container">
      <LanguageSelect />
      <button
        onClick={props.page === "products" ? logoutToHome : logoutFromSystem}
      >
        Logout
      </button>
      <div className="cart">{props.page === "products" && <Cart />}</div>
    </div>
  );
};

export default Settings;
