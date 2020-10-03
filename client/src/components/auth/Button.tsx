import { Button as MaterialButton } from "@material-ui/core";
import React, { ReactElement, CSSProperties } from "react";

const style: CSSProperties = {
    position: 'relative',
    top: '70%',
    transform: 'translateX(-25%)'
};

const Button: React.FC = (props): ReactElement => {
    return (
        <MaterialButton color='primary' variant='contained' style={style}>
            {props.children}
        </MaterialButton>
    );
}

export default Button;