import React, { useContext,useEffect } from 'react';
import AuthContext from './Storage-Context/auth-context';


const LogOut = (props) => {
    const ctx = useContext(AuthContext);

    useEffect(() => {

        ctx.OnLogout();

    }, [ctx]);  


    return (<div>{"Successfully Logged out..!"}</div>);
}

export default LogOut;