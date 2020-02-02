import React, { useEffect, useRef } from 'react';
import { Form, Button } from 'react-bootstrap';
import http from "../../Services/HttpService";
import { toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
//redux
import { useSelector, useDispatch } from "react-redux";
//actions
import LoginAction from "../../Redux/Action/LoginAction";

const Login = (props) => {

  toast.configure()
  const dispatch = useDispatch();

  const username= useRef();
  const password= useRef();

  const login = () => {
    const queryObj = {
      username: username.current.value,
      password: password.current.value
    };

    http.post(http.url+"user/login", queryObj)
    .then(function (response) {
    
       if(response.status===200){
        dispatch(LoginAction.setUsername(response.data.userName));
        dispatch(LoginAction.setToken(response.data.token));
        sessionStorage.setItem('userName', response.data.userName);
        sessionStorage.setItem('token', response.data.token);
        sessionStorage.setItem('login', true);
        dispatch(LoginAction.isLogin());
      }
    })
    .catch(function (error) {
    });
  };


  return (
    <Form>
      <Form.Group controlId="formBasicEmail">
        <Form.Label>Usuario</Form.Label>
        <Form.Control type="text" placeholder="Ingresa tu usuario" ref={username} />
      </Form.Group>

      <Form.Group controlId="formBasicPassword">
        <Form.Label>Contraseña</Form.Label>
        <Form.Control type="password" placeholder="Password" ref={password}/>
      </Form.Group>
      <Button variant="primary" onClick={()=>login()}>
        Iniciar sesion
    </Button>
    </Form>
  );

}

export default Login;
