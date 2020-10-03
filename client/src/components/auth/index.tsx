import React, { ReactElement } from "react";
import { Paper } from '@material-ui/core';

const paperStyle = {
    width: 700,
    position: 'absolute',
    top: '50%',
    left: '50%',
    transform: 'translate(-50%, -50%)',
    height: 300,
    border: '1px solid black'
};

const Auth: React.FC = (): ReactElement => {
    return (
        <Paper elevation={3} style={paperStyle as any}>

        </Paper>
    );
}

export default Auth;