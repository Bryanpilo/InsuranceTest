import React, { useState, useEffect } from 'react';
import { Button, Row, Col, Table } from 'react-bootstrap';
import http from "../../Services/HttpService";
import 'react-toastify/dist/ReactToastify.css';
import InsuranceModal from './Modal/InsuranceModal'
//redux
import { useSelector, useDispatch } from "react-redux";
//actions
// import LoginAction from "../../Redux/Action/LoginAction";
import InsuranceAction from "../../Redux/Action/InsuranceAction";
//hoc
import Aux from '../../Hoc/ContentWork';
//Styling
// import '../../Assets/css/site.css'
import './Insurance.css'

const Insurance = (props) => {

  const dispatch = useDispatch();

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
  const getAllInsuranceById = (idInsurance, idClient) => {

    console.log(idInsurance + " - " + idClient)

    const queryObj = {
      id: idInsurance,
      clientId: idClient
    };

    http.post(
      http.url + 'Insurance/getInsurangeBYIds', queryObj,
      {
        headers: {
          'Authorization': `Bearer ${loginData.token}`,
        }
      })
      .then(
        result => {
          dispatch(InsuranceAction.setId(result.data.id));
          dispatch(InsuranceAction.setName(result.data.name));
          dispatch(InsuranceAction.setDescription(result.data.description));
          dispatch(InsuranceAction.setCoverage(result.data.coverage));
          dispatch(InsuranceAction.setCoverageMonths(result.data.coverageMonths));
          dispatch(InsuranceAction.setInitDate(result.data.initDate));
          dispatch(InsuranceAction.setPrice(result.data.price));
          dispatch(InsuranceAction.setRiskId(result.data.riskId));

          setStateModal({
            modalShow: true
          });
        })
      .catch(function (error) {
        console.log(error)
      });
  }

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
          setStateInsurance({
            Insurance: result.data
          });
        })
      .catch(function (error) {
        console.log(error)
      });
  }

  const openNewInsuranceModal = () => {
    setStateModal({
      modalShow: true
    });
  }

  const deleteInsurance = (idInsurance) => {
    console.log(idInsurance)
    const queryObj = {
      id: idInsurance
    };

    console.log(http.toQuery(queryObj))

    http.delete(
      http.url + 'Insurance?'+http.toQuery(queryObj),
      {
        headers: {
          'Authorization': `Bearer ${loginData.token}`,
        }
      })
      .then(
        result => {
          getAllInsurance();
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
            onClick={() => openNewInsuranceModal()}
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
                  <th> Nombre </th>
                  <th> Descripción </th>
                  <th> Convertura (%) </th>
                  <th> Meses de convertura </th>
                  <th> Fecha de inicio </th>
                  <th> Precio </th>
                  <th> Acciones </th>
                </tr>
              </thead>
              <tbody>
                {stateInsurance.Insurance.map((Insurance, i) => {
                  return (
                    <tr key={Insurance.id}>
                      <td>{Insurance.name}</td>
                      <td>{Insurance.description}</td>
                      <td>{Insurance.coverage}</td>
                      <td>{Insurance.coverageMonths}</td>
                      <td>{Insurance.initDate}</td>
                      <td>{Insurance.price}</td>
                      <td>
                        <Button value={" - "}
                          variant={"outline-success"}
                          onClick={() => getAllInsuranceById(Insurance.id, Insurance.clientId)}
                        >
                          Editar
                        </Button>
                        <Button value={" - "}
                          variant={"outline-danger"}
                          onClick={() => deleteInsurance(Insurance.id)}
                        >
                          Cancelar
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
