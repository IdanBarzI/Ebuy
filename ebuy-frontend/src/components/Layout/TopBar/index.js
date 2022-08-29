import React, { useState, useRef } from "react";
import Toggle from "../../../UiKit/Toggle";
import { useSettings } from "../../../context/SettingsContext";
import { useAuth } from "../../../context/AuthContext";
import { NavLink } from "react-router-dom";
import Cart from "./Cart";
import img from "../../../assets/images/Navigation/Rectangle 5.png";
import img2 from "../../../assets/images/Navigation/Polygon 1.png";

import "./index.scss";
import Settings from "./Settings";

const TopBar = () => {
  const { onThemeSwitch, theme } = useSettings();

  const { logoutToHome, setUser, loggedIn, user } = useAuth();

  const handleLogout = async () => {
    try {
      // await logout();
    } catch (e) {}
  };

  return (
    <>
      {loggedIn && (
        <header className="header">
          <img src={img} height="50px" alt="topbar" className="bar" />
          <nav className="nav">
            {!user ? (
              <ul>
                <>
                  <li>
                    <NavLink
                      className={(navData) => {
                        if (navData.isActive) {
                          return "active";
                        }
                        return "";
                      }}
                      to={`/Home`}
                    >
                      <>
                        <img src={img2} className="arrow"></img>
                        <p>Home</p>
                      </>
                    </NavLink>
                  </li>
                  <li>
                    <NavLink
                      className={(navData) =>
                        navData.isActive ? "active" : ""
                      }
                      to="/login-club"
                    >
                      <img src={img2} className="arrow"></img>
                      <p>Login</p>
                    </NavLink>
                  </li>
                  <li>
                    <NavLink
                      className={(navData) =>
                        navData.isActive ? "active" : ""
                      }
                      to="/casual-login-club"
                    >
                      <img src={img2} className="arrow"></img>
                      <p>Casual Login</p>
                    </NavLink>
                  </li>
                  <li>
                    <NavLink
                      className={(navData) =>
                        navData.isActive ? "active" : ""
                      }
                      to="/register-club"
                    >
                      <img src={img2} className="arrow"></img>
                      <p>Register</p>
                    </NavLink>
                  </li>
                  <li className="last">
                    <Settings />
                  </li>
                </>
              </ul>
            ) : (
              <ul className="inner-site">
                <>
                  <li>
                    <NavLink
                      className={(navData) => {
                        if (navData.isActive) {
                          return "active";
                        }
                        return "";
                      }}
                      to={`/Products`}
                    >
                      <>
                        <img src={img2} className="arrow"></img>
                        <p>Products</p>
                      </>
                    </NavLink>
                  </li>
                  <li>
                    <NavLink
                      className={(navData) => {
                        if (navData.isActive) {
                          return "active";
                        }
                        return "";
                      }}
                      to={`/Checkout`}
                    >
                      <>
                        <img src={img2} className="arrow"></img>
                        <p>Checkout</p>
                      </>
                    </NavLink>
                  </li>
                  <li className="last">
                    <Settings page="products" />
                  </li>
                </>
              </ul>
            )}
          </nav>
        </header>
      )}
    </>
  );
};

export default TopBar;
