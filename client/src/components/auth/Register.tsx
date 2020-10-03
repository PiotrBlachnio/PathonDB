import React, { CSSProperties, ReactElement } from "react";
import Button from './Button';
import { Paper, TextField } from '@material-ui/core';

const paperStyle: CSSProperties = {
    width: 700,
    position: 'absolute',
    top: '50%',
    left: '50%',
    transform: 'translate(-50%, -50%)',
    height: 300
};

const inputStyle = {
    position: 'relative',
    top: '50%',
    left: '50%',
    transform: 'translate(-50%, -50%)',
    width: 310
};

const Register: React.FC = (): ReactElement => {
    return (
        <Paper elevation={24} style={paperStyle as any}>
            <TextField variant='outlined' style={inputStyle as any} placeholder='xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx' label='Access key'/>
            <Button>Generate</Button>
        </Paper>
    );
}

export default Register;