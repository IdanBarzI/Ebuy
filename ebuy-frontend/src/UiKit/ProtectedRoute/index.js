import React, { Fragment, useContext } from "react";
import { Navigate, Outlet } from "react-router-dom";
import AuthContext from "../../context/AuthContext";

const ProtectedRoute = (props) => {
  const { loggedIn } = useContext(AuthContext);
  return loggedIn ? <Outlet /> : <Navigate to="404" />;
};

export default ProtectedRoute;
