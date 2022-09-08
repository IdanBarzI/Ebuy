import React, { useState, useRef, useEffect } from "react";
import { faArrowRight } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Formik } from "formik";
import { useAuth } from "../../context/AuthContext";
import AnimatedLetters from "../AnimatedLetters";
import useAxios from "../../hooks/use-axios";

import "./index.scss";

const RegisterClub = () => {
  const [letterClass, setLetterClass] = useState("text-animate");

  useEffect(() => {
    let timeoutId = setTimeout(() => {
      setLetterClass("text-animate-hover");
    }, 4000);

    return () => {
      clearTimeout(timeoutId);
    };
  }, []);
  const { signIn } = useAuth();

  const {
    isLoading,
    fetchError,
    sendRequest: sendRegisterClubMemberRequest,
  } = useAxios();

  const registerClubMember = async (user) => {
    try {
      await sendRegisterClubMemberRequest(
        {
          method: "POST",
          url: `ClubMember/Register`,
          data: { ...user, purchasedProducts: [] },
        },
        (data) => {
          signIn(data);
        }
      );
    } catch (e) {}
  };
  return (
    <div className="login-club">
      <div className="overlay" />
      <h1 className="login-headers">
        <AnimatedLetters
          letterClass={letterClass}
          strArray={"Register".split("")}
          idx={5}
        />
      </h1>
      <h2 className="login-headers">
        <AnimatedLetters
          letterClass={letterClass}
          strArray={"Club Member".split("")}
          idx={13}
        />
      </h2>
      <Formik
        initialValues={{
          loginName: "",
          email: "",
          password: "",
          repassword: "",
          addres: "",
        }}
        validate={(values) => {
          const errors = {};
          if (!values.email) {
            errors.email = "Email is Required";
          } else if (
            !/^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}$/i.test(values.email)
          ) {
            errors.email = "Invalid email address";
          }
          if (!values.password) {
            errors.password = "Password is Required";
          }
          if (!values.loginName) {
            errors.loginName = "User Name is Required";
          }
          if (values.password !== values.repassword) {
            errors.repassword = "Passwords must match";
          }
          if (!values.addres) {
            errors.addres = "Address is Required";
          }
          return errors;
        }}
        onSubmit={(values, { setSubmitting }) => {
          delete values.repassword;
          registerClubMember(values);
          setTimeout(() => {
            setSubmitting(false);
          }, 400);
        }}
      >
        {({
          values,
          errors,
          touched,
          handleChange,
          handleBlur,
          handleSubmit,
          isSubmitting,
        }) => (
          <form className="form" onSubmit={handleSubmit}>
            <div style={{ display: "flex", gap: "32px" }}>
              <div
                style={{
                  display: "flex",
                  flexDirection: "column",
                  alignItems: "flex-start",
                }}
              >
                <input
                  placeholder="User Name *"
                  name="loginName"
                  required
                  onChange={handleChange}
                  onBlur={handleBlur}
                  value={values.loginName}
                ></input>
                <em>
                  {errors.loginName && touched.loginName && errors.loginName}
                </em>
              </div>
              <div
                style={{
                  display: "flex",
                  flexDirection: "column",
                  alignItems: "flex-start",
                }}
              >
                <input
                  placeholder="Email *"
                  type="email"
                  name="email"
                  onChange={handleChange}
                  onBlur={handleBlur}
                  value={values.email}
                ></input>
                <em>{errors.email && touched.email && errors.email}</em>
              </div>
            </div>
            <div style={{ display: "flex", gap: "32px" }}>
              <div
                style={{
                  display: "flex",
                  flexDirection: "column",
                  alignItems: "flex-start",
                }}
              >
                <input
                  placeholder="Password *"
                  required
                  type="password"
                  name="password"
                  autoComplete="new-password"
                  maxLength={10}
                  minLength={6}
                  onChange={handleChange}
                  onBlur={handleBlur}
                  value={values.password}
                ></input>
                <em>
                  {errors.password && touched.password && errors.password}
                </em>
              </div>
              <div
                style={{
                  display: "flex",
                  flexDirection: "column",
                  alignItems: "flex-start",
                }}
              >
                <input
                  placeholder="Renter Password *"
                  required
                  type="password"
                  name="repassword"
                  autoComplete="new-password"
                  onChange={handleChange}
                  onBlur={handleBlur}
                  value={values.repassword}
                ></input>
                <em>
                  {errors.repassword && touched.repassword && errors.repassword}
                </em>
              </div>
              <div
                style={{
                  display: "flex",
                  flexDirection: "column",
                  alignItems: "flex-start",
                }}
              >
                <input
                  placeholder="Address *"
                  required
                  type="Address"
                  name="addres"
                  onChange={handleChange}
                  onBlur={handleBlur}
                  value={values.addres}
                ></input>
                <em>{errors.addres && touched.addres && errors.addres}</em>
              </div>
            </div>
            <button
              className="login-button"
              type="submit"
              disabled={isSubmitting}
            >
              <p>Register</p>
              <FontAwesomeIcon icon={faArrowRight} />
            </button>
          </form>
        )}
      </Formik>
    </div>
  );
};

export default RegisterClub;
