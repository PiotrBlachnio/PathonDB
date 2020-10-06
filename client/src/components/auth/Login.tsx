import React, { ReactElement, useState } from "react";
import Button from './Button';
import Input from './Input';
import Container from './Container';
import Link, { Position } from './Link';
import { AuthPage } from "./index";
import { authorizeWithAccessKey } from '../../utils/api';

interface IProps {
    switchPage: (page: AuthPage) => void
}

const Login: React.FC<IProps> = (props): ReactElement => {
    const [key, setKey] = useState<string>('');
    const [isError, setIsError] = useState<boolean>(false);
    const [errorMessage, setErrorMessage] = useState<string>('');

    const onChange = (e: React.ChangeEvent<HTMLTextAreaElement | HTMLInputElement>): void => setKey(e.target.value);

    const authorize = async (): Promise<void> => {
        try {
            const response = await authorizeWithAccessKey(key);

            console.log(response);
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