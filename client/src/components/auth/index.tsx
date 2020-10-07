import React, { ReactElement, useEffect, useState } from "react";
import { useHistory } from "react-router-dom";
import Login from './Login';
import Register from './Register';
import { checkIsAuthenticated } from '../../utils';

export enum AuthPage {
    LOGIN = 1,
    REGISTER = 2
}

const Auth: React.FC = (): ReactElement => {
    const history = useHistory();
    const [currentPage, setCurrentPage] = useState<AuthPage>(AuthPage.LOGIN);

    const switchPage = (page: AuthPage): void => setCurrentPage(page);

    useEffect(() => {
        if(checkIsAuthenticated()) history.push('/home');
    }, [history]);
    
    const getComponentBasedOnCurrentPage = (): ReactElement => {
        if(currentPage === AuthPage.LOGIN) return <Login switchPage={switchPage} />
        else if(currentPage === AuthPage.REGISTER) return <Register switchPage={switchPage} />
        
        return <></>
    }

    return getComponentBasedOnCurrentPage()
}

export default Auth;