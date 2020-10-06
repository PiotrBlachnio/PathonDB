export const checkIsAuthenticated = (): boolean => {
    return localStorage.getItem("isAuthenticated") === 'true';
};

export const setIsAuthenticated = (value: boolean): void => {
    localStorage.setItem('isAuthenticated', value.valueOf.toString());
};