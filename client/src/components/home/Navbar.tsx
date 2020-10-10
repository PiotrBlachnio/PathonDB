import React, { ReactElement, CSSProperties } from "react";
import { AppBar, Toolbar, Button } from '@material-ui/core';
import { useHistory } from "react-router-dom";
import { IsAuthenticated, setAccessKey, setIsAuthenticated } from '../../utils';

const style: CSSProperties = {
    marginLeft: 'auto'
};

const Navbar: React.FC = (): ReactElement => {
    const history = useHistory();

    const handleButtonClick = async (): Promise<void> => {
        setIsAuthenticated(IsAuthenticated.FALSE);
        setAccessKey('');

        history.push('/auth');
    };

    return (
        <AppBar>
            <Toolbar>
                <Button color='inherit' style={style} onClick={handleButtonClick}>Logout</Button>
            </Toolbar>
        </AppBar>
    );
}

export default Navbar;