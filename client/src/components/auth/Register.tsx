import React, { ReactElement, useState } from "react";
import Button from './Button';
import Input from './Input';
import Container from './Container';
import Link, { Position } from "./Link";
import { AuthPage } from "./index";
import { v4 } from 'uuid';
import CopyButton from './CopyButton';
import Alert from '../general/Alert';

interface IProps {
    switchPage: (page: AuthPage) => void
}

const Register: React.FC<IProps> = (props): ReactElement => {
    const [isAlertOpen, setIsAlertOpen] = useState<boolean>(false);
    const [generatedKey, setGeneratedKey] = useState<string>('xxxxxxxx-xxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx');

    const toggleAlert = (): void => setIsAlertOpen(!isAlertOpen);

    const handleCopyButtonClick = (): void => {
        toggleAlert();
    };

    return (
        <Container>
            <Input isDisabled={true} value={generatedKey}/>
            <Button onClick={() => setGeneratedKey(v4())}>Generate</Button>
            <CopyButton onClick={handleCopyButtonClick} />
            <Link text="Use existing key" position={Position.LEFT} switchPage={props.switchPage}/>
            <Alert isOpen={isAlertOpen} handleClose={toggleAlert} severity="success" message="Access key copied successfully!" autoHideDuration={3000} />
        </Container>
    );
}

export default Register;