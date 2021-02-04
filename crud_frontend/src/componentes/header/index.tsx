import React from 'react';
import { Nav, Navbar } from 'react-bootstrap';
import { Link } from 'react-router-dom';

const Header: React.FC = () => {
    return (
        <Navbar bg="light" expand="lg">
            <Navbar.Brand href="/">Cadastro de Desenvolvedores</Navbar.Brand>
            <Navbar.Toggle aria-controls="basic-navbar-nav" />
            <Navbar.Collapse id="basic-navbar-nav">
                <Nav className="mr-auto">
                <Nav.Item as={Link} to="/" className="nav-link">Home</Nav.Item>
                <Nav.Item as={Link} to="/developers" className="nav-link"> Desenvolvedores</Nav.Item>
                </Nav>
            </Navbar.Collapse>
        </Navbar>
    )
}

export default Header;