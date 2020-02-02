import React, { useState, useEffect } from "react";
import axios from "axios";
import { withRouter } from "react-router-dom";
//Styling
import { Modal, Button, Row, Col, Tabs, Tab, Container } from "react-bootstrap";
//Components
import { toast } from "react-toastify";
//redux
import { useSelector, useDispatch } from "react-redux";
//actions
import insurance from "../../../Redux/Action/InsuranceAction";
//Services
import http from "../../../Services/HttpService";
//Helpers
//Containers
import GeneralTab from "../Tabs/GeneralTab";
// import DocumentExoneratedTab from "../Tabs/DocumentExonerated";

const ClientModal = props => {
  toast.configure();
  // let axiosCancelSource = axios.CancelToken.source();

  const dispatch = useDispatch();

  // const clientMaintenance = useSelector(state => state.ClientMaintenance);

  const CloseModalAction = () => {
    props.onHide();
    dispatch(insurance.clearData());
  };

  // const validData = () => {
  //   if (
  //     clientMaintenance.CLIENT_TYPE_DESCRIPTION !== null &&
  //     clientMaintenance.CLIENT_TYPE_DESCRIPTION !== "null" &&
  //     clientMaintenance.SPECIAL_TAX !== null &&
  //     clientMaintenance.SPECIAL_TAX !== "" &&
  //     clientMaintenance.RETENTION_TAX !== null &&
  //     clientMaintenance.RETENTION_TAX !== "" &&
  //     clientMaintenance.EXONERATE_TAX !== null &&
  //     clientMaintenance.EXONERATE_TAX !== ""
  //   ) {
  //     dispatch(clientMaintenanceAction.isValid(true));
  //     return true;
  //   } else {
  //     dispatch(clientMaintenanceAction.isValid(false));
  //     return false;
  //   }
  // };

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
                  {/* <DocumentExoneratedTab></DocumentExoneratedTab> */}
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
          // onClick={updateClientLegalEntity}
          // disabled={sessionStorage.getItem("userData_PrimaryRole") === "Auditor" ? true : false}
        >
          Save
        </Button>
      </Modal.Footer>
    </Modal>
  );
};

export default withRouter(ClientModal);
