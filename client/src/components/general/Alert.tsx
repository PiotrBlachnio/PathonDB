import React, { ReactElement, CSSProperties } from "react";
import { Snackbar, makeStyles } from '@material-ui/core';
import { Alert as MaterialAlert, Color } from '@material-ui/lab';

interface IProps {
    isOpen: boolean;
    handleClose: () => void;
    severity: Color;
    message: string;
    autoHideDuration?: number;
}

const Alert: React.FC<IProps> = (props): ReactElement => {
    return (
        <Snackbar open={props.isOpen} autoHideDuration={props.autoHideDuration} onClose={props.handleClose}>
            <MaterialAlert onClose={props.handleClose} severity={props.severity} elevation={12} variant="filled" >
                {props.message}
            </MaterialAlert>
        </Snackbar>
    );
}

export default Alert;