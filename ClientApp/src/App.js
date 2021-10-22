import React, {  useEffect } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import Login from './components/Login';
import LogOut from './components/LogOut';
import  Home  from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import { useContext,useState } from 'react';
import './custom.css'
import AuthContext from './components/Storage-Context/auth-context';

const App = (props) => {
 // const displayName = App.name;

    const [isAuthenticated, setIsAuthenticated] = useState(false);
    const ctx = useContext(AuthContext);
    const isAlreadyAuthenticated = localStorage.getItem("IS_LOGGEDIN");

    useEffect(() => {
        
        if (isAlreadyAuthenticated != null)
            setIsAuthenticated(isAlreadyAuthenticated);

        
        ctx.isUserLoggedin = isAuthenticated;

        //console.log(`${isAuthenticated} ===in APP ===  ${ctx.isUserLoggedin}`);
    }, [isAuthenticated,ctx])

    const logoutHander = () => {
        localStorage.removeItem("IS_LOGGEDIN");
        localStorage.removeItem("LOGGEDIN_USERJWT");
        localStorage.removeItem("LOGGEDIN_USERNAME");
        setIsAuthenticated(false);        
        
    }

    const SuccessAuthenicateHandler = () => {
        setIsAuthenticated(true);
        localStorage.setItem("IS_LOGGEDIN", true);
        
       // console.log(`${isAuthenticated} === notified after authentication ===  ${true}`);
    }

   // console.log("App Render" + isAuthenticated);

    return (
        
        <AuthContext.Provider
            value={{
                isUserLoggedin: isAuthenticated,
                OnLogout: logoutHander,
                OnSuccessfulAuth: SuccessAuthenicateHandler
            }}>
            <Layout>
                {isAuthenticated && <Route exact path='/' component={Home} />}
                {!isAuthenticated && <Route exact path='/' component={Login} />}
                {isAuthenticated && <Route path='/About' component={Counter} />}
                {isAuthenticated && <Route path='/ToDo-Items' component={FetchData} />}
                {isAuthenticated && <Route path='/LogOut' component={LogOut} />}
            </Layout>
        </AuthContext.Provider>
    );
}

export default App;
