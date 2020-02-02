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
// import clientAction from "../../../Actions/ClientMaintenanceAction";
//Helpers

const GeneralTab = props => {
  toast.configure();

  const dispatch = useDispatch();

  const insurance = useSelector(state => state.insurance);

  //#region set methods

  // const specialTax = event => {
  //   dispatch(clientAction.SpecialTax(event.target.value));
  // };

  // const HasPurchaseOrder = event => {
  //   dispatch(
  //     clientAction.HasPurchaseOrder(!clientMaintenance.HAS_PURCHASE_ORDER)
  //   );
  // };

  // const TaxRetention = event => {
  //   dispatch(clientAction.TaxRetention(event.target.value));
  // };

  // const IsExempt = event => {
  //   dispatch(clientAction.IsExempt(!clientMaintenance.IS_EXEMPT));
  // };


  //#endregion

  // //#region country typeahead

  // const [stateClientType, setStateClientType] = useState({
  //   clientType: []
  // });

  // const getSelectedClientType = event => {
  //   dispatch(clientAction.ClientType(event.target.value));
  // };

  // const GetDataClientType = props => {
  //   const queryObj = {
  //     statusId: "A"
  //   };

  //   http
  //     .get(http.url + "ClientType?" + http.toQuery(queryObj), {
  //       withCredentials: true
  //     })
  //     .then(result => {
  //       setStateClientType({
  //         clientType: result.data
  //       });
  //     });
  // };

  // useEffect(() => {
  //   GetDataClientType();
  // }, []);

  // //#endregion

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
                // onChange={specialTax}
              />
              <Form.Control.Feedback type="invalid">
                Please enter a special tax percentage.
              </Form.Control.Feedback>
            </Form.Group>
          </Col>
          <Col>
            <Form.Group>
              <Form.Label>Descripción</Form.Label>
              <Form.Control
                type="Text"
                placeholder={"Descripción"}
                value={insurance.Description}
                // onChange={specialTax}
              />
              <Form.Control.Feedback type="invalid">
                Please enter a special tax percentage.
              </Form.Control.Feedback>
            </Form.Group>
          </Col>
        </Row>
        <Row>
        <Col>
            <Form.Group>
              <Form.Label>Covertura</Form.Label>
              <Form.Control
                type="Text"
                placeholder={"Covertura"}
                value={insurance.Coverage}
                // onChange={specialTax}
              />
              <Form.Control.Feedback type="invalid">
                Please enter a special tax percentage.
              </Form.Control.Feedback>
            </Form.Group>
          </Col>
          <Col>
            <Form.Group>
              <Form.Label>Meses de covertura</Form.Label>
              <Form.Control
                type="Text"
                placeholder={"Meses de covertura"}
                value={insurance.CoverageMonths}
                // onChange={specialTax}
              />
              <Form.Control.Feedback type="invalid">
                Please enter a special tax percentage.
              </Form.Control.Feedback>
            </Form.Group>
          </Col>
        </Row>
        <Row>
        <Col>
            <Form.Group>
              <Form.Label>Fecha de inicio</Form.Label>
              <Form.Control
                type="Text"
                placeholder={"Fecha de inicio"}
                value={insurance.InitDate}
                // onChange={specialTax}
              />
              <Form.Control.Feedback type="invalid">
                Please enter a special tax percentage.
              </Form.Control.Feedback>
            </Form.Group>
          </Col>
          <Col>
            <Form.Group>
              <Form.Label>Precio</Form.Label>
              <Form.Control
                type="Text"
                placeholder={"Precio"}
                value={insurance.Price}
                // onChange={specialTax}
              />
              <Form.Control.Feedback type="invalid">
                Please enter a special tax percentage.
              </Form.Control.Feedback>
            </Form.Group>
          </Col>
        </Row>
        <Row>
        <Col>
            <Form.Group>
              <Form.Label>Riesgo</Form.Label>
              <Form.Control
                type="Text"
                placeholder={"Riesgo"}
                value={insurance.RiskId}
                // onChange={specialTax}
              />
              <Form.Control.Feedback type="invalid">
                Please enter a special tax percentage.
              </Form.Control.Feedback>
            </Form.Group>
          </Col>
          <Col>
            <Form.Group>
              <Form.Label>Boton</Form.Label>
              <Form.Control.Feedback type="invalid">
                Please enter a special tax percentage.
              </Form.Control.Feedback>
            </Form.Group>
          </Col>
        </Row>
      </Col>
    </Row>
  );
};

export default withRouter(GeneralTab);
