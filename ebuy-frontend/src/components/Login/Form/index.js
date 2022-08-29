import React, { useState, useRef, useEffect } from "react";
import { faArrowRight } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import AnimatedLetters from "../../AnimatedLetters";
import { useAuth } from "../../../context/AuthContext";
import gsap from "gsap";
import { Formik } from "formik";

import "./index.scss";

const Form = (props) => {
  const formRef = useRef();
  const { login } = useAuth();

  const [letterClass, setLetterClass] = useState("text-animate");

  useEffect(() => {
    if (!!formRef.current) {
      gsap.to(formRef.current, { opacity: 1, duration: 0.5, delay: 4 });
    }
  }, [formRef.current]);

  useEffect(() => {
    let timeoutId = setTimeout(() => {
      setLetterClass("text-animate-hover");
    }, 10000);

    return () => {
      clearTimeout(timeoutId);
    };
  }, []);

  const haddleSubmit = async (e) => {
    e.preventDefault();
  };
  return (
    <div className="form-container" ref={formRef}>
      <h1 className="login-headers">
        <AnimatedLetters
          letterClass={letterClass}
          strArray={"Login".split("")}
          idx={40}
        />
      </h1>
      <h2 className="login-headers">
        <AnimatedLetters
          letterClass={letterClass}
          strArray={"And start you'r adventure!".split("")}
          idx={46}
        />
      </h2>
      <Formik
        initialValues={{ email: "", password: "" }}
        validate={(values) => {
          console.log(values);
          const errors = {};
          if (!values.email) {
            errors.email = "Email is Required";
          } else if (
            !/^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}$/i.test(values.email)
          ) {
            errors.email = "Invalid email address";
          }
          if (!values.password) {
            console.log("first");
            errors.password = "Password is Required";
          }
          return errors;
        }}
        onSubmit={(values, { setSubmitting }) => {
          login();
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
          /* and other goodies */
        }) => (
          <form className="form login-form" onSubmit={handleSubmit}>
            <input
              placeholder="Email"
              type="email"
              name="email"
              onChange={handleChange}
              onBlur={handleBlur}
              value={values.email}
            ></input>
            <div className="input-error">
              {errors.email && touched.email && errors.email}
            </div>
            <input
              placeholder="Password"
              required
              type="password"
              name="password"
              autoComplete="new-password"
              onChange={handleChange}
              onBlur={handleBlur}
              value={values.password}
            />
            <div className="input-error">
              {errors.password && touched.password && errors.password}
            </div>
            <button
              className="login-button"
              type="submit"
              disabled={isSubmitting}
            >
              <p>Login</p>
              <FontAwesomeIcon icon={faArrowRight} />
            </button>
          </form>
        )}
      </Formik>
    </div>
  );
};

export default Form;
