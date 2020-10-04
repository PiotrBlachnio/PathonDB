import React, { ReactElement, useState } from "react";
import Login from './Login';
import Register from './Register';

export enum AuthPage {
    LOGIN = 1,
    REGISTER = 2
}

const Auth: React.FC = (): ReactElement => {
    const [currentPage, setCurrentPage] = useState<AuthPage>(AuthPage.LOGIN);

    const switchPage = (page: AuthPage): void => setCurrentPage(page);

    const getComponentBasedOnCurrentPage = (): ReactElement => {
        if(currentPage === AuthPage.LOGIN) return <Login switchPage={switchPage} />
        else if(currentPage === AuthPage.REGISTER) return <Register switchPage={switchPage} />
        
        return <></>
    }

    return getComponentBasedOnCurrentPage()
}

export default Auth;