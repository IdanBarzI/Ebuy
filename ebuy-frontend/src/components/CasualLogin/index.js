import React, { useState, useRef, useEffect } from "react";
import { faArrowRight } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Formik } from "formik";
import AnimatedLetters from "../AnimatedLetters";
import { useAuth } from "../../context/AuthContext";
import useAxios from "../../hooks/use-axios";
import "./index.scss";
import Modal from "../../UiKit/Modal";

const CasualLoginClub = () => {
  const [modalState, setModalState] = useState(false);
  const { signIn } = useAuth();
  const [letterClass, setLetterClass] = useState("text-animate");

  useEffect(() => {
    let timeoutId = setTimeout(() => {
      setLetterClass("text-animate-hover");
    }, 4000);

    return () => {
      clearTimeout(timeoutId);
    };
  }, []);

  const {
    isLoading,
    fetchError,
    sendRequest: sendLoginCasualRequest,
  } = useAxios();

  const loginCasual = async (user) => {
    try {
      console.log(user);
      await sendLoginCasualRequest(
        {
          method: "POST",
          url: `CasualCustomer/Register`,
          data: { ...user, isClubMember: false, purchasedProducts: [] },
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
      <Formik
        initialValues={{
          loginName: "",
          addres: "",
          email: "",
        }}
        validate={(values) => {
          const errors = {};
          if (!values.loginName) {
            errors.loginName = "User Name is Required";
          } else if (!values.loginName) {
            errors.loginName = "User Name must be less then 50 letters";
          }
          if (!values.addres) {
            errors.addres = "address is Required";
          } else if (!values.addres) {
            errors.addres = "address must be less then 50 letters";
          }
          if (!values.email) {
            errors.email = "email is Required";
          } else if (!values.email) {
            errors.email = "email must be less then 50 letters";
          }
          return errors;
        }}
        onSubmit={(values, { setSubmitting }) => {
          loginCasual(values);
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
          <form className="login-club-form" onSubmit={handleSubmit}>
            <h1 className="login-headers">
              <AnimatedLetters
                letterClass={letterClass}
                strArray={"Casual Login".split("")}
                idx={5}
              />
            </h1>
            <h2 className="login-headers">
              <AnimatedLetters
                letterClass={letterClass}
                strArray={"Club Member".split("")}
                idx={17}
              />
            </h2>
            <div className="row first">
              <input
                placeholder="User Name"
                name="loginName"
                maxLength={50}
                required
                onChange={handleChange}
                onBlur={handleBlur}
                value={values.loginName}
              ></input>
              <em>
                {errors.loginName && touched.loginName && errors.loginName}
              </em>
            </div>
            <div className="row last">
              <input
                placeholder="email"
                required
                type="email"
                name="email"
                onChange={handleChange}
                onBlur={handleBlur}
                value={values.email}
              ></input>
              <em>{errors.email && touched.email && errors.email}</em>
            </div>
            <div className="row last">
              <input
                placeholder="address"
                required
                type="address"
                name="addres"
                onChange={handleChange}
                onBlur={handleBlur}
                value={values.addres}
              ></input>
              <em>{errors.addres && touched.addres && errors.addres}</em>
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

export default CasualLoginClub;
