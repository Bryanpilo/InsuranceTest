import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './Container/Main Page/App';
import * as serviceWorker from './serviceWorker';
//Imports
import { BrowserRouter} from 'react-router-dom';
import { createStore } from 'redux';
import { Provider } from 'react-redux';
//reducer
import allReducer from './Redux/Reducer';

const store = createStore(
    allReducer,
    window.__REDUX_DEVTOOLS_EXTENSION__ && window.__REDUX_DEVTOOLS_EXTENSION__()
);

const app = (
    <BrowserRouter>
            <Provider store={store}>
                <App />
            </Provider>
    </BrowserRouter>
);

ReactDOM.render(app, document.getElementById('root'));
serviceWorker.register();
