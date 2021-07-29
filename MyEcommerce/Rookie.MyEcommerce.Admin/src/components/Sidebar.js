import React, { Component } from "react";

export default class Sidebar extends Component {
  render() {
    return (
      <div className="d-flex flex-column flex-shrink-0 p-3 text-white bg-dark collapse w-100 sticky">
        <a
          href="/"
          className="d-flex align-items-center mb-3 mb-md-0 me-md-auto text-white text-decoration-none"
        >
          <span className="fs-4">Sidebar</span>
        </a>
        <hr />
        <ul className="nav nav-pills flex-column mb-auto">
          <li className="nav-item">
            <a href="/" className="nav-link text-white">
              Category
            </a>
          </li>
          <li>
            <a href="/Product" className="nav-link text-white">
              Product
            </a>
          </li>
          <li>
            <a href="/Order" className="nav-link text-white">
              Orders
            </a>
          </li>
        </ul>
        <hr />
        <div className="dropdown">
          <a
            href="/"
            className="d-flex align-items-center text-white text-decoration-none dropdown-toggle"
            id="dropdownUser1"
            data-bs-toggle="dropdown"
            aria-expanded="false"
          >
            <strong></strong>
          </a>
          <ul
            className="dropdown-menu dropdown-menu-dark text-small shadow"
            aria-labelledby="dropdownUser1"
          >
            <li>
              <a className="dropdown-item" href="/">
                Profile
              </a>
            </li>
            <li>
              <a className="dropdown-item" href="/">
                Sign out
              </a>
            </li>
          </ul>
        </div>
      </div>
    );
  }
}
