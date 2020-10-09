import React, { ReactElement, useEffect, useState } from "react";
import { useHistory } from "react-router-dom";
import { checkIsAuthenticated, getAccessKey, IsAuthenticated, setAccessKey, setIsAuthenticated } from '../../utils';
import Navbar from './Navbar';
import Input from './Input';
import Alert from '../general/Alert';
import Button from './Button';
import { executeQuery } from '../../utils/api';
import { Color } from "@material-ui/lab";
import Table from './Table';

interface IAlert {
    isOpen: boolean;
    severity: Color;
    message: string;
}

interface ITable {
    isOpen: boolean;
    data: IData[] | null
}

export interface IData {
    columnNames: string[];
    values: string[] | number[] | boolean[];
    id: string;
}

const Home: React.FC = (): ReactElement => {
    const [alert, setAlert] = useState<IAlert>({
        isOpen: false,
        severity: 'error',
        message: ''
    });

    const [table, setTable] = useState<ITable>({
        isOpen: false,
        data: null
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

    const showTable = (data: IData[]): void => {
        setTable({
            isOpen: true,
            data: data
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
            console.log(response.data.result);
            if(response.data.result !== null) showTable(response.data.result);
        } catch(error) {
            if(error.response !== undefined) {
                if(error.response.data.Message === 'Access key is invalid') logout();
                else showAlert('error', error.response.data.Message);
            } else {
                showAlert('error', error.message);
            }
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
            <Table isOpen={table.isOpen} data={table.data} />
            <Alert severity={alert.severity} isOpen={alert.isOpen} message={alert.message} handleClose={toggleAlert} autoHideDuration={5000} />
        </>
    );
}

export default Home;