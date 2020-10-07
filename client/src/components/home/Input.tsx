import { TextField } from "@material-ui/core";
import React, { ReactElement, CSSProperties } from "react";

const style: CSSProperties = {
    position: 'absolute',
    top: '30%',
    left: '50%',
    transform: 'translate(-50%, -50%)',
    width: 700
};

const Input: React.FC = (): ReactElement => {
    return (
        <TextField variant='outlined' style={style} placeholder='Execute query' />
    );
}

export default Input;