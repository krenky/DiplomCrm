//import { AuthProvider } from 'react-admin';
import jwtDecode from 'jwt-decode';

const apiUrl = 'http://localhost:5241'; // your asp.net core API URL


export function login(username: string, password: string) {
    const request = new Request(`${apiUrl}/api/Authenticate/login`, {
        method: 'POST',
        body: JSON.stringify({ username, password }),
        headers: new Headers({ 'Content-Type': 'application/json' }),
    });

    return fetch(request)
        .then((response) => {
            if (response.status < 200 || response.status >= 300) {
                throw new Error(response.statusText);
            }
            return response.json();
        })
        .then((data) => {
            localStorage.setItem('token', data.token);
        });
}

export function logout() {
    localStorage.removeItem('token');
    return Promise.resolve();
}

export function checkAuth() {
    return localStorage.getItem('token') ? Promise.resolve() : Promise.reject();
}

export function checkError(error: any) {
    const status = error.status;
    if (status === 401 || status === 403) {
        localStorage.removeItem('token');
        return Promise.reject();
    }
    return Promise.resolve();
}

export function getPermissions() {
    const token = localStorage.getItem('token');
    const decodedToken: { [key: string]: any } = jwtDecode(token ? token : '');
    const roles = decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
    return Promise.resolve(roles);
}

export function getIdentity() {
    const token = localStorage.getItem('token');
    if (!token) {
        return Promise.reject();
    }

    const decodedToken: { [key: string]: any } = jwtDecode(token);
    const userId = decodedToken['sub'];

    return fetch(`${apiUrl}/api/Authenticate/CurrentUser`, {
        headers: new Headers({
            Authorization: `Bearer ${token}`,
        }),
    })
        .then((response) => {
            if (response.status < 200 || response.status >= 300) {
                throw new Error(response.statusText);
            }
            return response.json();
        })
        .then((data) => {
            const { id, email, userName } = data;
            return { id, fullName: `${userName}`, email };
        });
}

//export default authProvider;