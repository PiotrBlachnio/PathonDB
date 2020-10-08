import axios from 'axios';

export const authorizeWithAccessKey = async (key: string): Promise<void> => {
    return await axios.post('/auth', { key });
};

export const executeQuery = async (query: string, accessKey: string | null): Promise<void> => {
    console.log(accessKey);
    return await axios.post('/database/query', { query }, { headers: { 'access-key': accessKey }})
};