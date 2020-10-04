import React, { ReactElement } from "react";
import Button from './Button';
import Input from './Input';
import Container from './Container';
import Link, { Position } from './Link';
import { AuthPage } from "./index";

interface IProps {
    switchPage: (page: AuthPage) => void
}

const Login: React.FC<IProps> = (props): ReactElement => {
    return (
        <Container>
            <Input isDisabled={false} placeholder="Access key" />
            <Button>Authenticate</Button>
            <Link text="Generate new key" position={Position.RIGHT} switchPage={props.switchPage}/>
        </Container>
    );
}

export default Login;