import { TextField } from "@material-ui/core";
import React, { ReactElement, CSSProperties } from "react";

interface IProps {
    isDisabled: boolean;
    value?: string;
    placeholder?: string;
    isError?: boolean;
    errorMessage?: string;
    onChange?: (e: React.ChangeEvent<HTMLTextAreaElement | HTMLInputElement>) => void;
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
        <TextField helperText={props.errorMessage} error={props.isError} variant='outlined' style={style} value={props.value} placeholder={props.placeholder} disabled={props.isDisabled} onChange={props.onChange} />
    );
}

export default Input;