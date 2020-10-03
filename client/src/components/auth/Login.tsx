import React, { ReactElement } from "react";
import Button from './Button';
import Input from './Input';
import Container from './Container';

const Login: React.FC = (): ReactElement => {
    return (
        <Container>
            <Input />
            <Button>Authenticate</Button>
        </Container>
    );
}

export default Login;