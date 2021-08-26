import React, {useEffect} from 'react';
import UserLogin from './Login';
import { useContext } from 'react';
import AuthContext from './Storage-Context/auth-context';

const Home = (props) => {

  const displayName = Home.name;
    const ctx = useContext(AuthContext);

    console.log(ctx.isUserLoggedin + '  in home comp--- ' + typeof (ctx.isUserLoggedin));


    return (
        <div>
            {ctx.isUserLoggedin && "User Successfully Logged in"}
            {!ctx.isUserLoggedin && <UserLogin />}
        </div>);
    
  
}

export default Home;
