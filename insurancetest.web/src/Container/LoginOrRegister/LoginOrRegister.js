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
        <Col sm={10}>
          <Image src="https://source.unsplash.com/random" className="imgLoginOrRegister" />
        </Col>
        <Col sm={2}>
          <Tabs defaultActiveKey="profile" id="uncontrolled-tab-example">
            <Tab eventKey="home" title="Home">
              <h1>ino</h1>
            </Tab>
            <Tab eventKey="profile" title="Profile">
              <h1>ino</h1>
            </Tab>
          </Tabs>
        </Col>
      </Row>
    </div>
  );

}

export default LoginOrRegister;
