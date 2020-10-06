import React, { ReactElement, useState } from "react";
import Button from './Button';
import Input from './Input';
import Container from './Container';
import Link, { Position } from './Link';
import { AuthPage } from "./index";
import axios from 'axios';

interface IProps {
    switchPage: (page: AuthPage) => void
}

const Login: React.FC<IProps> = (props): ReactElement => {
    const [key, setKey] = useState<string>('');

    const onChange = (e: React.ChangeEvent<HTMLTextAreaElement | HTMLInputElement>): void => setKey(e.target.value);

    const authorize = async (): Promise<void> => {
        // try {
            const response = await axios.post('http://localhost:5000/api/v1/auth/existing-key', { key }, { headers: {
                'Content-Type': 'application/json'
            }});

            console.log(response);
        // } catch(error) {
        //     console.log(error);
        // }
    };

    return (
        <Container>
            <Input isDisabled={false} placeholder="Access key" onChange={onChange} />
            <Button onClick={authorize}>Authenticate</Button>
            <Link text="Generate new key" position={Position.RIGHT} switchPage={props.switchPage}/>
        </Container>
    );
}

export default Login;