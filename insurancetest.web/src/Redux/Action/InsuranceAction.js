const setId = (data) => {
    return {
        type: 'SET_ID',
        payload: data
    };
};

const setName = (data) => {
    return {
        type: 'SET_NAME',
        payload: data
    };
};

const setDescription = (data) => {
    return {
        type: 'SET_DESCRIPTION',
        payload: data
    };
};

const setCoverage = (data) => {
    return {
        type: 'SET_COVERAGE',
        payload: data
    };
};

const setCoverageMonths = (data) => {
    return {
        type: 'SET_COVERAGE_MONTHS',
        payload: data
    };
};

const setInitDate = (data) => {
    return {
        type: 'SET_INIT_DATE',
        payload: data
    };
};

const setPrice = (data) => {
    return {
        type: 'SET_PRICE',
        payload: data
    };
};

const setRiskId = (data) => {
    return {
        type: 'SET_RISK_ID',
        payload: data
    };
};

const setClientId = (data) => {
    return {
        type: 'SET_CLIENT_ID',
        payload: data
    };
};

const setInsuranceType = (data) => {
    return {
        type: 'SET_INSURANCE_TYPES',
        payload: data
    };
};

const clearData = () => {
    return {
        type: 'CLEAR_DATA'
    };
};


export default {
    setId: setId,
    setName: setName,
    setDescription: setDescription,
    setCoverage: setCoverage,
    setCoverageMonths: setCoverageMonths,
    setInitDate: setInitDate,
    setPrice: setPrice,
    setRiskId: setRiskId,
    clearData: clearData,
    setInsuranceType: setInsuranceType,
    setClientId: setClientId
}
