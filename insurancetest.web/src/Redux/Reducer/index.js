import {combineReducers} from 'redux';
//Reducers
import loginReducer from '../Reducer/LoginReducer';
import insuranceReducer from        '../Reducer/InsuranceReducer';

const allReducers = combineReducers({
    login: loginReducer,
    insurance: insuranceReducer
});

export default allReducers;
