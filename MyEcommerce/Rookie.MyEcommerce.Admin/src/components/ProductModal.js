import React from "react";
import { useEffect, useState } from "react";
import {
  ProductInvalidMessage,
  ProductRules,
} from "../constants/ProductConstants";
import { useSelector } from "react-redux";
import { useDispatch } from "react-redux";
import { ListCategories } from "../actions/CategoryAction";

export default function ProductModal(props) {
  const [id, setId] = useState(props.data.id);
  const [name, setName] = useState(props.data.name);
  const [description, setDescription] = useState(props.data.description);
  const [unitPrice, setUnitPrice] = useState(props.data.unitPrice);
  const [discount, setDiscount] = useState(props.data.discount);
  const [categoryId, setCategoryId] = useState(props.data.categoryId);
  const poster = React.createRef();
  const otherImages = React.createRef();
  const [invalidName, setInvalidName] = useState(
    ProductRules.nameRegex.test(name)
  );
  const [invalidDescription, setInvalidDescription] = useState(
    ProductRules.descriptionRegex.test(name)
  );
  const categoryList = useSelector((state) => state.categoryList);
  const { categories } = categoryList;
  const dispatch = useDispatch();

  const onNameChange = (e) => {
    setName(e.target.value);
    setInvalidName(!ProductRules.nameRegex.test(e.target.value));
  };
  const onDescriptionChange = (e) => {
    setDescription(e.target.value);
    setInvalidDescription(!ProductRules.descriptionRegex.test(e.target.value));
  };

  const submitHandler = (e) => {
    e.preventDefault();
    if (!invalidName && !invalidDescription) {
      props.onSubmit({
        name,
        id,
        description,
        unitPrice,
        discount,
        categoryId,
        images: [...poster.current.files, ...otherImages.current.files],
      });
    }
  };

  useEffect(() => {
    setId(props.data.id);
    setDescription(props.data.description);
    setName(props.data.name);
    setUnitPrice(props.data.unitPrice);
    setDiscount(props.data.discount);
    dispatch(ListCategories());
    return () => {};
  }, [props.data, dispatch]);
  return (
    <form
      className="border border-primary rounded p-3 border-3"
      onSubmit={(e) => submitHandler(e)}
    >
      {id && <input type="hidden" value={id} name="id" />}
      <div className="form-group mb-3">
        <label htmlFor="name" className="form-label">
          Name
        </label>
        <input
          type="text"
          id="name"
          className="form-control"
          name="name"
          value={name}
          onChange={(e) => onNameChange(e)}
        />
        {invalidName && (
          <div id="name-text" className="form-text">
            {ProductInvalidMessage.name}
          </div>
        )}
      </div>
      <div className="form-group mb-3">
        <label htmlFor="description" className="form-label">
          Description
        </label>
        <textarea
          id="description"
          className="form-control"
          name="description"
          value={description}
          onChange={(e) => onDescriptionChange(e)}
        ></textarea>
        {invalidDescription && (
          <div id="description-text" className="form-text">
            {ProductInvalidMessage.description}
          </div>
        )}
      </div>
      <div className="form-group mb-3">
        <label htmlFor="unitPrice" className="form-label">
          Unit Price
        </label>
        <div className="input-group mb-3">
          <span className="input-group-text">$</span>
          <input
            type="number"
            className="form-control"
            aria-label="Amount (to the nearest dollar)"
            value={unitPrice}
            onChange={(e) => setUnitPrice(e.target.value)}
          />
        </div>
      </div>
      <div className="form-group mb-3">
        <label htmlFor="discount" className="form-label">
          Discount
        </label>
        <div className="input-group mb-3">
          <span className="input-group-text">%</span>
          <input
            type="number"
            className="form-control"
            min="0"
            max="100"
            step="1"
            id="discount"
            value={discount}
            onChange={(e) => setDiscount(e.target.value)}
          />
        </div>
      </div>
      <div className="form-group mb-3">
        <label htmlFor="category" className="form-label">
          Category
        </label>
        <select
          id="category"
          className="form-select"
          aria-label="categories"
          value={categoryId}
          onChange={(e) => setCategoryId(e.target.value)}
        >
          <option>Choose a category</option>
          {categories.map((category) => (
            <option value={category.id} key={category.id}>
              {category.name}
            </option>
          ))}
        </select>
      </div>
      <div className="form-group mb-3">
        <label htmlFor="poster" className="form-label">
          Poster
        </label>
        <input
          className="form-control"
          type="file"
          id="poster"
          accept="image/*"
          ref={poster}
        />
      </div>
      <div className="form-froup mb-3">
        <label htmlFor="poster" className="form-label">
          Current Poster
        </label>
        <img src="..." class="img-thumbnail" alt="..." />
      </div>
      <div className="form-group mb-3">
        <label className="form-label">
          Other images
        </label>
        <input
          className="form-control"
          type="file"
          id="otherImages"
          multiple
          accept="image/*"
          ref={otherImages}
        />
      </div>
      <div className="form-froup mb-3">
        <label className="form-label">
          Images
        </label>
        <img src="..." class="img-thumbnail" alt="..." />
      </div>
      {id ? (
        <button className="btn btn-primary" type="submit">
          Save
        </button>
      ) : (
        <button className="btn btn-primary" type="submit">
          Add
        </button>
      )}
    </form>
  );
}
