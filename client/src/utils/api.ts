import axios from 'axios';

export const authorizeWithAccessKey = async (key: string): Promise<void> => {
    return await axios.post('/auth/existing-key', { key });
};