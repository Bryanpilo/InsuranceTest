import {combineReducers} from 'redux';
//Reducers
import loginReducer from '../Reducer/LoginReducer';
// import dashBoardReducer from '../../../../../../../Desktop/Bryan Espinoza/CBP WorkStation/cbp-webapp/cbp.WebApp/src/Reducers/DashBoardReducer';
// import billingRequestChange from '../../../../../../../Desktop/Bryan Espinoza/CBP WorkStation/cbp-webapp/cbp.WebApp/src/Reducers/BillingRequestChangeReducer';
// import openAnulationModal from '../../../../../../../Desktop/Bryan Espinoza/CBP WorkStation/cbp-webapp/cbp.WebApp/src/Reducers/OpenAnulationModal';
// import LegalEntityMaintenanceReducer from '../../../../../../../Desktop/Bryan Espinoza/CBP WorkStation/cbp-webapp/cbp.WebApp/src/Reducers/LegalEntityMaintenanceReducer';

const allReducers = combineReducers({
    login: loginReducer
    // dashBoardLoadings: dashBoardReducer,
    // billingRequestChange: billingRequestChange,
    // openAnulationModal: openAnulationModal,
    // LegalEntityMaintenance: LegalEntityMaintenanceReducer
});

export default allReducers;
