import React from 'react';

const AuthContext = React.createContext({

    isUserLoggedin: false,
    UserCity: "",
    OnLogout: () => { },
    OnSuccessfulAuth: () => { }
});

export default AuthContext;