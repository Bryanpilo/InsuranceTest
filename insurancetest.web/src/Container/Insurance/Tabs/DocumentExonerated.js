import React, { useState, useEffect } from 'react';
import { Button, Form, Row, Col, Table, ProgressBar, InputGroup, FormControl, OverlayTrigger, Popover } from 'react-bootstrap';
import { Typeahead } from 'react-bootstrap-typeahead';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import axios from "axios";
import { toast } from 'react-toastify';
import { withRouter } from 'react-router-dom';
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
//Styling
import '../Client.css'
import "react-datepicker/dist/react-datepicker.css";
import { faPlus, faPencilAlt, faTrashAlt, faCopy } from '@fortawesome/free-solid-svg-icons'
//Services 
import http from "../../../Services/HttpService";
//Helpers
import parametersFormatHelper from "../../../Helper/ParametersFormatHelper";
//redux
import { useSelector, useDispatch } from 'react-redux';
//actions
import ClientMaintenanceAction from '../../../Actions/ClientMaintenanceAction';

const DocumentExonerated = (props) => {

    toast.configure()

    const dispatch = useDispatch();


    const clientMaintenance = useSelector(state => state.ClientMaintenance);

    const [stateNewDocument, setStateNewDocument] = useState({
        file: null,
        documentName: null,
        fileExtension: null,
        number: null,
        institutionName: null,
        exoneratedAmount: null,
        initDate: new Date(),
        endDate: new Date(),
        isValid: null
    });

    const setEndDate = (event) => {

        // if (event <= new Date()) {
        //     event = new Date();
        // };
        setStateNewDocument({
            ...stateNewDocument,
            endDate: event
            // endDate: new Date(event).getTime() / 1000,
        });

    }

    const setInitDate = (event) => {

        // if (event <= new Date()) {
        //     event = new Date();
        // };

        setStateNewDocument({
            ...stateNewDocument,
            initDate: event,
            endDate: event
        });

        // setStateNewDocument({
        //     ...stateNewDocument,
        //     endDate: event
        // });

    }

    const setExoneratedAmount = (event) => {

        setStateNewDocument({
            ...stateNewDocument,
            exoneratedAmount: event.target.value
        });

    }

    const setInstitutionName = (event) => {

        setStateNewDocument({
            ...stateNewDocument,
            institutionName: event.target.value
        });

    }

    const setNumber = (event) => {

        setStateNewDocument({
            ...stateNewDocument,
            number: event.target.value
        });

    }

    const onAttChhange = (event) => {

        // if (event.target.files[0].size <= 1000024) {
            var name = event.target.files[0].name;
            var file = event.target.files[0].type;

            parametersFormatHelper.getBase64(event.target.files[0],
                (fileConvert) => {
                    setStateNewDocument({
                        ...stateNewDocument,
                        documentName: name,
                        fileExtension: file,
                        file: fileConvert.split("base64,")[1]
                    });
                }
            );



        // } else {

        //     toast.error("The file you want to upload must be no larger than 1 megabyte.", {position: toast.POSITION.TOP_CENTER});
        // }

    }

    //#region add fiscal verificator 
    const [stateFiscalVerificator, setStateFiscalVerificator] = useState({
        fiscalVerificator: [],
        selected: null,
        isValid: null
    });

    const GetFiscals = () => {

        const queryObj = {
            role: "Fiscal",
            text: ""
        };

        http.get(
            http.url + 'Users?' + http.toQuery(queryObj),
            {
                withCredentials: true
            })
            .then(
                result => {

                    setStateFiscalVerificator({
                        ...stateFiscalVerificator,
                        fiscalVerificator: result.data
                    });

                });
    };

    const onClickFiscal = (event) => {

        setStateFiscalVerificator({
            ...stateFiscalVerificator,
            selected: event.target.value,
            isValid: event.target.value !== null && event.target.value !== "null" ? true : false
        });

    };

    useEffect(() => {
        GetFiscals();
    }, []);

    //#endregion

    //#region add new document 
    const [stateDocumentType, setStateDocumentType] = useState({
        documentType: [],
        selected: null,
        isValid: null
    });

    const GetDocumentType = () => {

        const queryObj = {
            status: "A"
        };

        http.get(
            http.url + 'ExoneratedDocumentType?' + http.toQuery(queryObj),
            {
                withCredentials: true
            })
            .then(
                result => {

                    setStateDocumentType({
                        ...stateDocumentType,
                        documentType: result.data
                    });

                });
    };

    const onClickDocument = (event) => {

        setStateDocumentType({
            ...stateDocumentType,
            selected: event.target.value,
            isValid: event.target.value !== null && event.target.value !== "null" ? true : false
        });

    };

    useEffect(() => {
        GetDocumentType();
    }, []);

    //#endregion

    //#region add new document in list document

    const createNewDocument = () => {

        if (stateDocumentType.isValid === true &&
            stateFiscalVerificator.isValid === true &&
            stateNewDocument.file !== "null" && stateNewDocument.file !== null && stateNewDocument.file !== undefined &&
            stateNewDocument.number !== "null" && stateNewDocument.number !== null &&
            stateNewDocument.institutionName !== "null" && stateNewDocument.institutionName !== null &&
            stateNewDocument.exoneratedAmount !== "null" && stateNewDocument.exoneratedAmount !== null &&
            stateNewDocument.initDate !== "null" && stateNewDocument.initDate !== null &&
            stateNewDocument.endDate !== "null" && stateNewDocument.endDate !== null) {

            let list = clientMaintenance.DocumentList;

            const documentType = stateDocumentType.documentType.filter(x => x.EDT_ID.toString() === stateDocumentType.selected.toString())

            list.push({
                ED_ID: 0,
                LEGAL_ENTITY_ID: clientMaintenance.LEGAL_ENTITY_ID,
                CLIENT_ID: clientMaintenance.CLIENT_ID,
                ATTACHED_DOCUMENT: stateNewDocument.file,
                DOCUMENT_NUMBER: stateNewDocument.number,
                INSTITUTION_NAME: stateNewDocument.institutionName,
                ASSIGNED_TO: stateFiscalVerificator.selected.trim().split("-")[0],
                ASSIGNED_TO_NAME: stateFiscalVerificator.selected.trim().split("-")[2],
                PERCENTAJE_EXONERATED: stateNewDocument.exoneratedAmount,
                EDT_ID: stateDocumentType.selected,
                EDT_ID_NAME: documentType[0].CODE + " - " + documentType[0].DESCRIPTION,
                START_DATE_INSERT: new Date(stateNewDocument.initDate).getTime() / 1000,
                START_DATE: stateNewDocument.initDate,
                END_DATE_INSERT: new Date(stateNewDocument.endDate).getTime() / 1000,
                END_DATE: stateNewDocument.endDate,
                STATUS_ID: "G",
                STATUS_DESCRIPTION: "Pending approval",
                STATUS_NOTES: "",
                DOCUMENT_NAME: stateNewDocument.documentName,
                FILE_EXTENSION: stateNewDocument.fileExtension
            });

            dispatch(ClientMaintenanceAction.updateDocumentList(list));

            setStateNewDocument({
                file: null,
                documentName: null,
                fileExtension: null,
                number: null,
                institutionName: null,
                exoneratedAmount: null,
                initDate: new Date(),
                endDate: new Date(),
                isValid: null
            });

        } else {
            setStateNewDocument({
                ...stateNewDocument,
                isValid: false
            });

            if (stateDocumentType.selected === null || stateDocumentType.selected === "null") {
                setStateDocumentType({
                    ...stateDocumentType,
                    isValid: false
                });
            }

            if (stateFiscalVerificator.selected === null || stateFiscalVerificator.selected === "null") {
                setStateFiscalVerificator({
                    ...stateFiscalVerificator,
                    isValid: false
                });
            }
        }

    }

    //#endregion

    //#region  delete currency
    const deleteDocument = (document) => {

        let list = clientMaintenance.DocumentList;

        list.splice(document, 1);

        dispatch(ClientMaintenanceAction.updateDocumentList(list));

    };
    //#endregion

    return (
        <Row>
            <Col>
                <Row>
                    <Col sm={12}>
                        <fieldset className="my-fieldset">
                            <legend className="my-legend long-text">New document</legend>
                            <Row>
                                <Col sm={4} className="align-self-center">
                                    <Form.Group>
                                        <Form.Label>Document type</Form.Label>
                                        <Form.Control
                                            isInvalid={stateDocumentType.isValid === false ? true : false}
                                            as="select"
                                            onChange={onClickDocument}
                                            id="select"
                                            disabled={sessionStorage.getItem("userData_PrimaryRole") === "Auditor" ? true : false}
                                        >
                                            <option key="null" value="null">Select a document</option>
                                            {stateDocumentType.documentType.map((document, i) => {
                                                return (<option key={i} value={document.EDT_ID}>{document.CODE + " - " + document.DESCRIPTION}</option>)

                                            })}
                                        </Form.Control>
                                        <Form.Control.Feedback type="invalid">
                                            Please select a document type.
                                        </Form.Control.Feedback>
                                    </Form.Group>
                                </Col>
                                <Col sm={4} className="align-self-center">
                                    <Form.Group>
                                        <Form.Label>Number</Form.Label>
                                        <Form.Control
                                            type="text"
                                            placeholder={"Document number"}
                                            isInvalid={stateNewDocument.isValid === false && (stateNewDocument.number === null || stateNewDocument.number === "")
                                                ? true : false}
                                            onChange={setNumber}
                                            maxlength="50"
                                            disabled={sessionStorage.getItem("userData_PrimaryRole") === "Auditor" ? true : false}
                                        />
                                        <Form.Control.Feedback type="invalid">
                                            Please insert a document number.
                                        </Form.Control.Feedback>
                                    </Form.Group>
                                </Col>
                                <Col sm={4} className="align-self-center">
                                    <Form.Group>
                                        <Form.Label>Company name</Form.Label>
                                        <Form.Control
                                            type="text"
                                            placeholder="Company name"
                                            isInvalid={stateNewDocument.isValid === false && (stateNewDocument.institutionName === null
                                                || stateNewDocument.institutionName === "null") ? true : false}
                                            onChange={setInstitutionName}
                                            disabled={sessionStorage.getItem("userData_PrimaryRole") === "Auditor" ? true : false}
                                        />
                                        <Form.Control.Feedback type="invalid">
                                            Please, insert the Company name.
                                        </Form.Control.Feedback>
                                    </Form.Group>
                                </Col>
                            </Row>

                            <Row>
                                <Col sm={4} className="align-self-center">
                                    <Form.Group>
                                        <Form.Label>Exonerated Percentage (%)</Form.Label>
                                        <Form.Control
                                            type="number"
                                            pattern='[0-9]{0,5}'
                                            placeholder={"Number"}
                                            isInvalid={stateNewDocument.isValid === false && (stateNewDocument.exoneratedAmount === null
                                                || stateNewDocument.exoneratedAmount === "" || parametersFormatHelper.isNormalInteger(stateNewDocument.exoneratedAmount) === false) ? true : false}
                                            onChange={setExoneratedAmount}
                                            maxlength="50"
                                            disabled={sessionStorage.getItem("userData_PrimaryRole") === "Auditor" ? true : false}
                                        />
                                        <Form.Control.Feedback type="invalid">
                                            Please enter a percentage of exemption.
                                        </Form.Control.Feedback>
                                    </Form.Group>
                                </Col>
                                <Col sm={4} className="align-self-center">
                                    <Form.Group controlId="formBasicEmail">
                                        <Form.Label>Date from:</Form.Label>
                                        <DatePicker
                                            className="form-control"
                                            selected={stateNewDocument.initDate}
                                            selectsStart
                                            startDate={stateNewDocument.initDate}
                                            endDate={stateNewDocument.endDate}
                                            onChange={setInitDate}
                                            disabled={sessionStorage.getItem("userData_PrimaryRole") === "Auditor" ? true : false}
                                        />
                                    </Form.Group>
                                </Col>
                                <Col sm={4} className="align-self-center">
                                    <Form.Group controlId="formBasicEmail">
                                        <Form.Label>Dates up to:</Form.Label>
                                        <DatePicker
                                            className="form-control"
                                            selected={stateNewDocument.endDate}
                                            selectsEnd
                                            startDate={stateNewDocument.initDate}
                                            endDate={stateNewDocument.endDate}
                                            onChange={setEndDate}
                                            minDate={stateNewDocument.initDate}
                                            disabled={sessionStorage.getItem("userData_PrimaryRole") === "Auditor" ? true : false}
                                        />
                                    </Form.Group>
                                </Col>
                            </Row>

                            <br></br>
                            <Row>

                                <Col sm={4} className="align-self-center">
                                    <Form.Label>Document</Form.Label>
                                    <InputGroup className="mb-3">
                                        <Form.Control
                                            value={stateNewDocument.file ? stateNewDocument.documentName : 'Select a file'}
                                            disabled
                                            isInvalid={(stateNewDocument.isValid === false && stateNewDocument.file !== null)
                                                && (stateNewDocument.file === null || stateNewDocument.file === "null" || stateNewDocument.file === undefined) ? true : false}
                                        />
                                        <InputGroup.Append>
                                            <Button as="label"
                                                className="attachment-ey-button">
                                                Attach
                                        <input type="file"
                                                    isInvalid={stateNewDocument.isValid === false && (stateNewDocument.file === null || stateNewDocument.file === "null" || stateNewDocument.file === undefined) ? true : false}
                                                    name="arc"
                                                    accept=".doc,.docx,.xls,.xlsx, .xlsm, .docm, .pdf, .txt, .zip"
                                                    onChange={onAttChhange}
                                                    hidden />
                                            </Button>
                                        </InputGroup.Append>
                                    </InputGroup>
                                    <Form.Group>
                                        <Form.Control
                                            type="hidden"
                                            isInvalid={stateNewDocument.isValid === false && (stateNewDocument.file === null || stateNewDocument.file === "null"
                                                || stateNewDocument.file === undefined) ? true : false}

                                        />
                                        <Form.Control.Feedback type="invalid">
                                            Please include an exemption document.
                                        </Form.Control.Feedback>
                                    </Form.Group>
                                </Col>
                                <Col sm={4} className="align-self-center">
                                    <Form.Group>
                                        <Form.Label>Verifying Fiscal</Form.Label>
                                        <Form.Control
                                            isInvalid={stateFiscalVerificator.isValid === false ? true : false}
                                            as="select"
                                            onChange={onClickFiscal}
                                            id="select"
                                            disabled={sessionStorage.getItem("userData_PrimaryRole") === "Auditor" ? true : false}
                                        >
                                            <option key="null" value="null">Select a fiscal</option>
                                            {stateFiscalVerificator.fiscalVerificator.map((fiscal, i) => {
                                                return (<option key={i} value={fiscal.USER_NT + "-" + fiscal.FunctionaryLngName}>{fiscal.FunctionaryLngName}</option>)

                                            })}
                                        </Form.Control>
                                        <Form.Control.Feedback type="invalid">
                                            Please select a verifying fiscal.
                                        </Form.Control.Feedback>
                                    </Form.Group>
                                </Col>
                                <Col sm={4} className="align-self-center">
                                    <Button
                                        className='btn-ey-classic-1 btn-ey-yellow'
                                        onClick={createNewDocument}
                                        disabled={sessionStorage.getItem("userData_PrimaryRole") === "Auditor" ? true : false}
                                    ><FontAwesomeIcon icon={faPlus} size="sm" /> Add
                                    </Button>
                                </Col>
                            </Row>
                            <br></br>
                        </fieldset>
                    </Col>
                    <Col sm={12} className="sizeTableModal">
                        <Table className="costModal">
                            <thead>
                                <tr>
                                    <th> Name </th>
                                    <th> Document number </th>
                                    <th> Institution </th>
                                    <th> Exonerated percentage </th>
                                    <th> Type </th>
                                    <th> Home </th>
                                    <th> Completion </th>
                                    <th> Assigned to </th>
                                    <th> State </th>
                                    <th> Actions </th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr className="progress-grid">
                                    <td colSpan="10">
                                        <ProgressBar now=""></ProgressBar>
                                    </td>
                                </tr>
                                {clientMaintenance.DocumentList.map((document, i) => {
                                    return (
                                        <tr key={i}>
                                            <td>
                                                <a
                                                    className="borderLine"
                                                    onClick={() => parametersFormatHelper.downloadDoc(document.ATTACHED_DOCUMENT, document.DOCUMENT_NAME, document.FILE_EXTENSION)}
                                                > {document.DOCUMENT_NAME} </a>
                                            </td>
                                            <td>{document.DOCUMENT_NUMBER}</td>
                                            <td>{document.INSTITUTION_NAME}</td>
                                            <td>{document.PERCENTAJE_EXONERATED}</td>
                                            <td>{document.EDT_ID_NAME}</td>
                                            <td>{parametersFormatHelper.formatDateToShortDate(document.START_DATE)}</td>
                                            <td>{parametersFormatHelper.formatDateToShortDate(document.END_DATE)}</td>
                                            <td>{document.ASSIGNED_TO_NAME}</td>
                                            <td> {document.STATUS_ID === "Q" ?
                                                <OverlayTrigger 
                                                    // trigger="click" 
                                                    placement="left"
                                                    delay={{ show: 250, hide: 3000 }}
                                                    overlay={
                                                        <Popover id="popover-basic" title="Razón">
                                                            {document.STATUS_NOTES}
                                                        </Popover>
                                                    }>
                                                    <a className="borderLine"> {document.STATUS_DESCRIPTION} </a>
                                                </OverlayTrigger> : document.STATUS_DESCRIPTION}
                                                {/* {document.STATUS_DESCRIPTION} */}
                                            </td>
                                            <td>
                                                <Button value={" - "}
                                                    variant={"outline-danger"}
                                                    onClick={() => deleteDocument(i)}
                                                    disabled={sessionStorage.getItem("userData_PrimaryRole") === "Auditor" ? true : false}
                                                >
                                                    <FontAwesomeIcon icon={faTrashAlt} size="sm" />
                                                </Button>
                                            </td>
                                        </tr>
                                    )
                                })}

                            </tbody>
                        </Table>
                    </Col>

                </Row>
            </Col>
        </Row>

    );
}

export default withRouter(DocumentExonerated);