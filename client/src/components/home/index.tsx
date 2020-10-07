import React, { ReactElement, useEffect } from "react";
import { useHistory } from "react-router-dom";
import { checkIsAuthenticated } from '../../utils';
import Navbar from './Navbar';
import Input from './Input';

const Home: React.FC = (): ReactElement => {
    const history = useHistory();

    useEffect(() => {
        if(!checkIsAuthenticated()) history.push('/auth');
    }, [history]);
    return (
        <>
            <Navbar />
            <Input />
        </>
    );
}

export default Home;