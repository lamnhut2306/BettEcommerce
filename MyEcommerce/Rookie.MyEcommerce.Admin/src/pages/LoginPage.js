import React from 'react'
import userManager from '../utils/UserManager'

export default function LoginPage() {
    const login = () => userManager.signinRedirect();

    return (
        <div className="container-fluid">
            <div className="row">
                <div className="col" >
                    <h1>MyEcommerce</h1>
                    <button className="btn btn-primary" onClick={login}>CLICK HERE TO SIGN IN ADMIN SITE</button>
                </div>
            </div>
        </div>
    )
}
