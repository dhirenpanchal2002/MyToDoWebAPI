import React from 'react';
import Login from './Login';
import '@testing-library/jest-dom';
import userEvent from '@testing-library/user-event';
import { render, screen } from '@testing-library/react';

describe('Components-Unit-Tests', () => {

    //1. Email label text check test
    test('UserLogin-Email Label text check', () => {
        render(<Login />);
        const linkElemnt = screen.getByText('Email', { exact: false });
        expect(linkElemnt).toBeInTheDocument();
    });

    //2. Password label text check test
    test('UserLogin-Password Label text check', () => {
        render(<Login />);
        const linkElemnt = screen.getByText('Password', { exact: false });
        expect(linkElemnt).toBeInTheDocument();
    });


    //3. Error label should not be there
    test('UserLogin-Error Label should not be there', () => {
        render(<Login />);
        const linkElemnt = screen.queryByText('Please', { exact: false });
        expect(linkElemnt).toBeNull();
    });

    //4. Error label should be there after click
    test('UserLogin-Error should raise after click', () => {
        render(<Login />);

        const loginButtonElement = screen.getByRole('button');

        userEvent.click(loginButtonElement);

        const linkElemnt = screen.queryByText('Please', { exact: false });
        expect(linkElemnt).toBeInTheDocument();
    });

    //4. Error label should be there after click
    test('UserLogin-Error should raise for password minimum 4 char', () => {
        render(<Login />);

        const emailInputElement = screen.getByLabelText('Email');
        const passwordInputElement = screen.getByLabelText('Password');

        userEvent.type(emailInputElement, 'test@test.com');
        userEvent.type(passwordInputElement, '123');

        const loginButtonElement = screen.getByRole('button');

        userEvent.click(loginButtonElement);

        const linkElemnt = screen.queryByText('4', { exact: false });
        expect(linkElemnt).toBeInTheDocument();
    });

    //5. Error label should be there after click
    //test('UserLogin-Error should display error message returned from server',async () => {

    //    //Arrange - Mock
    //    window.fetch = jest.fn();
    //    window.fetch.mockResolvedValueOnce({
    //        Response: async () => ({ data:"", isSuccess: "false", message: "Error returned from server"  }),
    //    })

    //    render(<Login />);

        
    //    const emailInputElement = screen.getByLabelText('Email');
    //    const passwordInputElement = screen.getByLabelText('Password');

    //    userEvent.type(emailInputElement, 'test@test.com');
    //    userEvent.type(passwordInputElement, '123456');

    //    const loginButtonElement = screen.getByRole('button');

    //    //Act
    //    userEvent.click(loginButtonElement);

    //    //Assert
    //    const linkElemnt = await screen.findByText('not', { exact: false });
    //    expect(linkElemnt).toBeInTheDocument();
    //});
});

