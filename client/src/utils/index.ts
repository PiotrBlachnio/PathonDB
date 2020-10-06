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