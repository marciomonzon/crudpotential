import React from 'react';
import { Switch, Route } from 'react-router-dom';

import Home from './pages/home';
import Desenvolvedores from './pages/desenvolvedores';

const Routes: React.FC = () => {
    return (
        <Switch>
            <Route path="/" exact component={ Home } />
            <Route path="/developers" exact component={ Desenvolvedores } />
        </Switch>
    )
}

export default Routes;