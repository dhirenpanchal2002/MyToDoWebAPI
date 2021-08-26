import { error } from 'jquery';
import React, { useState,useContext } from 'react';
import ReactDOM from 'react-dom';
import classes from './Login.module.css';
import Card from './UI/Card'
import { Button, Form, FormGroup, Label, Input, FormText, Alert, FormFeedback } from 'reactstrap';
import AuthContext from './Storage-Context/auth-context';

const UserLogin = (props) => {


    const [UserName, setUserName] = useState('');
    const [Password, setPassword] = useState('');
    const [errorData, setErrorData] = useState('');

    const ctx = useContext(AuthContext);

    const onUsernameChangeHandler = (event) => {
        //console.log(event.target.value);
        setUserName(event.target.value);
    };

    const onPasswordChangeHandler = (event) => {
        //console.log(event.target.value);
        setPassword(event.target.value);
    };

    const errorDataChangeHandler = (event) => {
        setErrorData(null);
    }

    const onLoginClickHander = (event) => {
        event.preventDefault();
        if (UserName.trim().length <= 0 || Password.trim().length <= 0) {
            setErrorData({ title: "invalid ", message: "Please enter both input values" })
            return;
        }

        if (UserName.trim().length < 4) {
            setErrorData({ title: "invalid ", message: "UserName must be minimum 4 character long" })
            return;
        }

        if (Password.trim().length < 4) {
            setErrorData({ title: "invalid ", message: "Password must be minimum 4 character long" })
            return;
        }

        setErrorData({ title: "valid ", message: "" })

        LoginUserData();
    };

    async function LoginUserData() {

        const formData = {
            "UserName": UserName,
            "Password": Password,
            "NewPassword" : ""};

        console.log(formData);

        const response = await fetch('Auth/Login', {
            method: 'POST',
            body: JSON.stringify(formData),
            headers: {
                'Content-Type' :'Application/Json'
            }
        })

        console.log(response);
        if (response.status != 200)
        {
            setErrorData({ title: response.status, message: response.statusText })
            return;
        }

        const data = await response.json();

        console.log(data);
        //this.setState({ todoList: data.data, loading: false });
        

        if (!data.isSuccess) {
            setErrorData({ title: response.status, message: data.message })
            localStorage.setItem("IS_LOGGEDIN", false);
            ctx.isUserLoggedin = false;
        }
        else {
            localStorage.setItem("LOGGEDIN_USERNAME", UserName);
            localStorage.setItem("LOGGEDIN_USERJWT", data.data);
            localStorage.setItem("IS_LOGGEDIN", true);
            ctx.isUserLoggedin = true;
        }
    };

    return (

        <Card id="LoginCard" className={classes.cardParent}>
            <Form>     
                {errorData.message && <Alert color="danger"> {errorData.message}</Alert>}

                <FormGroup className="position-relative">
                    <Label for="UserEmail">Email</Label>
                    <Input type="email" name="email" id="UserEmail" onChange={onUsernameChangeHandler} placeholder="Username" />
                </FormGroup>                
                <FormGroup className="position-relative">
                    <Label for="UserPassword">Password</Label>
                    <Input type="password" name="password" id="UserPassword" onChange={onPasswordChangeHandler} placeholder="Password" />
                  
                </FormGroup>
                <br />
                <Button color="primary" size="lg" block onClick={onLoginClickHander}>Login</Button>      
            </Form>
        </Card>
        
    );
};

export default UserLogin;