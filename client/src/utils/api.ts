import axios from 'axios';

export const authorizeWithAccessKey = async (key: string): Promise<void> => {
    return await axios.post('/auth/existing-key', { key });
};

export const logout = async (): Promise<void> => {
    return await axios.post('/auth/logout');
};

export const executeQuery = async (query: string): Promise<void> => {
    return await axios.post('/database/query', { query })
};