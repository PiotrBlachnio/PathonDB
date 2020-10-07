import React, { ReactElement, CSSProperties } from "react";
import { AppBar, Toolbar, Button } from '@material-ui/core';

const style: CSSProperties = {
    marginLeft: 'auto'
};

const Navbar: React.FC = (): ReactElement => {
    const logout = (): void => {

    };

    return (
        <AppBar>
            <Toolbar>
                <Button color='inherit' style={style} onClick={logout}>Logout</Button>
            </Toolbar>
        </AppBar>
    );
}

export default Navbar;