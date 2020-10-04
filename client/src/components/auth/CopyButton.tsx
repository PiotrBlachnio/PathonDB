import React, { ReactElement, CSSProperties } from "react";
import { FileCopy } from '@material-ui/icons';

const style: CSSProperties = {

};

const CopyButton: React.FC = (props): ReactElement => {
    return (
        <FileCopy />
    );
}

export default CopyButton;