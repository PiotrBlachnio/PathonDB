import React, { ReactElement, useEffect, useState } from "react";
import { useHistory } from "react-router-dom";
import { checkIsAuthenticated, getAccessKey } from '../../utils';
import Navbar from './Navbar';
import Input from './Input';
import Alert from '../general/Alert';
import Button from './Button';
import axios from 'axios';
import { executeQuery } from '../../utils/api';

const Home: React.FC = (): ReactElement => {
    const history = useHistory();
    const [isAlertOpen, setIsAlertOpen] = useState<boolean>(false);
    const [alertMessage, setAlertMessage] = useState<string>('');
    const [query, setQuery] = useState<string>('');

    const toggleAlert = (): void => setIsAlertOpen(isOpen => !isOpen);

    const handleInputChange = (e: React.ChangeEvent<HTMLTextAreaElement | HTMLInputElement>): void => setQuery(e.target.value);

    const performQuery = async (): Promise<void> => {
        try {
            const response = await executeQuery(query, getAccessKey());
            console.log(response);
        } catch(error) {
            console.log(Object.entries(error));
            // setIsAlertOpen(true);
            // setAlertMessage(error.response.data.Message);
        }
    };

    useEffect(() => {
        if(!checkIsAuthenticated()) history.push('/auth');
    }, [history]);

    return (
        <>
            <Navbar />
            <Input onChange={handleInputChange} />
            <Button onClick={performQuery}>Perform query</Button>
            <Alert severity='error' isOpen={isAlertOpen} message={alertMessage} handleClose={toggleAlert} autoHideDuration={3000} />
        </>
    );
}

export default Home;