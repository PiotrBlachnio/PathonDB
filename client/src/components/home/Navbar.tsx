import React, { ReactElement, CSSProperties } from "react";
import { AppBar, Toolbar, Button } from '@material-ui/core';
import { logout } from '../../utils/api';
import { useHistory } from "react-router-dom";
import { IsAuthenticated, setIsAuthenticated } from '../../utils';

const style: CSSProperties = {
    marginLeft: 'auto'
};

const Navbar: React.FC = (): ReactElement => {
    const history = useHistory();

    const handleButtonClick = async (): Promise<void> => {
        try {
            await logout();
            setIsAuthenticated(IsAuthenticated.FALSE);

            history.push('/auth');
        } catch(error) {
            console.error(error);
        }
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