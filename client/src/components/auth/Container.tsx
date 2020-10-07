import { Paper } from "@material-ui/core";
import React, { ReactElement, CSSProperties } from "react";

const style: CSSProperties = {
    width: 700,
    position: 'absolute',
    top: '50%',
    left: '50%',
    transform: 'translate(-50%, -50%)',
    height: 300
};

const Container: React.FC = (props): ReactElement => {
    return (
        <Paper elevation={24} style={style}>
            {props.children}
        </Paper>
    );
}

export default Container;