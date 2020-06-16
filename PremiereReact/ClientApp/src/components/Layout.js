import React, {Component} from 'react';
import {NavMenu} from './nav-menu/nav-menu';

export class Layout extends Component {
    render() {
        return (
            <div>
                <NavMenu/>
                {this.props.children}
            </div>
        );
    }
}
