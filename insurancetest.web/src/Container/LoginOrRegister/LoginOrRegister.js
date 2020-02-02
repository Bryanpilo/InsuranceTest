import React, { useEffect, useState } from 'react';
import { Container, Row, Col, Tabs, Tab, Image } from 'react-bootstrap';
import './LoginOrRegister.css'
//Containers
import Register from './Register';
import Login from './Login';

const LoginOrRegister = (props) => {

  return (
    <div>
      <Row>
        <Col sm={8}>
          <Image src="https://source.unsplash.com/random" className="imgLoginOrRegister" />
        </Col>
        <Col sm={4}>
          <Tabs defaultActiveKey="Login" id="uncontrolled-tab-example">
            <Tab eventKey="Login" title="Iniciar sesion">
              <Login />
            </Tab>  
          </Tabs>
        </Col>
      </Row>
    </div>
  );

}

export default LoginOrRegister;
