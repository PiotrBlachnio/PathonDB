import React, { ReactElement, useEffect, useState } from "react";
import { useHistory } from "react-router-dom";
import { checkIsAuthenticated, getAccessKey, IsAuthenticated, setAccessKey, setIsAuthenticated } from '../../utils';
import Navbar from './Navbar';
import Input from './Input';
import Alert from '../general/Alert';
import Button from './Button';
import { executeQuery } from '../../utils/api';
import { Color } from "@material-ui/lab";

interface IAlert {
    isOpen: boolean;
    severity: Color;
    message: string;
}

const Home: React.FC = (): ReactElement => {
    const [alert, setAlert] = useState<IAlert>({
        isOpen: false,
        severity: 'error',
        message: ''
    });

    const history = useHistory();
    const [query, setQuery] = useState<string>('');

    const toggleAlert = (): void => setAlert((alert) => ({ ...alert, isOpen: !alert.isOpen }));

    const handleInputChange = (e: React.ChangeEvent<HTMLTextAreaElement | HTMLInputElement>): void => setQuery(e.target.value);

    const showAlert = (severity: Color, message: string): void => {
        setAlert({
            message,
            severity,
            isOpen: true
        });
    };

    const logout = (): void => {
        setIsAuthenticated(IsAuthenticated.FALSE);
        setAccessKey('');

        history.push('/auth');
    };

    const performQuery = async (): Promise<void> => {
        try {
            const response = await executeQuery(query, getAccessKey());
            showAlert('success', 'Query executed successfully');
            console.log(response);
            //TODO: Add success message and create table with data
        } catch(error) {
            if(error.response.data.Message === 'Access key is invalid') logout();
            else showAlert('error', error.response.data.Message);
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
            <Alert severity={alert.severity} isOpen={alert.isOpen} message={alert.message} handleClose={toggleAlert} autoHideDuration={3000} />
        </>
    );
}

export default Home;