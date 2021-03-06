const loginReducer = (state = ({
    isLogin:  sessionStorage.getItem('login'),
    username: sessionStorage.getItem('userName'),
    token: sessionStorage.getItem('token')
}), action) => {
    switch (action.type) {
        case 'IS_LOGIN':
            return state = ({
                ...state,
                isLogin: !state.isLogin
            });
        case 'SET_USERNAME':
            return state = ({
                ...state,
                username: action.payload,
            });
        case 'SET_TOKEN':
            return state = ({
                ...state,
                token: action.payload,
            });
        default:
            return state;
    }
};

export default loginReducer;