import React from "react";
import { useState } from "react";
import ProductModal from "../components/ProductModal";
import ProductTable from "../components/ProductTable";
import { useDispatch } from "react-redux";
import { useSelector } from "react-redux";
import { useEffect } from "react";
import {
  DeleteProduct,
  ListProducts,
  SaveProduct,
} from "../actions/ProductAction";
import Sidebar from "../components/Sidebar";

export default function ProductPage() {
  const [modalShow, setModalShow] = useState(false);
  const [product, setProduct] = useState({});
  const productList = useSelector((state) => state.productList);
  const { loading, products } = productList;
  const dispatch = useDispatch();

  const productSave = useSelector((state) => state.productSave);
  const { success: successSave } = productSave;
  const productDelete = useSelector((state) => state.productDelete);
  const { success: successDelete } = productDelete;

  const submitHandler = (product) => {
    dispatch(SaveProduct(product));
  };

  const deleteHandler = (id) => {
    dispatch(DeleteProduct(id));
  };

  const addHandler = () => {
    setModalShow(true);
    setProduct({
      name: "",
      description: "",
      unitPrice: 0,
      discount: 0,
      categoryId: "",
    });
  };

  const editHandler = (product) => {
    setModalShow(true);
    setProduct(product);
  };

  useEffect(() => {
    if (successSave) {
      setModalShow(false);
    }
    dispatch(ListProducts());
    return () => {};
  }, [dispatch, successSave, successDelete]);

  return (
    <div className="App container-fluid p-0">
      <div className="row g-0">
        <aside className="App-sidebar col-md-3 d-md-block">
          <Sidebar></Sidebar>
        </aside>
        <main className="App-main col-md-9">
          <div className="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom">
            <h1 className="h2">Product</h1>
            <div className="btn-toolbar mb-2 mb-md-0">
              {!modalShow ? (
                <button
                  type="button"
                  className="btn btn-sm btn-outline-primary"
                  onClick={() => addHandler()}
                >
                  New product
                </button>
              ) : (
                <button
                  type="button"
                  className="btn btn-sm btn-outline-primary"
                  onClick={() => setModalShow(false)}
                >
                  Close
                </button>
              )}
            </div>
          </div>
          {modalShow && (
            <ProductModal
              onSubmit={(product) => submitHandler(product)}
              data={product}
            ></ProductModal>
          )}
          {!loading && (
            <ProductTable
              products={products}
              onDelete={(productId) => deleteHandler(productId)}
              onEdit={(product) => editHandler(product)}
            ></ProductTable>
          )}
        </main>
      </div>
    </div>
  );
}
