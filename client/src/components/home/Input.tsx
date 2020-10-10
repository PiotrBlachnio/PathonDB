import { TextField } from "@material-ui/core";
import React, { ReactElement, CSSProperties } from "react";

interface IProps {
    onChange?: (e: React.ChangeEvent<HTMLTextAreaElement | HTMLInputElement>) => void;
}

const style: CSSProperties = {
    position: 'absolute',
    top: '20%',
    left: '50%',
    transform: 'translate(-50%, -50%)',
    width: 700
};

const Input: React.FC<IProps> = (props): ReactElement => {
    return (
        <TextField variant='outlined' style={style} placeholder='Query...' onChange={props.onChange} spellCheck={false} />
    );
}

export default Input;