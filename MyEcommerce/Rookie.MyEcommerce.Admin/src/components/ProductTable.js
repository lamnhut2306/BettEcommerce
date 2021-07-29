import React from "react";

export default function ProductTable(props) {
  const products = props.products;
  const editHandler = (product) => props.onEdit(product);
  const deleteHandler = (productId) => props.onDelete(productId);
  return (
    <table className="table">
      <thead>
        <tr>
          <th scope="col">#</th>
          <th scope="col">Name</th>
          <th scope="col">Description</th>
          <th scope="col">Unit Price</th>
          <th scope="col">Discount</th>
          <th scope="col"></th>
        </tr>
      </thead>
      <tbody>
        {products.map((product, index) => (
          <tr key={product.id}>
            <td>{index + 1}</td>
            <td>{product.name}</td>
            <td>{product.description}</td>
            <td>{product.unitPrice}</td>
            <td>{product.discount}</td>
            <td>
              <div className="btn-group">
                <button
                  className="btn btn-outline-primary"
                  onClick={() => editHandler(product)}
                >
                  Edit
                </button>
                <button
                  className="btn btn-outline-primary"
                  onClick={() => deleteHandler(product.id)}
                >
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
