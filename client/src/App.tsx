import React, { ReactElement } from 'react';
import Auth from './components/auth';
import { BrowserRouter as Router, Switch, Route, Redirect } from 'react-router-dom';

const App: React.FC = (): ReactElement => {
    return (
        <Router>
            <Switch>
                <Route path="/auth" component={Auth} />
            </Switch>
        </Router>
    );
}

export default App;
