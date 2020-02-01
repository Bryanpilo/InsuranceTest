import React, { useState, useEffect } from 'react';
import { Button, Row, Col, Table } from 'react-bootstrap';
import http from "../../Services/HttpService";
import 'react-toastify/dist/ReactToastify.css';
//redux
import { useSelector, useDispatch } from "react-redux";
//actions
import LoginAction from "../../Redux/Action/LoginAction";
//hoc
import Aux from '../../Hoc/ContentWork';
//Styling
// import '../../Assets/css/site.css'
import './Home.css'

const Home = (props) => {

  const loginData = useSelector(state => state.login)

  const [stateClients, setStateClient] = useState({
    Clients: []
  })

  useEffect(() => {
    getAllClient();
  }, []);


  const getAllClient = (props) => {

    http.get(
      http.url + 'Client/getAllClient',
      {
        headers: {
          'Authorization': `Bearer ${loginData.token}`,
        }
      })
      .then(
        result => {
          setStateClient({
            Clients: result.data
          });
        })
      .catch(function (error) {
        console.log(error)
      });
  }

  const getInsurances = (prop) =>{
    props.history.replace("/Insurance");
  }

  var hour = new Date().getHours();
  const greeting = (hour < 12 ? "Buenos días " : hour < 18 ? "Buenas tardes " : "Buenas noches ");

  return (
    <Aux>
      <Row>
        <Col>
          <h1>{greeting}</h1>
        </Col>
      </Row>
      <Row>
        <Col sm={12}>
          {stateClients.Clients.length > 0 ?
            <Table>
              <thead>
                <tr>
                  <th> Nombre Completo </th>
                  <th> Fecha de Inicio </th>
                  <th> Salario </th>
                  <th> Puesto </th>
                  <th> Acciones </th>
                </tr>
              </thead>
              <tbody>
                {stateClients.Clients.map((client, i) => {
                  return (
                    <tr key={client.id}>
                      <td>{client.fullName}</td>
                      <td>{client.initDate}</td>
                      <td>{client.salary}</td>
                      <td>{client.charge}</td>
                      <td>
                        <Button value={" - "}
                          variant={"outline-success"}
                          onClick={() => getInsurances()}
                        >
                          Poliza
                      </Button>
                      </td>
                    </tr>
                  )
                })}

              </tbody>
            </Table>
            :
            <h1>Porfavor espere</h1>
          }
        </Col>
      </Row>
    </Aux>
  );

}

export default Home;
