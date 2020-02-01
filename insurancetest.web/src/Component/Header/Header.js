import React, { useEffect, useRef } from 'react';
import { Form, Button, Navbar, Nav, FormControl } from 'react-bootstrap';
import { withRouter } from 'react-router-dom';
//redux
import { useSelector, useDispatch } from "react-redux";
//actions
import LoginAction from "../../Redux/Action/LoginAction";


const Header = (props) => {

  const dispatch = useDispatch();

  const logout = () => {
    sessionStorage.removeItem('login');
    dispatch(LoginAction.setUsername(null));
    dispatch(LoginAction.setToken(null));
    dispatch(LoginAction.isLogin());
  }

  return (
    <Navbar bg="dark" variant="dark">
      <Navbar.Brand href="#home">GAP</Navbar.Brand>
      <Nav className="mr-auto">
        <Nav.Link href="#home">Home</Nav.Link>
      </Nav>
      <Form inline>
        <Button variant="outline-info" onClick={()=>logout()}>Cerrar sesion</Button>
      </Form>
    </Navbar>
  )
}


export default withRouter(Header)
