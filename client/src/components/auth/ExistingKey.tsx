import React, { ReactElement } from "react";
import { Paper, TextField, Button } from '@material-ui/core';

const paperStyle = {
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

const buttonStyle = {
    position: 'relative',
    top: '70%',
    transform: 'translateX(-25%)'
};

const Auth: React.FC = (): ReactElement => {
    return (
        <Paper elevation={24} style={paperStyle as any}>
            <TextField variant='outlined' style={inputStyle as any} placeholder='xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx' label='Access key'/>
            <Button color='primary' variant='contained' style={buttonStyle as any}>Authenticate</Button>
        </Paper>
    );
}

export default Auth;

//TODO: Create existing key and new key components
//TODO: Render above components based on condition in index auth
//TODO: Add links with arrows to switch between them