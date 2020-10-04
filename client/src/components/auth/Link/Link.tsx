import React, { ReactElement } from "react";
import RightLink from './RightLink';

export enum Position {
    LEFT = 1,
    RIGHT = 2
}

interface IProps {
    text: string;
    position: Position; 
}

const Link: React.FC<IProps> = (props): ReactElement => {
    const getComponentBasedOnPosition = (): ReactElement => {
        if(props.position == Position.LEFT) return <></>
        else if(props.position == Position.RIGHT) return <RightLink text={props.text} />

        return <></>
    }

    return getComponentBasedOnPosition();
}

//TODO: Create separate components for right and left link. Render them based on condition in Link component;
export default Link;