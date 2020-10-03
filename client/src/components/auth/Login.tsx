import React, { ReactElement } from "react";
import Button from './Button';
import Input from './Input';
import Container from './Container';
import Link, { Position } from './Link';

const Login: React.FC = (): ReactElement => {
    return (
        <Container>
            <Input />
            <Button>Authenticate</Button>
            <Link text="Generate new key" position={Position.RIGHT} />
        </Container>
    );
}

export default Login;