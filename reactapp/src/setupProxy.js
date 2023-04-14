const { createProxyMiddleware } = require('http-proxy-middleware');

const context = [
    "/weatherforecast",
    "/api/Authenticate/register",
    "/api/Authenticate/register-admin",
    "/api/Authenticate/login",
    "/api/Authenticate/change-password",
    "/api/Roles/create",
    "/api/Roles/delete",
    "/api/Roles/edit"

];

module.exports = function (app) {
    const appProxy = createProxyMiddleware(context, {
        target: 'https://localhost:7270',
        secure: false
    });

    app.use(appProxy);
};
