import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { Glyphicon, Nav, Navbar, NavItem } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';
import './index.css';

export class NavMenu extends Component {
  render() {
    return (
      <div>
            <LinkContainer to={'/'} exact>
              <NavItem>
                <Glyphicon glyph='home' /> Home
              </NavItem>
            </LinkContainer>
            <LinkContainer to={'/page1'}>
              <NavItem>
                <Glyphicon glyph='home' /> Page 1
              </NavItem>
            </LinkContainer>
            <LinkContainer to={'/page2'}>
              <NavItem>
                <Glyphicon glyph='home' /> Page 2
              </NavItem>
            </LinkContainer>
      </div>
    );
  }
}
