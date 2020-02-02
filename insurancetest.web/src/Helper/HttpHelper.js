const isNotFound = (err) => err.response && err.response.status === 404;

const isUnautorized = (err) => err.response && err.response.status === 401;

const badCombination = (err) => err.response && err.response.status === 405;
// const isExpected = (err) => err.response && err.response.status >= 400 && err.response.status < 500;

const isServerError = (err) => err.response && err.response.status === 500;

const isUndefined = (err) => err.response && err.response.status === undefined;

export default { isNotFound, isUnautorized, isUndefined, isServerError, badCombination };