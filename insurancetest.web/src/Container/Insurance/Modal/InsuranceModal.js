import React, { useState, useEffect } from "react";
import { withRouter } from "react-router-dom";
//Styling
import { Modal, Button, Row, Col, Tabs, Tab, Container } from "react-bootstrap";
//Components
import { toast } from "react-toastify";
//redux
import { useSelector, useDispatch } from "react-redux";
//actions
import insuranceAction from "../../../Redux/Action/InsuranceAction";
//Services
import http from "../../../Services/HttpService";
//Helpers
//Containers
import GeneralTab from "../Tabs/GeneralTab";
import InsuranceType from "../Tabs/InsuranceType";

const ClientModal = props => {
  toast.configure();

  const dispatch = useDispatch();

  const insurance = useSelector(state => state.insurance);
  const loginData = useSelector(state => state.login);

  const CloseModalAction = () => {
    props.onHide();
    dispatch(insuranceAction.clearData());
  };

  const createNewInsurance = () => {

    const queryObj = {
      Id: parseInt(insurance.Id),
      Name: insurance.Name,
      Description: insurance.Description,
      Coverage: parseFloat(insurance.Coverage),
      CoverageMonths: parseInt(insurance.CoverageMonths),
      InitDate: insurance.InitDate,
      Price: parseFloat(insurance.Price),
      RiskId: parseInt(insurance.RiskId),
      ClientId: parseInt(insurance.ClientId),
      insuranceTypeDTOs: insurance.InsuranceTypes
    };

    console.log("entra aca")
    http.post(
      http.url + 'Insurance/CreateInsurance', queryObj, http.setJWT(loginData.token)
      // {
      //   headers: {
      //     'Authorization': `Bearer ${loginData.token}`,
      //   }
      // }
    )
      .then(
        result => {
          toast.success("La poliza se guardo correctamente");
            CloseModalAction();
        })
      .catch(function (error) {
        console.log(error)
      });
    // if (
    //   clientMaintenance.CLIENT_TYPE_DESCRIPTION !== null &&
    //   clientMaintenance.CLIENT_TYPE_DESCRIPTION !== "null" &&
    //   clientMaintenance.SPECIAL_TAX !== null &&
    //   clientMaintenance.SPECIAL_TAX !== "" &&
    //   clientMaintenance.RETENTION_TAX !== null &&
    //   clientMaintenance.RETENTION_TAX !== "" &&
    //   clientMaintenance.EXONERATE_TAX !== null &&
    //   clientMaintenance.EXONERATE_TAX !== ""
    // ) {
    // dispatch(clientMaintenanceAction.isValid(true));
    // return true;
    // } else {
    //   dispatch(clientMaintenanceAction.isValid(false));
    //   return false;
    // }
  };

  const udateInsurance = () => {
    // dispatch(insuranceAction.setClientId(atob(props.match.params.ClientId)));
    // http.post(
    //   http.url + 'Insurance/CreateInsurance', insurance, http.setJWT(loginData.token)
    //   // {
    //   //   headers: {
    //   //     'Authorization': `Bearer ${loginData.token}`,
    //   //   }
    //   // }
    //   )
    //   .then(
    //     result => {
    //       alert("sirvio")
    //     })
    //   .catch(function (error) {
    //     console.log(error)
    //   });
    // if (
    //   clientMaintenance.CLIENT_TYPE_DESCRIPTION !== null &&
    //   clientMaintenance.CLIENT_TYPE_DESCRIPTION !== "null" &&
    //   clientMaintenance.SPECIAL_TAX !== null &&
    //   clientMaintenance.SPECIAL_TAX !== "" &&
    //   clientMaintenance.RETENTION_TAX !== null &&
    //   clientMaintenance.RETENTION_TAX !== "" &&
    //   clientMaintenance.EXONERATE_TAX !== null &&
    //   clientMaintenance.EXONERATE_TAX !== ""
    // ) {
    // dispatch(clientMaintenanceAction.isValid(true));
    // return true;
    // } else {
    //   dispatch(clientMaintenanceAction.isValid(false));
    //   return false;
    // }
  };

  // const updateClientLegalEntity = () => {
  //   if (validData()) {
  //     http
  //       .put(http.url + "clientlegalEntity", clientMaintenance, {
  //         headers: {
  //           withCredentials: true
  //         }
  //       })
  //       .then(result => {
  //         if (result.status === 200) {
  //           toast.success("The client was updated correctly!", {position: toast.POSITION.TOP_CENTER});
  //           CloseModalAction();
  //         }
  //       });
  //   } else {
  //     toast.error("Please fill in all the required fields.", {position: toast.POSITION.TOP_CENTER});
  //   }
  // };

  return (
    <Modal
      {...props}
      size="xl"
      dialogClassName="modal-70w"
      aria-labelledby="example-custom-modal-styling-title"
      onHide={CloseModalAction}
    // aria-labelledby="example-modal-sizes-title-lg"
    // onExit={CloseModalAction}
    >
      <Modal.Header closeButton>
        <Modal.Title id="example-modal-sizes-title-lg">
          Seguros
        </Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <Container>
          <Row>
            <Col sm={12}>
              <Tabs defaultActiveKey="General" id="uncontrolled-tab-example">
                <Tab eventKey="General" title="General">
                  <GeneralTab></GeneralTab>
                </Tab>
                <Tab
                  eventKey="InsuranceTypes"
                  title="Tipo de seguros"
                >
                  <InsuranceType></InsuranceType>
                </Tab>
              </Tabs>
            </Col>
          </Row>
        </Container>
      </Modal.Body>
      <Modal.Footer>
        <Button
          onClick={CloseModalAction}
        >
          Cancel
        </Button>
        <Button
          onClick={insurance.Id === 0 ? createNewInsurance : udateInsurance}
        // disabled={sessionStorage.getItem("userData_PrimaryRole") === "Auditor" ? true : false}
        >
          Save
        </Button>
      </Modal.Footer>
    </Modal>
  );
};

export default withRouter(ClientModal);
