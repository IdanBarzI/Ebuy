import React from "react";
import { Outlet } from "react-router-dom";
// import Footer from "./Footer";
import TopBar from "./TopBar";
import { useSettings } from "../../context/SettingsContext";

import "./index.scss";
import "../../styles/_main.scss";

const Layout = () => {
  const { theme } = useSettings();
  console.log(theme);
  return (
    <div className={`app ${theme ? "light" : "dark"}`}>
      <TopBar />
      <Outlet />
    </div>
  );
};

export default Layout;
