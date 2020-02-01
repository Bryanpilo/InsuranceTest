import React, { useState, useEffect } from "react";
import { Form, Row, Col, InputGroup, Button } from "react-bootstrap";
import { toast } from "react-toastify";
import { withRouter } from "react-router-dom";
//Styling
import "../Client.css";
import "react-datepicker/dist/react-datepicker.css";
//Services
import http from "../../../Services/HttpService";
//redux
import { useSelector, useDispatch } from "react-redux";
//actions
import clientAction from "../../../Actions/ClientMaintenanceAction";
//Helpers
import parametersFormatHelper from "../../../Helper/ParametersFormatHelper";

const generalTab = props => {
  toast.configure();

  const dispatch = useDispatch();

  const clientMaintenance = useSelector(state => state.ClientMaintenance);

  //#region set methods

  const specialTax = event => {
    dispatch(clientAction.SpecialTax(event.target.value));
  };

  const HasPurchaseOrder = event => {
    dispatch(
      clientAction.HasPurchaseOrder(!clientMaintenance.HAS_PURCHASE_ORDER)
    );
  };

  const TaxRetention = event => {
    dispatch(clientAction.TaxRetention(event.target.value));
  };

  const IsExempt = event => {
    dispatch(clientAction.IsExempt(!clientMaintenance.IS_EXEMPT));
  };


  //#endregion

  // //#region country typeahead

  const [stateClientType, setStateClientType] = useState({
    clientType: []
  });

  const getSelectedClientType = event => {
    dispatch(clientAction.ClientType(event.target.value));
  };

  const GetDataClientType = props => {
    const queryObj = {
      statusId: "A"
    };

    http
      .get(http.url + "ClientType?" + http.toQuery(queryObj), {
        withCredentials: true
      })
      .then(result => {
        setStateClientType({
          clientType: result.data
        });
      });
  };

  useEffect(() => {
    GetDataClientType();
  }, []);

  // //#endregion

  return (
    <Row>
      <Col sm={12}>
        <Row>
          <Col>
            <Form.Group>
              <Form.Label>Percentage of special tax (%)</Form.Label>
              <Form.Control
                type="number"
                pattern="[0-9]{0,5}"
                placeholder={"Percentage of special tax"}
                isInvalid={
                  clientMaintenance.isValid === false &&
                    (clientMaintenance.SPECIAL_TAX === null ||
                      clientMaintenance.SPECIAL_TAX === "" ||
                      parametersFormatHelper.isNormalInteger(
                        clientMaintenance.SPECIAL_TAX
                      ) === false)
                    ? true
                    : false
                }
                value={clientMaintenance.SPECIAL_TAX}
                onChange={specialTax}
                maxlength="50"
                disabled={sessionStorage.getItem("userData_PrimaryRole") === "Auditor" ? true : false}
              />
              <Form.Control.Feedback type="invalid">
                Please enter a special tax percentage.
              </Form.Control.Feedback>
            </Form.Group>
          </Col>
          <Col>
            <Form.Group>
              <Form.Label>Customer type</Form.Label>
              <Form.Control
                isInvalid={
                  clientMaintenance.isValid === false &&
                    (clientMaintenance.CLIENT_TYPE_DESCRIPTION === null ||
                      clientMaintenance.CLIENT_TYPE_DESCRIPTION === "null")
                    ? true
                    : false
                }
                as="select"
                onChange={getSelectedClientType}
                id="select"
                disabled={sessionStorage.getItem("userData_PrimaryRole") === "Auditor" ? true : false}
              >
                <option key="null" value="null">
                  Select a customer
                </option>

                {stateClientType.clientType !== null ||
                  stateClientType.clientType !== "null"
                  ? stateClientType.clientType.map((clientType, i) => {
                    if (
                      clientMaintenance.CLIENT_TYPE_DESCRIPTION ===
                      clientType.CLIENT_TYPE_ID
                    ) {
                      return (
                        <option
                          selected
                          key={clientType.CLIENT_TYPE_ID}
                          value={clientType.CLIENT_TYPE_ID}
                        >
                          {clientType.DESCRIPTION}
                        </option>
                      );
                    } else {
                      return (
                        <option
                          key={clientType.CLIENT_TYPE_ID}
                          value={clientType.CLIENT_TYPE_ID}
                        >
                          {clientType.DESCRIPTION}
                        </option>
                      );
                    }
                  })
                  : null}
              </Form.Control>
              <Form.Control.Feedback type="invalid">
                Please select a type of customer
              </Form.Control.Feedback>
            </Form.Group>
          </Col>
        </Row>
        <Row>
          <Col>
            {/* <Form.Check
              type="checkbox"
              label="¿Tiene retención especial?"
              // onChange={HasRetention}
              // checked={clientMaintenance.HAS_RETENTION}
            /> */}
            <Form.Group>
              <Form.Label>Special retention percentage (%)</Form.Label>
              <Form.Control
                type="number"
                pattern="[0-9]{0,5}"
                placeholder={"Special retention percentage"}
                isInvalid={
                  clientMaintenance.isValid === false &&
                    (clientMaintenance.RETENTION_TAX === null ||
                      clientMaintenance.RETENTION_TAX === "" ||
                      parametersFormatHelper.isNormalInteger(
                        clientMaintenance.RETENTION_TAX
                      ) === false)
                    ? true
                    : false
                }
                value={clientMaintenance.RETENTION_TAX}
                onChange={TaxRetention}
                maxlength="50"
                disabled={sessionStorage.getItem("userData_PrimaryRole") === "Auditor" ? true : false}
              />
              <Form.Control.Feedback type="invalid">
                Please enter a special retention percentage.
              </Form.Control.Feedback>
            </Form.Group>
          </Col>
          <Col>
            <Form.Group>
              <Form.Check
                type="checkbox"
                label="Do you have a purchase order?"
                onChange={HasPurchaseOrder}
                checked={clientMaintenance.HAS_PURCHASE_ORDER}
                disabled={sessionStorage.getItem("userData_PrimaryRole") === "Auditor" ? true : false}
              />
            </Form.Group>
            <Form.Group>
              <Form.Check
                type="checkbox"
                label="Is he exempt?"
                onChange={IsExempt}
                checked={clientMaintenance.IS_EXEMPT}
                disabled={sessionStorage.getItem("userData_PrimaryRole") === "Auditor" ? true : false}
              />
            </Form.Group>
          </Col>
        </Row>
      </Col>
    </Row>
  );
};

export default withRouter(generalTab);
