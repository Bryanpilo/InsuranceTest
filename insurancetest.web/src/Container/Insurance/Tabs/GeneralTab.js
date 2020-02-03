import React, { useState, useEffect } from "react";
import { Form, Row, Col, InputGroup, Button } from "react-bootstrap";
import { toast } from "react-toastify";
import { withRouter } from "react-router-dom";
//Styling
//Services
import http from "../../../Services/HttpService";
//redux
import { useSelector, useDispatch } from "react-redux";
//actions
import insuranceAction from "../../../Redux/Action/InsuranceAction";
//Helpers

const GeneralTab = props => {
  toast.configure();

  const dispatch = useDispatch();

  const insurance = useSelector(state => state.insurance);
  const loginData = useSelector(state => state.login);

  const [stateRisk, setStateRisk] = useState({
    Risks: []
  })

  const setName = event => {
    dispatch(insuranceAction.setName(event.target.value));
  };

  const setDescription = event => {
    dispatch(insuranceAction.setDescription(event.target.value));
  };

  const setCoverture = event => {
    dispatch(insuranceAction.setCoverage(event.target.value));
  };

  const setCoverageMonths = event => {
    dispatch(insuranceAction.setCoverageMonths(event.target.value));
  };

  const setDateInit = event => {
    dispatch(insuranceAction.setInitDate(event.target.value));
  };

  const setPrice = event => {
    dispatch(insuranceAction.setPrice(event.target.value));
  };

  const onClickRisk = event => {
    dispatch(insuranceAction.setRiskId(event.target.value));
  };

  const getAllRisks = (props) => {

    http.get(
      http.url + 'RiskType/getAllRiskType', http.setJWT(loginData.token))
      .then(
        result => {
          setStateRisk({
            Risks: result.data
          });
        })
      .catch(function (error) {
        console.log(error)
      });
  }

  useEffect(() => {
    getAllRisks();
    if (insurance.InitDate !== null)
      dispatch(insuranceAction.setInitDate(insurance.InitDate.split("T")[0]));
  }, []);


  return (
    <Row>
      <Col sm={12}>
        <Row>
          <Col>
            <Form.Group>
              <Form.Label>Nombre</Form.Label>
              <Form.Control
                type="Text"
                placeholder={"Nombre"}
                value={insurance.Name}
                onChange={setName}
              />
            </Form.Group>
          </Col>
          <Col>
            <Form.Group>
              <Form.Label>Descripción</Form.Label>
              <Form.Control
                type="Text"
                placeholder={"Descripción"}
                value={insurance.Description}
                onChange={setDescription}
              />
            </Form.Group>
          </Col>
        </Row>
        <Row>
          <Col>
            <Form.Group>
              <Form.Label>Cobertura</Form.Label>
              <Form.Control
                type="number"
                placeholder={"Cobertura"}
                value={insurance.Coverage}
                onChange={setCoverture}
              />
            </Form.Group>
          </Col>
          <Col>
            <Form.Group>
              <Form.Label>Meses de Cobertura</Form.Label>
              <Form.Control
                type="number"
                placeholder={"Meses de Cobertura"}
                value={insurance.CoverageMonths}
                onChange={setCoverageMonths}
              />
            </Form.Group>
          </Col>
        </Row>
        <Row>
          <Col>
            <Form.Group>
              <Form.Label>Fecha de inicio</Form.Label>
              <Form.Control
                type="date"
                placeholder={"Fecha de inicio"}
                value={insurance.InitDate}
                onChange={setDateInit}
              />
            </Form.Group>
          </Col>
          <Col>
            <Form.Group>
              <Form.Label>Precio</Form.Label>
              <Form.Control
                type="number"
                placeholder={"Precio"}
                value={insurance.Price}
                onChange={setPrice}
              />
            </Form.Group>
          </Col>
        </Row>
        <Row>
          <Col>
            <Form.Group>
              <Form.Label>Tipo de riesgo</Form.Label>
              <Form.Control
                as="select"
                onChange={onClickRisk}
                id="select"
              >
                <option key="null" value="null">Seleccione un tipo</option>
                {stateRisk.Risks.map((risk, i) => {
                  return (<option
                    selected={risk.id === insurance.RiskId ? true : false}
                    key={i}
                    value={risk.id}>{risk.risk}
                  </option>)

                })}
              </Form.Control>
            </Form.Group>
          </Col>
        </Row>
      </Col>
    </Row >
  );
};

export default withRouter(GeneralTab);
