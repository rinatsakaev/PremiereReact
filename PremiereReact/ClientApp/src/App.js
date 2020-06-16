import React, { Component } from 'react';
import { Layout } from './components/layout';
import Home from './pages/home';
import {Route} from 'react-router-dom';
import Page1 from './pages/page-1';
import Page2 from './pages/page-2';
export default class App extends Component {
    render() {
        return (
            <Layout>
                <Route exact path="/" component={Home} />
                <Route path='/page1' component={Page1} />
                <Route path='/page2' component={Page2} />
            </Layout>
        );
    }
}
