import React, { useEffect, useRef } from "react";
import { Formik } from "formik";
import "./index.scss";

const Card = () => {
  const mounthRef = useRef();
  const buy = (a) => {
    console.log(a);
  };

  useEffect(() => {
    todayDate();
  }, []);

  const todayDate = () => {
    var today = new Date();
    var mm = String(today.getMonth() + 1).padStart(2, "0");
    var yyyy = today.getFullYear();
    console.log(yyyy + "-" + mm);
    mounthRef.current.min = yyyy + "-" + mm;
  };

  return (
    <div className="card-detailes">
      <Formik
        initialValues={{
          cardType: "Visa",
          cardNumber: "",
          cardExp: "",
          cardName: "",
        }}
        validate={(values) => {
          const errors = {};
          if (!values.cardNumber) {
            errors.cardNumber = "Card Number is Required";
          } else if (
            values.cardType === "Visa" &&
            values.cardNumber.length < 16
          ) {
            errors.cardNumber = "Visa Card Number must contain 16 digits";
          } else if (
            values.cardType === "Visa" &&
            values.cardNumber.substring(0, 4) !== "4580"
          ) {
            errors.cardNumber = "Visa Card Number must start with 4580";
          } else if (
            values.cardType === "Master Card" &&
            values.cardNumber.length < 16
          ) {
            errors.cardNumber =
              "Master Card Card Number must contain 16 digits";
          } else if (
            values.cardType === "Master Card" &&
            values.cardNumber.substring(0, 4) !== "5326"
          ) {
            errors.cardNumber = "Master Card Card Number must start with 5326";
          } else if (
            values.cardType === "American Express" &&
            values.cardNumber.length < 15
          ) {
            errors.cardNumber =
              "American Express Card Number must contain 15 digits";
          } else if (
            values.cardType === "American Express" &&
            values.cardNumber.substring(0, 4) !== "3434"
          ) {
            errors.cardNumber =
              "American Express Card Number must start with 3434";
          }
          if (!values.cardExp) {
            errors.cardExp = "Card Expiration Date is Required";
          }
          if (!values.cardName) {
            errors.cardName = "Card Owner is Required";
          }
          return errors;
        }}
        onSubmit={(values, { setSubmitting }) => {
          buy(values);
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
          <form className="form card-form" onSubmit={handleSubmit}>
            <div className="row">
              <div className="coulmn">
                <div className="row">
                  Card Type
                  <select
                    name="cardType"
                    onChange={handleChange}
                    onBlur={handleBlur}
                    value={values.cardType}
                  >
                    <option>Master Card </option>
                    <option>Visa </option>
                    <option>American Express </option>
                  </select>
                </div>
                <div className="input-error">
                  {errors.cardType && touched.cardType && errors.cardType}
                </div>
              </div>
              <div className="coulmn">
                <input
                  placeholder="Card number"
                  type="cardNumber"
                  name="cardNumber"
                  onChange={handleChange}
                  onBlur={handleBlur}
                  value={values.cardNumber}
                  maxLength={
                    values.cardType === "American Express" ? "15" : "16"
                  }
                ></input>
                <div className="input-error">
                  {errors.cardNumber && touched.cardNumber && errors.cardNumber}
                </div>
              </div>
            </div>
            <div className="row">
              <div className="coulmn">
                <input
                  placeholder="Card owner"
                  type="cardName"
                  name="cardName"
                  onChange={handleChange}
                  onBlur={handleBlur}
                  value={values.cardName}
                ></input>
                <div className="input-error">
                  {errors.cardName && touched.cardName && errors.cardName}
                </div>
              </div>
              <div className="coulmn">
                <input
                  type="month"
                  id="start"
                  name="cardExp"
                  onChange={handleChange}
                  onBlur={handleBlur}
                  value={values.cardExp}
                  ref={mounthRef}
                ></input>
                <div className="input-error">
                  {errors.cardExp && touched.cardExp && errors.cardExp}
                </div>
              </div>
            </div>
            <button type="submit">Buy</button>
          </form>
        )}
      </Formik>
    </div>
  );
};

export default Card;
