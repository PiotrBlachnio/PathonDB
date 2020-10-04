import React, { ReactElement, CSSProperties } from "react";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faLongArrowAltRight } from '@fortawesome/free-solid-svg-icons';

interface IProps {
    text: string;
}

const containerStyle: CSSProperties = {
    position: 'absolute',
    right: 25,
    top: 35,
    cursor: 'pointer',
    height: 50,
    transition: '.3s opacity',
    fontFamily: 'roboto',
    fontSize: 15
};

const iconStyle: CSSProperties = {
    position: 'relative',
    paddingLeft: 5,
    top: 2
};

const RightLink: React.FC<IProps> = (props): ReactElement => {
    return (
        <div style={containerStyle}>
            {props.text}
            <FontAwesomeIcon icon={faLongArrowAltRight} style={iconStyle}/>
        </div>
    );
};

export default RightLink;