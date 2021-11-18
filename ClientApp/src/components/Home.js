import React from 'react';
import classes from './Home.module.css';
import profileIcon from '.././Images/account.svg';

const Home = (props) => {

  //const displayName = Home.name;
    //const ctx = useContext(AuthContext);

    //console.log(ctx.isUserLoggedin + '  in home comp--- ' + typeof (ctx.isUserLoggedin));

    const LoggedUserName = localStorage.getItem("LOGGEDIN_USERNAME", true);

    return (
        <div>
            <img src={profileIcon} className={classes.imgIcon} alt="View Profile" id="imgProfile" />
            <a href="/Profile" className={classes.stdHref}>{LoggedUserName}</a>
        </div>);
}

export default Home;
