import React from 'react';

const Home = (props) => {

  //const displayName = Home.name;
    //const ctx = useContext(AuthContext);

    //console.log(ctx.isUserLoggedin + '  in home comp--- ' + typeof (ctx.isUserLoggedin));

    const LoggedUserName = localStorage.getItem("LOGGEDIN_USERNAME", true);

    return (
        <div>
            {"Welcome " + LoggedUserName + "..!" }
        </div>);
    
  
}

export default Home;
