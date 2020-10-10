export enum IsAuthenticated {
    TRUE = 'true',
    FALSE = 'false'
}

export const checkIsAuthenticated = (): boolean => {
    return localStorage.getItem("isAuthenticated") === IsAuthenticated.TRUE;
};

export const setIsAuthenticated = (value: IsAuthenticated): void => {
    localStorage.setItem('isAuthenticated', value);
};

export const getAccessKey = (): string | null => {
    return localStorage.getItem('access-key');
};

export const setAccessKey = (value: string): void => {
    localStorage.setItem('access-key', value);
};