import React, { ReactElement } from 'react';
import Auth from './components/auth';
import Home from './components/home';
import { BrowserRouter as Router, Switch, Route, Redirect } from 'react-router-dom';

const App: React.FC = (): ReactElement => {
    return (
        <Router>
            <Switch>
                <Route path="/auth" component={Auth} />
                <Route path="/home" component={Home} />
                <Redirect from='*' to='/home' />
            </Switch>
        </Router>
    );
}

export default App;
