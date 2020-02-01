import React, { useState, useEffect } from 'react';
import { Button, Row, Col, Table } from 'react-bootstrap';
import http from "../../Services/HttpService";
import 'react-toastify/dist/ReactToastify.css';
import InsuranceModal from './Modal/InsuranceModal'
//redux
import { useSelector, useDispatch } from "react-redux";
//actions
import LoginAction from "../../Redux/Action/LoginAction";
//hoc
import Aux from '../../Hoc/ContentWork';
//Styling
// import '../../Assets/css/site.css'
import './Insurance.css'

const Insurance = (props) => {

  const loginData = useSelector(state => state.login)

  const [stateRisk, setStateRisk] = useState({
    Risks: []
  })

  const [stateInsuranceTypes, setStateInsuranceTypes] = useState({
    InsuranceTypes: []
  })

  const [stateInsurance, setStateInsurance] = useState({
    Insurance: []
  })


  const [stateModal, setStateModal] = useState({
    modalShow: false
  });

  const modalClose = () =>
    setStateModal({
      modalShow: false
    });

  // const getAllRisks = (props) => {

  //   http.get(
  //     http.url + 'Client/getAllClient',
  //     {
  //       headers: {
  //         'Authorization': `Bearer ${loginData.token}`,
  //       }
  //     })
  //     .then(
  //       result => {
  //         setStateClient({
  //           Clients: result.data
  //         });
  //       })
  //     .catch(function (error) {
  //       console.log(error)
  //     });
  // }

  // const getAllInsuranceTypes = (props) => {

  //   http.get(
  //     http.url + 'Client/getAllClient',
  //     {
  //       headers: {
  //         'Authorization': `Bearer ${loginData.token}`,
  //       }
  //     })
  //     .then(
  //       result => {
  //         setStateClient({
  //           Clients: result.data
  //         });
  //       })
  //     .catch(function (error) {
  //       console.log(error)
  //     });
  // }

  const getAllInsurance = (props) => {

    const queryObj = {
      id: 1
    };

    http.post(
      http.url + 'Insurance', queryObj,
      {
        headers: {
          'Authorization': `Bearer ${loginData.token}`,
        }
      })
      .then(
        result => {
          console.log(result.data)
          setStateInsurance({
            Insurance: result.data
          });
        })
      .catch(function (error) {
        console.log(error)
      });
  }

  useEffect(() => {
    // getAllRisks();
    // getAllInsuranceTypes();
    getAllInsurance();
  }, []);

  return (
    <Aux>
      <InsuranceModal
        show={stateModal.modalShow}
        onHide={modalClose}
      // editm={stateModal.userEdit}
      // onExited={() => GetData(StateTableParameters.text)}
      />
      <Row>
        <Col>
          <h1>Polizas</h1>
          <Button value={" - "}
            variant={"outline-success"}
          // onClick={() => deleteDocument(i)}
          >
            Crear Poliza
          </Button>
        </Col>
      </Row>
      <Row>
        <Col sm={12}>
          {stateInsurance.Insurance.length > 0 ?
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
                {stateInsurance.Insurance.map((Insurance, i) => {
                  return (
                    <tr key={Insurance.id}>
                      <td>{Insurance.name}</td>
                      <td>{Insurance.initDate}</td>
                      <td>{Insurance.price}</td>
                      <td>{Insurance.coverage}</td>
                      <td>
                        <Button value={" - "}
                          variant={"outline-success"}
                        // onClick={() => deleteDocument(i)}
                        >
                          Seguros
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

export default Insurance;
