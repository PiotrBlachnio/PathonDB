import React, { ReactElement } from "react";
import RightLink from './RightLink';
import LeftLink from './LeftLink';
import { AuthPage } from "../index";

export enum Position {
    LEFT = 1,
    RIGHT = 2
}

interface IProps {
    text: string;
    switchPage: (page: AuthPage) => void;
    position: Position; 
}

const Link: React.FC<IProps> = (props): ReactElement => {
    const getComponentBasedOnPosition = (): ReactElement => {
        if(props.position === Position.LEFT) return <LeftLink text={props.text} switchPage={props.switchPage} />
        else if(props.position === Position.RIGHT) return <RightLink text={props.text} switchPage={props.switchPage} />

        return <></>
    }

    return getComponentBasedOnPosition();
}

export default Link;