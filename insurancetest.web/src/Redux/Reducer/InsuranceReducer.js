const loginReducer = (state = ({
    Id: null,
    Name: null,
    Description: null,
    Coverage: null,
    CoverageMonths: null,
    InitDate: null,
    Price: null,
    RiskId: null
}), action) => {
    switch (action.type) {
        case 'SET_ID':
            return state = ({
                ...state,
                Id: action.payload,
            });
        case 'SET_NAME':
            return state = ({
                ...state,
                Name: action.payload,
            });
        case 'SET_DESCRIPTION':
            return state = ({
                ...state,
                Description: action.payload,
            });
        case 'SET_COVERAGE':
            return state = ({
                ...state,
                Coverage: action.payload,
            });
        case 'SET_COVERAGE_MONTHS':
            return state = ({
                ...state,
                CoverageMonths: action.payload,
            });
        case 'SET_INIT_DATE':
            return state = ({
                ...state,
                InitDate: action.payload,
            });
        case 'SET_PRICE':
            return state = ({
                ...state,
                Price: action.payload,
            });
        case 'SET_RISK_ID':
            return state = ({
                ...state,
                RiskId: action.payload,
            });
        case 'CLEAR_DATA':
            return state = ({
                Id: null,
                Name: null,
                Description: null,
                Coverage: null,
                CoverageMonths: null,
                InitDate: null,
                Price: null,
                RiskId: null
            });
        default:
            return state;
    }
};

export default loginReducer;