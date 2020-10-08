import React, { ReactElement, useEffect, useState } from "react";
import { useHistory } from "react-router-dom";
import { checkIsAuthenticated } from '../../utils';
import Navbar from './Navbar';
import Input from './Input';
import Alert from '../general/Alert';

const Home: React.FC = (): ReactElement => {
    const history = useHistory();
    const [isAlertOpen, setIsAlertOpen] = useState<boolean>(false);
    const [alertMessage, setAlertMessage] = useState<string>('');

    const toggleAlert = (): void => setIsAlertOpen(isOpen => !isOpen);

    const performQuery = async (query: string): Promise<void> => {
        
    };
    useEffect(() => {
        if(!checkIsAuthenticated()) history.push('/auth');
    }, [history]);

    return (
        <>
            <Navbar />
            <Input />
            <Alert severity='error' isOpen={isAlertOpen} message={alertMessage} handleClose={toggleAlert} />
        </>
    );
}

export default Home;