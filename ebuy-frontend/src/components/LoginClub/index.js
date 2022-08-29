import React, { useState, useRef, useEffect } from "react";
import { faArrowRight } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Formik } from "formik";
import AnimatedLetters from "../AnimatedLetters";
import { useAuth } from "../../context/AuthContext";
import useAxios from "../../hooks/use-axios";
import "./index.scss";
import Modal from "../../UiKit/Modal";

const LoginClub = () => {
  const [modalState, setModalState] = useState(false);
  const { signIn } = useAuth();

  const [letterClass, setLetterClass] = useState("text-animate");

  const {
    isLoading,
    fetchError,
    sendRequest: sendLoginClubRequest,
  } = useAxios();

  const loginClub = async (userName, passwrod) => {
    try {
      await sendLoginClubRequest(
        {
          method: "POST",
          url: `ClubMember/Login`,
          params: { userName, passwrod },
        },
        (data) => {
          signIn(data);
        }
      );
    } catch (e) {}
  };

  useEffect(() => {
    let timeoutId = setTimeout(() => {
      setLetterClass("text-animate-hover");
    }, 4000);

    return () => {
      clearTimeout(timeoutId);
    };
  }, []);

  return (
    <div className="login-club">
      <div className="overlay" />
      <Formik
        initialValues={{
          userName: "",
          email: "",
          password: "",
          repassword: "",
        }}
        validate={(values) => {
          const errors = {};
          if (!values.password) {
            errors.password = "Password is Required";
          }
          if (!values.userName) {
            errors.userName = "User Name is Required";
          }
          // console.log(errors);
          return errors;
        }}
        onSubmit={(values, { setSubmitting }) => {
          loginClub(values.userName, values.password);
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
          /* and other goodies */
        }) => (
          <form className="login-club-form" onSubmit={handleSubmit}>
            <h1 className="login-headers">
              <AnimatedLetters
                letterClass={letterClass}
                strArray={"Login".split("")}
                idx={5}
              />
            </h1>
            <h2 className="login-headers">
              <AnimatedLetters
                letterClass={letterClass}
                strArray={"Club Member".split("")}
                idx={11}
              />
            </h2>
            <div className="row first">
              <input
                placeholder="User Name"
                name="userName"
                required
                onChange={handleChange}
                onBlur={handleBlur}
                value={values.userName}
              ></input>
              <em>{errors.userName && touched.userName && errors.userName}</em>
            </div>
            <div className="row last">
              <input
                placeholder="Password"
                required
                type="password"
                name="password"
                autoComplete="new-password"
                onChange={handleChange}
                onBlur={handleBlur}
                value={values.password}
              ></input>
              <em>{errors.password && touched.password && errors.password}</em>
            </div>
            <div>
              <button
                className="login-club-button"
                type="submit"
                disabled={isSubmitting}
              >
                <p>Login</p>
                <FontAwesomeIcon icon={faArrowRight} />
              </button>
              {isSubmitting}
            </div>
            <em>{fetchError}</em>
          </form>
        )}
      </Formik>

      <Modal
        show={modalState}
        onCancle={() => setModalState(false)}
        title=" Login As Guest"
        scroll={false}
      >
        <div>asdasd</div>
      </Modal>
    </div>
  );
};

export default LoginClub;
