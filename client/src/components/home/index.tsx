import React, { ReactElement, useEffect } from "react";
import { useHistory } from "react-router-dom";
import { checkIsAuthenticated } from '../../utils';

const Home: React.FC = (): ReactElement => {
    const history = useHistory();

    useEffect(() => {
        if(!checkIsAuthenticated()) history.push('/auth');
    }, [history]);
    return (
        <h1>Home</h1>
    );
}

export default Home;