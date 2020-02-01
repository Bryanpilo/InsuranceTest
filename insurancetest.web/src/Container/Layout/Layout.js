import React, { useState, useEffect } from "react";
import { withRouter } from 'react-router-dom';
// import "@babel/polyfill";
//Services
//Components
import { Header, Footer } from '../../Component'
//hoc
import Aux from '../../Hoc/ContentWork';
//Styling
import './Layout.css';



const Layout = (props) => {

  return (
    <Aux>
      <Header />
        <main>
          {props.children}
        </main>
      <Footer />
    </Aux>
  )
}


export default withRouter(Layout)
