import React, { useEffect } from 'react';
//hoc
import Aux from '../../Hoc/ContentWork';
//Styling
// import '../../Assets/css/site.css'
import './Home.css'

const homePage = (props) => {
;

  var hour = new Date().getHours();
  const greeting = (hour < 12 ? "Buenos días, " : hour < 18 ? "Buenas tardes, " : "Buenas noches, ");

  return (
    <Aux>
      <h1>home</h1>
    </Aux>
  );

}

export default homePage;
