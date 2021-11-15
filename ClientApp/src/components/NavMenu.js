import React, { Component } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';
import AuthContext from './Storage-Context/auth-context';


export class NavMenu extends Component {
  static displayName = NavMenu.name;

  constructor (props) {
    super(props);

    this.toggleNavbar = this.toggleNavbar.bind(this);
    this.state = {
      collapsed: true
    };
  }

  toggleNavbar () {
    this.setState({
      collapsed: !this.state.collapsed
    });
  }

  
    static contextType = AuthContext;

    render() {
          

        const { isUserLoggedin: isAuthenticated, loggedOut, LoggedIn } = this.context;
        //console.log(this.context);

    return (
        <header className="topheader">
        <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" color>
          <Container>
            <NavbarBrand tag={Link} to="/">Todo Management</NavbarBrand>
            <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
            <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.collapsed} navbar>
              <ul className="navbar-nav flex-grow">
                            {!isAuthenticated && <NavItem>
                                <NavLink tag={Link} className="text-light" to="/">Login</NavLink>
                            </NavItem>}
                            {isAuthenticated && <NavItem>
                                <NavLink tag={Link} className="text-light" to="/About">About</NavLink>
                            </NavItem>}
                            {isAuthenticated && <NavItem>
                                <NavLink tag={Link} className="text-light" to="/ToDo-Items">My ToDo Items</NavLink>
                            </NavItem>}
                            {isAuthenticated && <NavItem>
                                <NavLink tag={Link} className="text-light" to="/LogOut">Logout</NavLink>
                            </NavItem>}
              </ul>
            </Collapse>
          </Container>
        </Navbar>
      </header>
    );
  }
}

//NavMenu.contextType = AuthContext;