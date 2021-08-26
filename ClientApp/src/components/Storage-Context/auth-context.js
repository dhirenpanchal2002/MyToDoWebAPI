import React from 'react';

const AuthContext = React.createContext({

    isUserLoggedin: false,
    OnLogout: () => { }
});

export default AuthContext;