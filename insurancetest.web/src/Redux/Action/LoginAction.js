const isLogin = () => {
    return {
        type: 'IS_LOGIN'
    };
};

const setUsername = data => {
    return {
        type: "SET_USERNAME",
        payload: data
    };
};


const setToken = data => {
    return {
        type: "setToken",
        payload: data
    };
};


export default {
    isLogin: isLogin,
    setUsername: setUsername,
    setToken: setToken
}
