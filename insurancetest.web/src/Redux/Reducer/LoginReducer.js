const loginReducer = (state = ({
    isLogin: false
}), action) => {
    switch (action.type) {
        case 'IS_LOGIN':
            return state = ({
                ...state,
                isLogin: !state.isLogin
            });
        default:
            return state;
    }
};

export default loginReducer;