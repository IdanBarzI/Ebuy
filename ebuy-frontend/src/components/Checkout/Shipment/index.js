import React, { useState, useEffect, useContext } from "react";
import { useSelector, useDispatch } from "react-redux";
import { checkoutActions } from "../../../store/Checkout";
import AuthContext from "../../../context/AuthContext";

import { Formik } from "formik";
import Modal from "../../../UiKit/Modal";

import "./index.scss";
import useAxios from "../../../hooks/use-axios";

const Shipment = () => {
  const checkoutData = useSelector((state) => state.checkout);
  const cartData = useSelector((state) => state.cart);

  const [modalOpen, setModalOpen] = useState(false);
  const [deliveryModes, setDeliveryModes] = useState([]);
  const [shipmentOptions, setShipmentOptions] = useState([]);
  const [countries, setCountries] = useState([]);
  const [states, setStates] = useState([]);
  const [shipmentCost, setShipmentCost] = useState([]);

  const dispatch = useDispatch();

  const {
    isLoading,
    fetchError,
    sendRequest: sendGetCountriesRequest,
  } = useAxios();

  const {
    isLoadingg,
    fetchErrorr,
    sendRequest: sendGetStatesRequest,
  } = useAxios();

  const {
    isLoadinggg,
    fetchErrorrr,
    sendRequest: sendGetDeliveryModesRequest,
  } = useAxios();

  const {
    isLoadingggg,
    fetchErrorrrr,
    sendRequest: sendGetShipmentOptionsRequest,
  } = useAxios();

  const {
    isLoadinggggg,
    fetchErrorrrrr,
    sendRequest: sendGetShipmentCalculateRequest,
  } = useAxios();

  useEffect(() => {
    getDeliveryModes();
    getShipmentOptions();
    getCountries();
    getStates();
  }, []);

  const getCountries = async () => {
    try {
      await sendGetCountriesRequest(
        {
          method: "Get",
          url: `EbuyStore/GetCountries`,
        },
        (data) => {
          setCountries(data);
        }
      );
    } catch (e) {}
  };

  const getStates = async () => {
    try {
      await sendGetStatesRequest(
        {
          method: "Get",
          url: `EbuyStore/GetStates`,
        },
        (data) => {
          setStates(data);
        }
      );
    } catch (e) {}
  };

  const getDeliveryModes = async () => {
    try {
      await sendGetDeliveryModesRequest(
        {
          method: "Get",
          url: `EbuyStore/GetDeliveryModes`,
        },
        (data) => {
          setDeliveryModes(data);
        }
      );
    } catch (e) {}
  };

  const getShipmentOptions = async () => {
    try {
      await sendGetShipmentOptionsRequest(
        {
          method: "Get",
          url: `EbuyStore/GetShipmentOptions`,
        },
        (data) => {
          setShipmentOptions(data);
        }
      );
    } catch (e) {}
  };

  const getShipmentCalculate = async (ShipmentAreaId, ShipmentOptionId) => {
    try {
      await sendGetShipmentCalculateRequest(
        {
          method: "POST",
          url: `EbuyStore/ShipmentCalculate`,
          data: {
            ShipmentAreaId,
            ShipmentOptionId,
            AmountOfProducts: cartData.totalQuantity,
          },
        },
        (data) => {
          setShipmentCost((prev) => {
            if (prev.lowestCost !== data.lowestCost) {
              return data;
            }
            return prev;
          });
        }
      );
    } catch (e) {}
  };

  const { user } = useContext(AuthContext);

  return (
    <>
      <>
        <div className="shipment-detailes">
          <div className="row">
            Delivery Mode
            <select
              name="shipmentOption"
              onChange={(e) =>
                dispatch(
                  checkoutActions.submitShipmentChange({
                    field: "shipmentOption",
                    value: e.target.value,
                  })
                )
              }
            >
              {deliveryModes.map((deliveryMode) => (
                <option key={deliveryMode.id}>
                  {deliveryMode.description}{" "}
                </option>
              ))}
            </select>
          </div>
          <button onClick={() => setModalOpen((prevState) => !prevState)}>
            Shipment Details
          </button>
        </div>
      </>
      <Modal
        show={modalOpen}
        onCancle={() => setModalOpen((prevState) => !prevState)}
        title="Shipment Detailes"
        scroll={false}
      >
        {checkoutData.shipment.shipmentOption === "electronically" ? (
          <Formik
            initialValues={{}}
            validate={(values) => {
              const errors = {};
              if (!values.email && !checkoutData.shipment.shipmentData.email) {
                errors.email = "Email is Required";
              } else if (
                !/^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}$/i.test(
                  values.email
                ) &&
                !/^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}$/i.test(
                  checkoutData.shipment.shipmentData.email
                )
              ) {
                errors.email = "Invalid email address";
              } else if (values.email) {
                dispatch(
                  checkoutActions.setShipmentData({
                    field: "email",
                    value: values.email,
                  })
                );
              }
              return errors;
            }}
            onSubmit={(values, { setSubmitting }) => {
              setModalOpen(false);
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
              <>
                <form className="form shipment-form" onSubmit={handleSubmit}>
                  <div className="shipment-detailes">
                    <div className="row">
                      <input
                        placeholder="email"
                        type="email"
                        name="email"
                        defaultValue={
                          user.email || checkoutData.shipment.shipmentData.email
                        }
                        onChange={handleChange}
                        onBlur={handleBlur}
                      ></input>
                      <div className="input-error">
                        {errors.email && touched.email && errors.email}
                      </div>
                    </div>
                  </div>
                  <button type="submit">Submit</button>
                </form>
              </>
            )}
          </Formik>
        ) : (
          <Formik
            initialValues={{
              deliveryMode: "",
              country: "",
              state: "",
              city: "",
              street: "",
              reciverName: "",
              houseNumber: "",
              zipCode: "",
              pob: "",
            }}
            validate={(values) => {
              const errors = {};
              if (
                !values.deliveryMode &&
                !checkoutData.shipment.shipmentData.deliveryMode
              ) {
                errors.deliveryMode = "Delivery Mode is Required";
              }
              if (
                !values.country &&
                !checkoutData.shipment.shipmentData.country
              ) {
                errors.country = "Country is Required";
              } else if (values.country) {
                dispatch(
                  checkoutActions.setShipmentData({
                    field: "country",
                    value: values.country,
                  })
                );
                if (values.deliveryMode) {
                  getShipmentCalculate();
                }
              }
              if (!values.state && !checkoutData.shipment.shipmentData.state) {
                errors.state = "State is Required";
              } else if (values.state) {
                dispatch(
                  checkoutActions.setShipmentData({
                    field: "state",
                    value: values.state,
                  })
                );
              }
              if (
                !values.street &&
                !checkoutData.shipment.shipmentData.street
              ) {
                errors.street = "Street is Required";
              } else if (values.street) {
                dispatch(
                  checkoutActions.setShipmentData({
                    field: "street",
                    value: values.street,
                  })
                );
              }
              if (
                !values.houseNumber &&
                !checkoutData.shipment.shipmentData.houseNumber
              ) {
                errors.houseNumber = "House Number is Required";
              } else if (
                values.houseNumber <= 0 &&
                checkoutData.shipment.shipmentData.houseNumber <= 0
              ) {
                errors.houseNumber = "House Number can't be less or equle to 0";
              } else if (values.houseNumber) {
                dispatch(
                  checkoutActions.setShipmentData({
                    field: "houseNumber",
                    value: values.houseNumber,
                  })
                );
              }
              if (
                !values.zipCode &&
                !checkoutData.shipment.shipmentData.zipCode
              ) {
                errors.zipCode = "Zip Code is Required";
              } else if (
                values.zipCode <= 0 &&
                checkoutData.shipment.shipmentData.zipCode <= 0
              ) {
                errors.zipCode = "Zip Code can't be less or equle to 0";
              } else if (values.zipCode) {
                dispatch(
                  checkoutActions.setShipmentData({
                    field: "zipCode",
                    value: values.zipCode,
                  })
                );
              }
              if (values.deliveryMode && values.country) {
                dispatch(
                  checkoutActions.setShipmentData({
                    field: "deliveryMode",
                    value: values.deliveryMode,
                  })
                );
                dispatch(
                  checkoutActions.setShipmentData({
                    field: "country",
                    value: values.country,
                  })
                );
                console.log({
                  ShipmentAreaId: checkoutData.shipment.shipmentData.country,
                  ShipmentOptionId:
                    checkoutData.shipment.shipmentData.deliveryMode,
                  AmountOfProducts: cartData.totalQuantity,
                });
                getShipmentCalculate(values.country, values.deliveryMode);
              }
              return errors;
            }}
            onSubmit={(values, { setSubmitting }) => {
              setModalOpen(false);
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
              <>
                <form className="form shipment-form" onSubmit={handleSubmit}>
                  <div className="shipment-detailes">
                    <div className="row">
                      Shipment Option
                      <select
                        name="deliveryMode"
                        onChange={handleChange}
                        onBlur={handleBlur}
                        defaultValue={
                          checkoutData.shipment.shipmentData.deliveryMode
                        }
                      >
                        {shipmentOptions.map((shipmentOption) => (
                          <option
                            key={shipmentOption.id}
                            value={shipmentOption.id}
                          >
                            {shipmentOption.description}
                          </option>
                        ))}
                      </select>
                      <div className="input-error">
                        {errors.deliveryMode &&
                          touched.deliveryMode &&
                          errors.deliveryMode}
                      </div>
                    </div>
                    <div className="row">
                      Country
                      <select
                        name="country"
                        onChange={handleChange}
                        onBlur={handleBlur}
                        defaultValue={
                          checkoutData.shipment.shipmentData.country
                        }
                      >
                        {countries.map((country) => (
                          <option
                            key={country.country}
                            value={country.shipmentAreaId}
                          >
                            {country.country}{" "}
                          </option>
                        ))}
                      </select>
                      <div className="input-error">
                        {errors.country && touched.country && errors.country}
                      </div>
                    </div>
                    {values.country === "2" && (
                      <div className="row">
                        State
                        <select
                          name="state"
                          onChange={handleChange}
                          onBlur={handleBlur}
                          defaultValue={
                            checkoutData.shipment.shipmentData.state
                          }
                        >
                          {states.map((state) => (
                            <option key={state.state}>{state.name} </option>
                          ))}
                        </select>
                        <div className="input-error">
                          {errors.state && touched.state && errors.state}
                        </div>
                      </div>
                    )}
                    <div className="row">
                      <input
                        placeholder="City"
                        type="city"
                        name="city"
                        onChange={handleChange}
                        onBlur={handleBlur}
                        maxLength="50"
                        defaultValue={checkoutData.shipment.shipmentData.city}
                      ></input>
                      <div className="input-error">
                        {errors.city && touched.city && errors.city}
                      </div>
                    </div>
                    <div className="row">
                      <input
                        placeholder="Street"
                        type="street"
                        name="street"
                        onChange={handleChange}
                        onBlur={handleBlur}
                        maxLength="50"
                        defaultValue={checkoutData.shipment.shipmentData.street}
                      ></input>
                      <div className="input-error">
                        {errors.street && touched.street && errors.street}
                      </div>
                    </div>

                    <div className="row">
                      <input
                        placeholder="Reciver Name"
                        type="reciverName"
                        name="reciverName"
                        onChange={handleChange}
                        onBlur={handleBlur}
                        maxLength="50"
                        defaultValue={
                          checkoutData.shipment.shipmentData.reciverName
                        }
                      ></input>
                      <div className="input-error">
                        {errors.reciverName &&
                          touched.reciverName &&
                          errors.reciverName}
                      </div>
                    </div>
                    <div className="row">
                      <input
                        placeholder="House Number"
                        type="number"
                        name="houseNumber"
                        onChange={handleChange}
                        onBlur={handleBlur}
                        defaultValue={
                          checkoutData.shipment.shipmentData.houseNumber
                        }
                      ></input>
                      <div className="input-error">
                        {errors.houseNumber &&
                          touched.houseNumber &&
                          errors.houseNumber}
                      </div>
                    </div>
                    <div className="row">
                      <input
                        placeholder="Zip Code"
                        type="number"
                        name="zipCode"
                        onChange={handleChange}
                        onBlur={handleBlur}
                        defaultValue={
                          checkoutData.shipment.shipmentData.zipCode
                        }
                        maxLength="10"
                      ></input>
                      <div className="input-error">
                        {errors.zipCode && touched.zipCode && errors.zipCode}
                      </div>
                    </div>
                    <div className="row">
                      <input
                        placeholder="P.O.B"
                        type="text"
                        name="pob"
                        onChange={handleChange}
                        onBlur={handleBlur}
                        defaultValue={checkoutData.shipment.shipmentData.pob}
                      ></input>
                      <div className="input-error">
                        {errors.pob && touched.pob && errors.pob}
                      </div>
                    </div>
                  </div>
                  {shipmentCost.shipmentDuration && (
                    <div>
                      <p>
                        Shipment Cost - <b>{shipmentCost?.lowestCost}$</b>
                      </p>
                      <p>
                        Shipment Company - <b>{shipmentCost?.nameCompany}</b>
                      </p>
                      <p>
                        Shipment Duration -
                        <b>{shipmentCost?.shipmentDuration.slice(2, 10)}</b>
                      </p>
                    </div>
                  )}
                  <button type="submit">Submit</button>
                </form>
              </>
            )}
          </Formik>
        )}
      </Modal>
    </>
  );
};

export default Shipment;
