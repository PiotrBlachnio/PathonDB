import { TextField } from "@material-ui/core";
import React, { ReactElement, CSSProperties } from "react";

const style: CSSProperties = {
    position: 'relative',
    top: '50%',
    left: '50%',
    transform: 'translate(-50%, -50%)',
    width: 310
};

const Input: React.FC = (): ReactElement => {
    return (
        <TextField variant='outlined' style={style} placeholder='xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx' label='Access key'/>
    );
}

export default Input;