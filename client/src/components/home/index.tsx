import React, { ReactElement, useEffect } from "react";
import { useHistory } from "react-router-dom";
import { checkIsAuthenticated } from '../../utils';
import Navbar from './Navbar';

const Home: React.FC = (): ReactElement => {
    const history = useHistory();

    useEffect(() => {
        if(!checkIsAuthenticated()) history.push('/auth');
    }, [history]);
    return (
        <>
            <Navbar />
            <h1>Home</h1>
        </>
    );
}

export default Home;