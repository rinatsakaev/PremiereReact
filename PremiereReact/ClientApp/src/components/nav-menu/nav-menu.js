import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { Glyphicon, Nav, Navbar, NavItem } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';
import './index.css';

export class NavMenu extends Component {
  render() {
    return (
      <div className={"header"}>
            <LinkContainer to={'/'} exact>
              <a className={"header__link"}>Home</a>
            </LinkContainer>
            <LinkContainer to={'/page1'}>
              <a className={"header__link"}>Page 1</a>
            </LinkContainer>
            <LinkContainer to={'/page2'}>
                <a className={"header__link"}>Page 2</a>
            </LinkContainer>
      </div>
    );
  }
}
