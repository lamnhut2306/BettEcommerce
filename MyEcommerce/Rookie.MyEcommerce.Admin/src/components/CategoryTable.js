import React from "react";

export default function CategoryTable(props) {
  const categories = props.categories;
  const editHandler = (category) => props.onEdit(category);
  const deleteHandler = (categoryId) => props.onDelete(categoryId);

  return (
    <table className="table">
      <thead>
        <tr>
          <th scope="col">#</th>
          <th scope="col">Name</th>
          <th scope="col">Description</th>
          <th scope="col"></th>
        </tr>
      </thead>
      <tbody>
        { categories.map((category, index) => (
          <tr key={category.id}>
            <td>{index + 1}</td>
            <td>{category.name}</td>
            <td>{category.description}</td>
            <td>
              <div className="btn-group">
                <button className="btn btn-outline-primary" onClick={() => editHandler(category)}>
                  Edit
                </button>
                <button className="btn btn-outline-primary" onClick={() => deleteHandler(category.id)}>
                  Delete
                </button>
              </div>
            </td>
          </tr>
        ))}
      </tbody>
    </table>
  );
}

