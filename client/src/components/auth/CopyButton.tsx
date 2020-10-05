import React, { ReactElement, CSSProperties } from "react";
import { FileCopy } from '@material-ui/icons';

const style: CSSProperties = {
    position: 'relative',
    top: '50%',
    left: '15%',
    transform: 'translate(-50%, -50%)',
    fontSize: 22
};

const CopyButton: React.FC = (props): ReactElement => {
    return (
        <FileCopy style={style} />
    );
}

export default CopyButton;