import React from 'react';

const AuthContext = React.createContext({

    isUserLoggedin: false,
    OnLogout: () => { },
    OnSuccessfulAuth: () => { }
});

export default AuthContext;