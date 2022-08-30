import React, { useEffect } from "react";
import CartDrawer from "../Layout/TopBar/Cart/CartDrawer";
import { useSelector, useDispatch } from "react-redux";
import { cartActions } from "../../store/Cart";
import cover from "../../assets/images/E-buy.png";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faAdd, faSubtract } from "@fortawesome/free-solid-svg-icons";
import useAxios from "../../hooks/use-axios";
import "./index.scss";
import Filters from "./Filters";

const Products = () => {
  const cartData = useSelector((state) => state.cart);
  const dispatch = useDispatch();

  const {
    isLoading,
    fetchError,
    sendRequest: sendGetProductsRequest,
  } = useAxios();

  const {
    isLoadingg,
    fetchErrorr,
    sendRequest: sendGetBogoRequest,
  } = useAxios();

  useEffect(() => {
    getProducts();
    const user = JSON.parse(window.localStorage.getItem("user"));
    if (user?.isClubMember) {
      getBogo(user);
    }
  }, []);

  const getProducts = async (user) => {
    try {
      await sendGetProductsRequest(
        {
          method: "GET",
          url: `EbuyStore/GetAllProductsInData`,
        },
        (data) => {
          dispatch(cartActions.SetProducts(data));
        }
      );
    } catch (e) {}
  };

  const getBogo = async (user) => {
    try {
      await sendGetBogoRequest(
        {
          method: "POST",
          url: `ClubMember/AddBogoProductTocart`,
          data: { ...user },
        },
        (data) => {
          console.log(data);
          data.map((product) => {
            dispatch(cartActions.AddProduct({ id: product.id, bogo: true }));
          });
        }
      );
    } catch (e) {}
  };

  return (
    <div className="products">
      <CartDrawer />
      <Filters />
      <div className="products-container">
        {isLoading ? (
          <>
            <div className="product">
              <div className=" loading"></div>
            </div>
            <div className="product">
              <div className="loading"></div>
            </div>
            <div className="product">
              <div className="loading"></div>
            </div>
            <div className="product">
              <div className="loading"></div>
            </div>
            <div className="product">
              <div className="loading"></div>
            </div>
            <div className="product">
              <div className="loading"></div>
            </div>
          </>
        ) : (
          cartData.products.map((p) => {
            if (p) {
              return (
                <div key={p.id} className="product">
                  <img src={cover} />
                  <div className="product-details">
                    <h1>{p.title}</h1>
                    <h3>Author: {p.author}</h3>
                    <p>Publication Date: {p.publishdate.slice(2, 10)}</p>
                    <p>Price: {p.price}$</p>
                    <div className="actions">
                      <FontAwesomeIcon
                        icon={faAdd}
                        color="rgb(32, 117, 3)"
                        onClick={() =>
                          dispatch(cartActions.AddProduct({ id: p.id }))
                        }
                      />
                      <p>{p.quntity || 0}</p>
                      <FontAwesomeIcon
                        icon={faSubtract}
                        color="rgb(177, 3, 3)"
                        onClick={() => dispatch(cartActions.SubProduct(p.id))}
                      />
                    </div>
                  </div>
                </div>
              );
            }
          })
        )}
      </div>
    </div>
  );
};

export default Products;
