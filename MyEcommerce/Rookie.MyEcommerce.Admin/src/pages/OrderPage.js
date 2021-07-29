import React from "react";
import { useState } from "react";
import OrderModal from "../components/OrderModal";
import OrderTable from "../components/OrderTable";
import { useEffect } from "react";
import { useDispatch } from "react-redux";
import { useSelector } from "react-redux";
import Sidebar from "../components/Sidebar";

export default function OrderPage() {
  const [modalShow, setModalShow] = useState(false);
  const [order, setOrder] = useState({});
  const dispatch = useDispatch();
  const orderList = useSelector((state) => state.orderList);
  const { loading, orders, err } = orderList;

  const submitHandler = () => {};

  const deleteHandler = () => {};

  const editHandler = () => {};

  useEffect(() => {
    return () => {
      //
    };
  }, []);

  return (
    <div className="App container-fluid p-0">
      <div className="row g-0">
        <main className="App-main col-md-9">
          <aside className="App-sidebar col-md-3 d-md-block">
            <Sidebar></Sidebar>
          </aside>
          <div className="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom">
            <h1 className="h2">Order</h1>
            <div className="btn-toolbar mb-2 mb-md-0"></div>
          </div>
          {modalShow && (
            <OrderModal
              onSubmit={(e) => submitHandler(e)}
              data={order}
            ></OrderModal>
          )}
          {!loading && (
            <OrderTable
              order={orders}
              onDelete={(orderId) => deleteHandler(orderId)}
              onEdit={(order) => editHandler(order)}
            ></OrderTable>
          )}
        </main>
      </div>
    </div>
  );
}
