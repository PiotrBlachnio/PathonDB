import React, { ReactElement, useState } from "react";
import Button from './Button';
import Input from './Input';
import Container from './Container';
import Link, { Position } from "./Link";
import { AuthPage } from "./index";
import { v4 } from 'uuid';
import CopyButton from './CopyButton';

interface IProps {
    switchPage: (page: AuthPage) => void
}

const Register: React.FC<IProps> = (props): ReactElement => {
    const [generatedKey, setGeneratedKey] = useState<string>('xxxxxxxx-xxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx');

    return (
        <Container>
            <Input isDisabled={true} value={generatedKey}/>
            <Button onClick={() => setGeneratedKey(v4())}>Generate</Button>
            <CopyButton />
            <Link text="Use existing key" position={Position.LEFT} switchPage={props.switchPage}/>
        </Container>
    );
}

export default Register;