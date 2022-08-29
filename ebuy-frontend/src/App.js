import logo from "./logo.svg";
import { Routes, Route, Navigate } from "react-router-dom";

import Layout from "./components/Layout";
import AuthContext from "./context/AuthContext";
import { useContext } from "react";

import Login from "./pages/Login";

import ProtectedRoute from "./UiKit/ProtectedRoute";
import Home from "./pages/Home";
import LoginClub from "./pages/SignIn";
import RegisterClub from "./pages/SignUp";

import "./App.scss";
import Products from "./pages/Products";
import CasualLogin from "./pages/CasualLogin";
import Checkout from "./components/Checkout";

const App = () => {
  const { loggedIn, user } = useContext(AuthContext);
  console.log(user);
  return (
    <>
      <Routes>
        <Route path="/" element={<Layout />}>
          <Route
            index
            element={
              !loggedIn ? (
                <Login />
              ) : user ? (
                <Navigate to="products" />
              ) : (
                <Navigate to="home" />
              )
            }
          />
          <Route path="/" element={<ProtectedRoute />}>
            <Route path="/Home" element={<Home />} />
            <Route path="/login-club" element={<LoginClub />} />
            <Route path="/casual-login-club" element={<CasualLogin />} />
            <Route path="/register-club" element={<RegisterClub />} />
            <Route
              path="/products"
              element={user ? <Products /> : <Navigate to="/404" />}
            />
            <Route
              path="/checkout"
              element={user ? <Checkout /> : <Navigate to="/404" />}
            />
          </Route>
        </Route>
      </Routes>
    </>
  );
};

export default App;
