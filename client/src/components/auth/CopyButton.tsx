import React, { ReactElement, CSSProperties } from "react";
import { FileCopy } from '@material-ui/icons';
import styles from '../../assets/styles.module.css';

const style: CSSProperties = {
    position: 'relative',
    top: '50%',
    left: '15%',
    transform: 'translate(-50%, -50%)',
    fontSize: 22,
    transition: '.3s opacity',
    cursor: 'pointer'
};

const CopyButton: React.FC = (props): ReactElement => {
    return (
        <FileCopy style={style} className={styles.copy_icon} />
    );
}

export default CopyButton;