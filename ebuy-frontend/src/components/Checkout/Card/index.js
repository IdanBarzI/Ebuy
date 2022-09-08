import React, { useEffect, useRef, useState } from "react";
import { Formik } from "formik";

import useAxios from "../../../hooks/use-axios";

import "./index.scss";

const Card = () => {
  const mounthRef = useRef();
  const cardNumberRef = useRef();
  const [creditCardTypes, setCreditCardTypes] = useState([]);
  const buy = (a) => {};

  const {
    isLoading,
    fetchError,
    sendRequest: sendGetCreditCardTypesRequest,
  } = useAxios();

  const GetCreditCardTypes = async (user) => {
    try {
      await sendGetCreditCardTypesRequest(
        {
          method: "Get",
          url: `EbuyStore/GetCreditCardTypes`,
        },
        (data) => {
          setCreditCardTypes(data);
        }
      );
    } catch (e) {}
  };

  useEffect(() => {
    todayDate();
    GetCreditCardTypes();
  }, []);

  const todayDate = () => {
    var today = new Date();
    var mm = String(today.getMonth() + 1).padStart(2, "0");
    var yyyy = today.getFullYear();
    mounthRef.current.min = yyyy + "-" + mm;
  };
  return (
    <div className="card-detailes">
      <Formik
        initialValues={{
          cardType: "Card Type",
          cardNumber: "",
          cardExp: "",
          cardName: "",
        }}
        validate={(values) => {
          const errors = {};
          console.log(values);
          const card = creditCardTypes.filter((c) => {
            if (c.name === values.cardType) {
              return true;
            }
          });
          if (values.cardNumber.length <= 4) {
            console.log(card[0].prefix.trim());
            values.cardNumber = card[0].prefix.trim();
            // cardNumberRef.current = values.cardNumber;
          }
          if (values.cardNumber.length <= 4) {
            console.log(card[0].prefix.trim());
            values.cardNumber = card[0].prefix.trim();
            // cardNumberRef.current = values.cardNumber;
          }
          if (!values.cardNumber) {
            errors.cardNumber = "Card Number is Required";
          } else if (
            (values.cardType === "Visa" ||
              values.cardType === "MasterCardLocal") &&
            values.cardNumber.length < 19
          ) {
            errors.cardNumber = `${card[0].name} Card Number must contain 16 digits`;
          } else if (
            (values.cardType === "Visa" ||
              values.cardType === "MasterCardLocal") &&
            values.cardNumber.substring(0, 4) !== card[0].prefix.trim()
          ) {
            errors.cardNumber = `${
              card[0].name
            } Card Number must start with ${card[0].prefix.trim()}`;
          } else if (
            values.cardType === "American Express" &&
            values.cardNumber.length < 18
          ) {
            errors.cardNumber = `${card[0].name} Card Number must contain 15 digits`;
          } else if (
            values.cardType === "American Express" &&
            values.cardNumber.substring(0, 4) !== card[0].prefix.trim()
          ) {
            errors.cardNumber = `${
              card[0].name
            } Card Number must start with ${card[0].prefix.trim()}`;
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
                    {creditCardTypes.map((card) => (
                      <option key={card.name}>{card.name}</option>
                    ))}
                  </select>
                </div>
                <div className="input-error">
                  {errors.cardType && touched.cardType && errors.cardType}
                </div>
              </div>
              <div className="coulmn">
                Card number
                <input
                  placeholder="xxxx-xxxx-xxxx-xxxx"
                  type="cardNumber"
                  name="cardNumber"
                  onChange={handleChange}
                  onBlur={handleBlur}
                  value={values.cardNumber}
                  maxLength={
                    values.cardType === "American Express" ? "18" : "19"
                  }
                ></input>
                <div className="input-error">
                  {errors.cardNumber && touched.cardNumber && errors.cardNumber}
                </div>
              </div>
            </div>
            <div className="row">
              <div className="coulmn">
                Card owner
                <input
                  placeholder="Jon Dow"
                  type="cardName"
                  name="cardName"
                  onChange={handleChange}
                  onBlur={handleBlur}
                  value={values.cardName}
                  ref={cardNumberRef}
                ></input>
                <div className="input-error">
                  {errors.cardName && touched.cardName && errors.cardName}
                </div>
              </div>
              <div className="coulmn">
                Expiration Date
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
