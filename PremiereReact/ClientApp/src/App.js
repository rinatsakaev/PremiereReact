import React, { Component } from 'react';
import { Layout } from './components/Layout';
import Home from './components/Home';
import {Route} from 'react-router-dom';
import Page1 from './components/Page1';
import Page2 from './components/Page2';
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
