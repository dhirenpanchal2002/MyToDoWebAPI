import React from 'react';

import ReactDOM from 'react-dom';
import { BrowserRouter } from 'react-router-dom';
import { NavMenu }  from './NavMenu';
import '@testing-library/jest-dom';
import { render, screen } from '@testing-library/react';
import { Layout } from './Layout';

describe('Components-Unit-Tests', () => {

    //1. Login menu item check test
   /* test('NavMenu-Login menu item check test', () => {
        //render(<Layout />);
        const div = document.createElement('div');
        ReactDOM.render(
            <BrowserRouter>
                <NavMenu />
            </BrowserRouter>, div);

        ReactDOM.unmountComponentAtNode(div);

        const linkElemnt = screen.queryByRole('Navbar', { hidden: true });
       // expect(linkElemnt).toBeNull(); -- To be revise - it has to be not null
    });
    */

    test('NavMenu- Renders without crashing', async () => {
        const div = document.createElement('div');
        ReactDOM.render(
            <BrowserRouter>
                <NavMenu />
            </BrowserRouter>, div);
        await new Promise(resolve => setTimeout(resolve, 1000))
    });
});

