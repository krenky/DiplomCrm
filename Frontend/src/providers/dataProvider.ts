import axios, { AxiosInstance, AxiosResponse } from 'axios';


export interface RequestOptions {
    method: 'get' | 'post' | 'put' | 'delete';
    url: string;
    data?: any;
    headers?: any;
}

export interface DataProviderResponse<T> {
    data?: T;
    total?: number;
}

export class DataProvider {
    private http: AxiosInstance;
    private token: string | null;

    constructor(url:string) {
        this.http = axios.create({
            baseURL: url || 'https://localhost:7270/api',
        });

        // Set the token from local storage if it exists
        this.token = localStorage.getItem('token');
    }

    setToken(token: string) {
        this.token = token;
        localStorage.setItem('token', token);
    }

    async request<T>({ method, url, data, headers }: RequestOptions): Promise<AxiosResponse<T>> {
        if (this.token) {
            headers = {
                ...headers,
                Authorization: `Bearer ${this.token}`,
            };
        }

        return this.http.request<T>({
            method,
            url,
            data,
            headers,
        });
    }

    async getList<T>(resource: string, params?: any): Promise<DataProviderResponse<T[]>> {
        const { data } = await this.request<T[]>({
            method: 'get',
            url: `/${resource}`,
            //params
        });

        return { data, total: data.length };
    }

    async getOne<T>(resource: string, id: string): Promise<DataProviderResponse<T>> {
        const { data } = await this.request<T>({
            method: 'get',
            url: `/${resource}/${id}`,
        });

        return { data };
    }

    async create<T>(resource: string, data: any): Promise<DataProviderResponse<T>> {
        const { data: createdData } = await this.request<T>({
            method: 'post',
            url: `/${resource}`,
            data,
        });

        return { data: createdData };
    }

    async update<T>(resource: string, id: string, data: any): Promise<DataProviderResponse<T>> {
        const { data: updatedData } = await this.request<T>({
            method: 'put',
            url: `/${resource}/${id}`,
            data,
        });

        return { data: updatedData };
    }

    async delete<T>(resource: string, id: string): Promise<DataProviderResponse<T>> {
        const { data: deletedData } = await this.request<T>({
            method: 'delete',
            url: `/${resource}/${id}`,
        });

        return { data: deletedData };
    }
}

export default new DataProvider('https://localhost:7270/api');