import React, { useState, useEffect } from 'react';
import { Button, Form, Row, Col, Table, ProgressBar, InputGroup, FormControl } from 'react-bootstrap';
import { toast } from 'react-toastify';
import { withRouter } from 'react-router-dom';
//Styling
//Services 
import http from "../../../Services/HttpService";
//Helpers
//redux
import { useSelector, useDispatch } from 'react-redux';
//actions
import insurance from '../../../Redux/Action/InsuranceAction';
import InsuranceAction from '../../../Redux/Action/InsuranceAction';

const InsuranceType = (props) => {

    toast.configure()

    const dispatch = useDispatch();

    const insurance = useSelector(state => state.insurance)
    const loginData = useSelector(state => state.login)

    const [stateInsuranceTypes, setStateInsuranceTypes] = useState({
        InsuranceTypes: [],
        selected: null,
        isValid: null
    })

    const getAllInsuranceTypes = (prop) => {

        http.get(
            http.url + 'InsuranceType/getAllInsuranceType', http.setJWT(loginData.token))
            .then(
                result => {
                    setStateInsuranceTypes({
                        ...stateInsuranceTypes,
                        InsuranceTypes: result.data
                    });
                })
            .catch(function (error) {
                console.log(error)
            });
    }

    const onClickInsuranceType = (event) => {

        setStateInsuranceTypes({
            ...stateInsuranceTypes,
            selected: event.target.value,
            isValid: event.target.value !== null && event.target.value !== "null" ? true : false
        });

    };

    const createNewInsuranceType = () => {

        if (stateInsuranceTypes.isValid === true) {

            const insuranceSelected = stateInsuranceTypes.InsuranceTypes.filter(x => x.id === parseInt(stateInsuranceTypes.selected));

            let list = insurance.InsuranceTypes;

            let exist = list.filter(x => x.id === parseInt(stateInsuranceTypes.selected))

            if (exist.length === 0) {
                list.push(insuranceSelected[0]);
            } else {
                toast.error("El tipo de cubrimiento, ya se encuentra seleccionado");
            }

            dispatch(InsuranceAction.setInsuranceType(list));

        } else {
            setStateInsuranceTypes({
                ...stateInsuranceTypes,
                isValid: stateInsuranceTypes.selected !== null && stateInsuranceTypes.selected !== "null" ? true : false
            });
        }

    }

    useEffect(() => {
        getAllInsuranceTypes();
    }, []);

    const deleteInsuranceType = (insuranceId) => {

        let list = insurance.InsuranceTypes;

        list.splice(insuranceId, 1);

        dispatch(InsuranceAction.setInsuranceType(list));

    };

    return (
        <Row>
            <Col>
                <Row>
                    <Col sm={12}>
                        <fieldset>
                            <legend>Nuevo tipo de cubrimiento</legend>
                            <Row>
                                <Col sm={4}>
                                    <Form.Group>
                                        <Form.Label>Tipos</Form.Label>
                                        <Form.Control
                                            // isInvalid={stateCurrency.isValid === false ? true : false}
                                            as="select"
                                            onChange={onClickInsuranceType}
                                            id="select"
                                        // disabled={sessionStorage.getItem("userData_PrimaryRole") === "Auditor" ? true : false}
                                        >
                                            <option key="null" value="null">Seleccione un tipo</option>
                                            {stateInsuranceTypes.InsuranceTypes.map((InsuranceTypes, i) => {
                                                return (<option
                                                    key={i}
                                                    value={InsuranceTypes.id}>{InsuranceTypes.name}
                                                </option>)

                                            })}
                                        </Form.Control>
                                        <Form.Control.Feedback type="invalid">
                                            You must select a currency.
                                        </Form.Control.Feedback>
                                    </Form.Group>
                                </Col>
                                <Col sm={4} className="align-self-center">
                                    <Button
                                        // className='btn-ey-classic-1 btn-ey-yellow'
                                        onClick={createNewInsuranceType}
                                    // disabled={sessionStorage.getItem("userData_PrimaryRole") === "Auditor" ? true : false}
                                    // disabled={props.match.params.ViewMode === "V" ? true : false}
                                    >
                                        Agregar
                                    </Button>
                                </Col>
                            </Row>
                        </fieldset>
                    </Col>
                    <Col sm={12}>
                        <Table>
                            <thead>
                                <tr>
                                    <th> Tipo de cubrimiento </th>
                                    <th> Actions </th>
                                </tr>
                            </thead>
                            <tbody>
                                {insurance.InsuranceTypes.map((insurance, i) => {
                                    return (
                                        <tr key={i}>
                                            <td>{insurance.name}</td>
                                            <td>
                                                <Button value={" - "}
                                                    variant={"outline-danger"}
                                                    onClick={() => deleteInsuranceType(i)}
                                                >
                                                    Eliminar
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

export default withRouter(InsuranceType);