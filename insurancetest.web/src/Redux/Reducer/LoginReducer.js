const loginReducer = (state = ({
    isLogin:  sessionStorage.getItem('login'),
    username: null,
    token: "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIxIiwidW5pcXVlX25hbWUiOiJhZG1pbiIsIm5iZiI6MTU4MDU5NDc0NSwiZXhwIjoxNTgwNjgxMTQ1LCJpYXQiOjE1ODA1OTQ3NDV9.sx5nfRTqTm1AT-CYMDnlF6c4Vplcfg0bUestED_63s31663ipPhe4c8MzfDJOcJiBr3tV0d8qy9JHVtsTxX-Lg"
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