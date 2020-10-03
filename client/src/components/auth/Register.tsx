import React, { ReactElement } from "react";
import Button from './Button';
import Input from './Input';
import Container from './Container';

const Register: React.FC = (): ReactElement => {
    return (
        <Container>
            <Input />
            <Button>Generate</Button>
        </Container>
    );
}

export default Register;