import React from 'react';
import { Switch, Route } from 'react-router-dom';

import Home from './pages/home';
import Desenvolvedores from './pages/desenvolvedores';
import DesenvolvedorForm from './pages/forms';


const Routes: React.FC = () => {
    return (
        <Switch>
            <Route path="/" exact component={ Home } />
            <Route path="/developers" exact component={ Desenvolvedores } />
            <Route path="/formulario" exact component={ DesenvolvedorForm } />
            <Route path="/formulario/:id" exact component={ DesenvolvedorForm } />
        </Switch>
    )
}

export default Routes;