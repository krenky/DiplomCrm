import { stringify } from 'querystring';
import { DataProvider, GetManyReferenceParams, GetManyReferenceResult, RaRecord, fetchUtils } from 'react-admin';
import Header from '../Header';
import { string } from 'prop-types';

const apiUrl = 'https://localhost:7270/api'; // your asp.net core API URL

const httpClient = (url: string, options: any = {}) => {
    if (!options.headers) {
        options.headers = new Headers({ Accept: 'application/json' });
    }
    const token = localStorage.getItem('token');
    options.headers.set('Authorization', `Bearer ${token}`);
    return fetchUtils.fetchJson(url, options);
};

const dataProvider: DataProvider = {
    getList: (resource, params) => {
        const { page, perPage } = params.pagination;
        const { field, order } = params.sort;
        const query = {
            sort: `${field},${order}`,
            range: `${(page - 1) * perPage},${page * perPage - 1}`,
            filter: JSON.stringify(params.filter),
        };
        const url = `${apiUrl}/${resource}?${stringify(query)}`;
        let getTotal = (header: Headers) => {
            const contentRange = header.get('content-range');
            if(contentRange != null){
                const [, total] = contentRange.split(/\//);
                return total as string;
            }
            else{
                return "0"
            }
        }
        
        return httpClient(url).then(({ headers, json }) => ({
            data: json,
            total: parseInt(getTotal(headers), 10),
        }));
    },

    getOne: (resource, params) => httpClient(`${apiUrl}/${resource}/${params.id}`).then(({ json }) => ({
        data: json,
    })),

    getMany: (resource, params) => {
        const query = {
            filter: JSON.stringify({ Id: params.ids }),
        };
        const url = `${apiUrl}/${resource}?${stringify(query)}`;

        return httpClient(url).then(({ json }) => ({ data: json }));
    },

    create: (resource, params) => httpClient(`${apiUrl}/${resource}`, {
        method: 'POST',
        body: JSON.stringify(params.data),
    }).then(({ json }) => ({
        data: { ...params.data, Id: json.Id },
    })),

    update: (resource, params) => httpClient(`${apiUrl}/${resource}/${params.id}`, {
        method: 'PUT',
        body: JSON.stringify(params.data),
    }).then(({ json }) => ({ data: json })),

    updateMany: (resource, params) => {
        const query = {
            filter: JSON.stringify({ Id: params.ids }),
        };
        return httpClient(`${apiUrl}/${resource}?${stringify(query)}`, {
            method: 'PUT',
            body: JSON.stringify(params.data),
        }).then(({ json }) => ({ data: json }));
    },

    delete: (resource, params) => httpClient(`${apiUrl}/${resource}/${params.id}`, {
        method: 'DELETE',
    }).then(({ json }) => ({ data: json })),

    deleteMany: (resource, params) => {
        const query = {
            filter: JSON.stringify({ Id: params.ids }),
        };
        return httpClient(`${apiUrl}/${resource}?${stringify(query)}`, {
            method: 'DELETE',
        }).then(({ json }) => ({ data: json }));
    },
    getManyReference: function <RecordType extends RaRecord = any>(): Promise<GetManyReferenceResult<RecordType>> {
        throw new Error('Function not implemented.');
    }
}

export default dataProvider;