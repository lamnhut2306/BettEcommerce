import React from "react";
import CategoryTable from "../components/CategoryTable";
import { useSelector } from "react-redux";
import CategoryModal from "../components/CategoryModal";
import { useState } from "react";
import {
  DeleteCategory,
  ListCategories,
  SaveCategory,
} from "../actions/CategoryAction";
import { useDispatch } from "react-redux";
import { useEffect } from "react";
import Sidebar from "../components/Sidebar";

export default function CategoryPage() {
  const [modalShow, setModalShow] = useState(false);
  const [category, setCategory] = useState({});
  const categoryList = useSelector((state) => state.categoryList);
  const { loading, categories } = categoryList;

  const dispatch = useDispatch();
  const categorySave = useSelector((state) => state.categorySave);
  const { success: successSave } = categorySave;
  const categoryDelete = useSelector((state) => state.categoryDelete);
  const { success: successDelete } = categoryDelete;

  const submitHandler = (e) => {
    dispatch(
      SaveCategory({
        id: e.target.id.value,
        name: e.target.name.value,
        description: e.target.description.value,
      })
    );
  };

  const deleteHandler = (id) => {
    dispatch(DeleteCategory(id));
  };

  const addHandler = () => {
    setModalShow(true);
    setCategory({
      id: "",
      name: "",
      description: "",
    });
  };

  const editHandler = (category) => {
    setModalShow(true);
    setCategory(category);
  };

  useEffect(() => {
    if (successSave) {
      setModalShow(false);
    }
    dispatch(ListCategories());
    return () => {};
  }, [dispatch, successSave, successDelete]);

  return (
    <div className="App container-fluid p-0">
      <div className="row g-0">
        <div className="d-flex">
          <aside className="App-sidebar col-md-3 d-md-block">
            <Sidebar></Sidebar>
          </aside>
          <main className="App-main col-md-9">
            <div className="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom">
              <h1 className="h2">Category</h1>
              <div className="btn-toolbar mb-2 mb-md-0">
                {!modalShow ? (
                  <button
                    type="button"
                    className="btn btn-sm btn-outline-primary"
                    onClick={() => addHandler()}
                  >
                    New category
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
              <CategoryModal
                onSubmit={(e) => submitHandler(e)}
                data={category}
              ></CategoryModal>
            )}
            {!loading && (
              <CategoryTable
                categories={categories}
                onDelete={(categoryId) => deleteHandler(categoryId)}
                onEdit={(category) => editHandler(category)}
              ></CategoryTable>
            )}
          </main>
        </div>
      </div>
    </div>
  );
}
