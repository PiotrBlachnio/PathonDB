import axios, { AxiosResponse } from 'axios';

export const authorizeWithAccessKey = async (key: string): Promise<AxiosResponse<any>> => {
    return await axios.post('/auth', { key });
};

export const executeQuery = async (query: string, accessKey: string | null): Promise<AxiosResponse<any>> => {
    return await axios.post('/database/query', { query }, { headers: { 'access-key': accessKey }})
};