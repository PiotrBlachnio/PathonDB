import { TextField } from "@material-ui/core";
import React, { ReactElement, CSSProperties } from "react";

interface IProps {
    value?: string;
    placeholder?: string;
    isDisabled: boolean;
}

const style: CSSProperties = {
    position: 'relative',
    top: '50%',
    left: '50%',
    transform: 'translate(-50%, -50%)',
    width: 340
};

const Input: React.FC<IProps> = (props): ReactElement => {
    return (
        <TextField variant='outlined' style={style} value={props.value} placeholder={props.placeholder} disabled={props.isDisabled} />
    );
}

export default Input;