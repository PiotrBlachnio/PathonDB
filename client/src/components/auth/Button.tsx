import { Button as MaterialButton } from "@material-ui/core";
import React, { ReactElement, CSSProperties } from "react";

interface IProps {
    onClick?: () => void
}

const style: CSSProperties = {
    position: 'relative',
    top: '70%',
    transform: 'translateX(-35%)'
};

const Button: React.FC<IProps> = (props): ReactElement => {
    return (
        <MaterialButton color='primary' variant='contained' style={style} onClick={props.onClick}>
            {props.children}
        </MaterialButton>
    );
}

export default Button;