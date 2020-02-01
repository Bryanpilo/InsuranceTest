import React, { useEffect, useState } from 'react';
import { Container, Row, Col, Tabs, Tab, Image } from 'react-bootstrap';
import './LoginOrRegister.css'
//Containers
import Register from './Register';
import Login from './Login';
//redux
// import { useDispatch } from 'react-redux';
//actions
// import dashBoardActions from '../../Actions/DashBoardAction';

const LoginOrRegister = (props) => {

  return (
    <div>
      <Row>
        <Col sm={8}>
          <Image src="https://source.unsplash.com/random" className="imgLoginOrRegister" />
        </Col>
        <Col sm={4}>
          <Tabs defaultActiveKey="Login" id="uncontrolled-tab-example">
            <Tab eventKey="Login" title="Login">
              <Login />
            </Tab>
            <Tab eventKey="Register" title="Register">
              <Register />
            </Tab>
          </Tabs>
        </Col>
      </Row>
    </div>
  );

}

export default LoginOrRegister;
