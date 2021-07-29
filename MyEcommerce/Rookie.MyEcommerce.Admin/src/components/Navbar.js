import React, { Component } from "react";

export default class Navbar extends Component {
  render() {
    return (
      <nav className="navbar navbar-light bg-dark">
        <div className="container">
          <a className="navbar-brand" href="./">
            <img
              src="/docs/5.0/assets/brand/bootstrap-logo.svg"
              alt=""
              width="30"
              height="24"
            />
          </a>
        </div>
      </nav>
    );
  }
}
