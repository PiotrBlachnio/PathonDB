import React, { ReactElement, useEffect, useState } from "react";
import { useHistory } from "react-router-dom";
import { checkIsAuthenticated } from '../../utils';
import Navbar from './Navbar';
import Input from './Input';
import Alert from '../general/Alert';
import {  executeQuery } from '../../utils/api';

const Home: React.FC = (): ReactElement => {
    const history = useHistory();
    const [isAlertOpen, setIsAlertOpen] = useState<boolean>(false);
    const [alertMessage, setAlertMessage] = useState<string>('');
    const [query, setQuery] = useState<string>('');

    const toggleAlert = (): void => setIsAlertOpen(isOpen => !isOpen);

    const performQuery = async (): Promise<void> => {
        try {
            const response = await executeQuery(query);
            console.log(response);
        } catch(error) {
            setIsAlertOpen(true);
            setAlertMessage(error.response.data.Message);
        }
    };

    useEffect(() => {
        if(!checkIsAuthenticated()) history.push('/auth');
    }, [history]);

    return (
        <>
            <Navbar />
            <Input />
            <Alert severity='error' isOpen={isAlertOpen} message={alertMessage} handleClose={toggleAlert} autoHideDuration={3000} />
        </>
    );
}

export default Home;