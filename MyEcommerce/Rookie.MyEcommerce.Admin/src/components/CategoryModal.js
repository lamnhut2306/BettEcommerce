import React from "react";
import { useState } from "react";
import { useEffect } from "react";
import { CategoryInvalidMessage, CategoryRules } from "../constants/CategoryConstants";

export default function CategoryModal(props) {
  const [id, setId] = useState(props.data.id);
  const [name, setName] = useState(props.data.name);
  const [invalidName, setInvalidName] = useState(!CategoryRules.nameRegex.test(name));
  const [description, setDescription] = useState(props.data.description);
  const [invalidDescription, setInvalidDescription] = useState(!CategoryRules.descriptionRegex.test(description));


  const submitHandler = (e) => {
    e.preventDefault();
    if (!invalidName && !invalidDescription) {
      props.onSubmit(e);
    }
  };

  const onNameChange = (e) => {
    setName(e.target.value)
    setInvalidName(!CategoryRules.nameRegex.test(e.target.value));
  }
  const onDescriptionChange = (e) => {
    setDescription(e.target.value)
    setInvalidDescription(!CategoryRules.descriptionRegex.test(e.target.value));
  }

  useEffect(() => {
    setId(props.data.id);
    setDescription(props.data.description);
    setName(props.data.name);
    return () => {};
  }, [props.data]);

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
        { invalidName && <div id="name-text" className="form-text">{CategoryInvalidMessage.name}</div>}
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
        { invalidDescription && <div id="description-text" className="form-text">{CategoryInvalidMessage.description}</div>}
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
