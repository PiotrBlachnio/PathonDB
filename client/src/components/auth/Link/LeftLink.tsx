import React, { ReactElement, CSSProperties } from "react";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faLongArrowAltLeft } from '@fortawesome/free-solid-svg-icons';
import styles from '../../../assets/styles.module.css';
import { AuthPage } from "../index";

interface IProps {
    text: string;
    switchPage: (page: AuthPage) => void;
}

const containerStyle: CSSProperties = {
    position: 'absolute',
    left: 25,
    top: 35,
    cursor: 'pointer',
    height: 50,
    transition: '.3s opacity',
    fontFamily: 'roboto',
    fontSize: 15
};

const iconStyle: CSSProperties = {
    position: 'relative',
    paddingRight: 5,
    top: 2
};

const LeftLink: React.FC<IProps> = (props): ReactElement => {
    return (
        <div style={containerStyle} className={styles.link} onClick={() => props.switchPage(AuthPage.LOGIN)} >
            <FontAwesomeIcon icon={faLongArrowAltLeft} style={iconStyle}/>
            {props.text}
        </div>
    );
};

export default LeftLink;