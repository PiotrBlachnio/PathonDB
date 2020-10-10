import { Button as MaterialButton } from "@material-ui/core";
import React, { ReactElement, CSSProperties } from "react";

interface IProps {
    onClick?: () => Promise<void>;
}

const style: CSSProperties = {
    position: 'absolute',
    top: '30%',
    left: '50%',
    transform: 'translate(-50%, -50%)',
    width: 200
};

const Button: React.FC<IProps> = (props): ReactElement => {
    return (
        <MaterialButton color='primary' variant='contained' style={style} onClick={props.onClick}>
            {props.children}
        </MaterialButton>
    );
}

export default Button;