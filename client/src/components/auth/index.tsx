import React, { ReactElement, useState } from "react";
import Login from './Login';
import Register from './Register';

enum AuthPage {
    LOGIN = 1,
    REGISTER = 2
}

const Auth: React.FC = (): ReactElement => {
    const [currentPage, setCurrentPage] = useState<AuthPage>(AuthPage.LOGIN);

    const renderPage = (): ReactElement => {
        if(currentPage == AuthPage.LOGIN) {
            return <Login />
        } else {
            return <Register />
        }
    }

    return renderPage();
}

export default Auth;