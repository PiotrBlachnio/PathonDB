import React, { ReactElement, useState } from "react";
import Button from './Button';
import Input from './Input';
import Container from './Container';
import Link, { Position } from './Link';
import { AuthPage } from "./index";
import { authorizeWithAccessKey } from '../../utils/api';
import { setIsAuthenticated, IsAuthenticated, setAccessKey } from '../../utils';
import { useHistory } from "react-router-dom";

interface IProps {
    switchPage: (page: AuthPage) => void
}

const Login: React.FC<IProps> = (props): ReactElement => {
    const history = useHistory();
    const [key, setKey] = useState<string>('');
    const [isError, setIsError] = useState<boolean>(false);
    const [errorMessage, setErrorMessage] = useState<string>('');

    const onChange = (e: React.ChangeEvent<HTMLTextAreaElement | HTMLInputElement>): void => setKey(e.target.value);

    const authorize = async (): Promise<void> => {
        try {
            await authorizeWithAccessKey(key);
            setIsAuthenticated(IsAuthenticated.TRUE);
            
            setAccessKey(key);
            history.push('/home');
        } catch(error) {
            setIsError(true);
            setErrorMessage(error.response.data.Message);
        }
    };

    return (
        <Container>
            <Input isDisabled={false} placeholder="Access key" onChange={onChange} isError={isError} errorMessage={errorMessage} />
            <Button onClick={authorize}>Authenticate</Button>
            <Link text="Generate new key" position={Position.RIGHT} switchPage={props.switchPage}/>
        </Container>
    );
}

export default Login;