import React, { ReactElement, CSSProperties } from "react";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faLongArrowAltRight } from '@fortawesome/free-solid-svg-icons';
import styles from '../../assets/styles.module.css';

export enum Position {
    LEFT = 1,
    RIGHT = 2
}

interface IProps {
    text: string;
    position: Position; 
}

const rightContainerStyle: CSSProperties = {
    position: 'absolute',
    right: 25,
    top: 35,
    cursor: 'pointer',
    height: 50,
    transition: '.3s opacity',
    fontFamily: 'roboto',
    fontSize: 15
};

const rightIconStyle: CSSProperties = {
    position: 'relative',
    paddingLeft: 5,
    top: 2
};

const Link: React.FC<IProps> = (props): ReactElement => {
    return (
        <div style={rightContainerStyle} className={styles.link}>
            {props.text}
            <FontAwesomeIcon icon={faLongArrowAltRight} style={rightIconStyle}/>
        </div>
    );
}

// const RightLink: React.FC<IProps> = (props): ReactElement => {
//     return (
//         <div style={containerStyle}>
//             {props.text}
//             <FontAwesomeIcon icon={faLongArrowAltRight} style={iconStyle}/>
//         </div>
//     );
// };

export default Link;