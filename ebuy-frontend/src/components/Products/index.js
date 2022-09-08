import React, { useEffect, useState } from "react";
import CartDrawer from "../Layout/TopBar/Cart/CartDrawer";
import { useSelector, useDispatch } from "react-redux";
import { productsActions } from "../../store/Products";
import { cartActions } from "../../store/Cart";
import cover from "../../assets/images/E-buy.png";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faAdd, faSubtract } from "@fortawesome/free-solid-svg-icons";
import useAxios from "../../hooks/use-axios";
import "./index.scss";
import Filters from "./Filters";
import Pagination from "../../UiKit/Pagination/pagination";

const PER_PAGE = 3;

const Products = () => {
  const cartData = useSelector((state) => state.cart);
  const productsData = useSelector((state) => state.products);
  const dispatch = useDispatch();

  const [questionsPerPage, setQuestionsPerPage] = useState(PER_PAGE);
  const [currentPage, setCurrentPage] = useState(1);

  const indexOfLastQuestion = currentPage * questionsPerPage;
  const indexOfFirstQuestion = indexOfLastQuestion - questionsPerPage;
  const currentQuestions = productsData.products.slice(
    indexOfFirstQuestion,
    indexOfLastQuestion
  );

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
          dispatch(productsActions.SetProducts(data));
          dispatch(cartActions.SetProducts(data));
        }
      );
    } catch (e) {}
  };

  const paginate = (number) => {
    setCurrentPage(number);
  };

  console.log(cartData);
  console.log(productsData);

  const getBogo = async (user) => {
    try {
      await sendGetBogoRequest(
        {
          method: "POST",
          url: `ClubMember/AddBogoProductTocart`,
          data: { ...user },
        },
        (data) => {
          data.map((product) => {
            console.log(product);
            dispatch(cartActions.AddProduct({ id: product.id, bogo: true }));
            dispatch(productsActions.SubProduct({ id: product.id }));
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
          currentQuestions.map((p) => {
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
                        size="lg"
                        onClick={() => {
                          dispatch(cartActions.AddProduct({ id: p.id }));
                          dispatch(productsActions.SubProduct({ id: p.id }));
                        }}
                      />
                    </div>
                  </div>
                </div>
              );
            }
          })
        )}
      </div>
      <div style={{ width: "80vw" }}>
        <Pagination
          itemsPerPage={questionsPerPage}
          currentPage={currentPage}
          paginate={paginate}
          totalItems={productsData.products.length}
        />
      </div>
    </div>
  );
};

export default Products;
