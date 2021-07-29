import { createUserManager } from "redux-oidc";
import { Common } from "../constants/Common";


const config = {
    authority: `${Common.IdentityServerHost}`,
    client_id: "Rookie.MyEcommerce.AdminSite",
    client_secret: "511536EF-F270-4058-80CA-1C89C192F69A",
    response_type: "code",
    save_tokens: true,
    post_logout_redirect_uri : `http://localhost:3000/signout-callback-oidc`,
    redirect_uri: "http://localhost:3000/callback",
    scope: "openid profile rookie.myecommerce.api identity.api",
    loadUserInfo: true,
    filterProtocolClaims: true
};

const userManager = createUserManager(config);


export default userManager;