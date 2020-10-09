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
    const history = useHistory();
    const [alert, setAlert] = useState<IAlert>({
        isOpen: false,
        severity: 'error',
        message: ''
    });

    const [isAlertOpen, setIsAlertOpen] = useState<boolean>(false);
    const [alertMessage, setAlertMessage] = useState<string>('');
    const [alertSeverity, setAlertSeverity] = useState<Color>('error');
    const [query, setQuery] = useState<string>('');

    const toggleAlert = (): void => setIsAlertOpen(isOpen => !isOpen);

    const handleInputChange = (e: React.ChangeEvent<HTMLTextAreaElement | HTMLInputElement>): void => setQuery(e.target.value);

    const showAlert = (severity: Color, message: string): void => {
        setAlertMessage(message);
        setAlertSeverity(severity);
        setIsAlertOpen(true);
    };

    const logout = (): void => {
        setIsAuthenticated(IsAuthenticated.FALSE);
        setAccessKey('');

        history.push('/auth');
    };

    const performQuery = async (): Promise<void> => {
        try {
            const response = await executeQuery(query, getAccessKey());
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
            <Alert severity={alertSeverity} isOpen={isAlertOpen} message={alertMessage} handleClose={toggleAlert} autoHideDuration={3000} />
        </>
    );
}

export default Home;