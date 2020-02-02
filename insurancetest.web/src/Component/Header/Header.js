import React, { useEffect, useRef } from 'react';
import { Form, Button, Navbar, Nav, FormControl } from 'react-bootstrap';
import { NavLink, withRouter } from "react-router-dom";
//redux
import { useSelector, useDispatch } from "react-redux";
//actions
import LoginAction from "../../Redux/Action/LoginAction";


const Header = (props) => {

  const dispatch = useDispatch();

  const logout = () => {
    sessionStorage.removeItem('login');
    sessionStorage.removeItem('userName');
    sessionStorage.removeItem('token');
    dispatch(LoginAction.setUsername(null));
    dispatch(LoginAction.setToken(null));
    dispatch(LoginAction.isLogin());
    props.history.replace("/");
  }

  return (
    <Navbar bg="dark" variant="dark">
      <Navbar.Brand href="#home">GAP</Navbar.Brand>
      <Nav className="mr-auto">
        <NavLink
          to="/"
        >
          Home
      </NavLink>
      </Nav>
      <Form inline>
        <Button variant="outline-info" onClick={() => logout()}>Cerrar sesion</Button>
      </Form>
    </Navbar>
  )
}


export default withRouter(Header)
