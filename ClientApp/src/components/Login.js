import { error } from 'jquery';
import React, { useState } from 'react';
import ReactDOM from 'react-dom';
import { Button, Form, FormGroup, Label, Input, FormText, Alert, FormFeedback } from 'reactstrap';

const UserLogin = (props) => {


    const [UserName, setUserName] = useState('');
    const [Password, setPassword] = useState('');
    const [errorData, setErrorData] = useState('');

    const onUsernameChangeHandler = (event) => {
        console.log(event.target.value);
        setUserName(event.target.value);
    };

    const onPasswordChangeHandler = (event) => {
        console.log(event.target.value);
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

        if (!UserName.includes('@')) {
            setErrorData({ title: "invalid ", message: "Invalid Email" })
            return;
        }

        if (Password.trim().length < 4) {
            setErrorData({ title: "invalid ", message: "Password must be minimum 4 character long" })
            return;
        }

        setErrorData({ title: "valid ", message: "" })
    };

    return (

        <div>
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
        </div>
        
    );
};

export default UserLogin;