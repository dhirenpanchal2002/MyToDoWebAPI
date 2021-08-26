import React, { Component, useEffect } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import  Home  from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import { useContext,useState } from 'react';
import './custom.css'
import AuthContext from './components/Storage-Context/auth-context';

const App = (props) => {
  const displayName = App.name;

    const [isAuthenticated, setIsAuthenticated] = useState(false);

  
    const ctx = useContext(AuthContext);

    useEffect(() => {
        const isAuthenticated1 = localStorage.getItem("IS_LOGGEDIN");
        if (isAuthenticated1 != null)
            setIsAuthenticated(isAuthenticated1);

        
        ctx.isUserLoggedin = isAuthenticated;

        console.log(`${isAuthenticated} ===in APP ===  ${ctx.isUserLoggedin}`);
    }, [])

    const logoutHander = () => {
        localStorage.setItem("IS_LOGGEDIN",false);
    }
    return (
        <AuthContext.Provider
            value={{
                isUserLoggedin: false,
                OnLogout: logoutHander
            }}>
            <Layout>      
                <Route exact path='/' component={Home} />
                <Route path='/About' component={Counter} />
                <Route path='/ToDo-Items' component={FetchData} />
            </Layout>
        </AuthContext.Provider>
    );
}

export default App;
