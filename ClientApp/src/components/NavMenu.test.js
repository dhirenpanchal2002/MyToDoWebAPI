import React from 'react';

import ReactDOM from 'react-dom';
import { BrowserRouter } from 'react-router-dom';
import { NavMenu }  from './NavMenu';
import '@testing-library/jest-dom';
import { render, screen } from '@testing-library/react';
import { Layout } from './Layout';

describe('Components-Unit-Tests', () => {

    //1. Login menu item check test
   //test('NavMenu-Login menu item check test', async () => {
   //    const div = document.createElement('div');
   //    ReactDOM.render(
   //        <BrowserRouter>
   //            <NavMenu />
   //        </BrowserRouter>, div);
   //    await new Promise(resolve => setTimeout(resolve, 1000))

   //    console.log(div.innerHTML);

   //    ReactDOM.unmountComponentAtNode(div);

   //     const linkElemnt = await screen.findByRole('nav', { hidden: true });
   //     expect(linkElemnt).toBeInTheDocument();
   // });
    

    test('NavMenu- Renders without crashing', async () => {
        const div = document.createElement('div');
        ReactDOM.render(
            <BrowserRouter>
                <NavMenu />
            </BrowserRouter>, div);
        await new Promise(resolve => setTimeout(resolve, 1000))
    });
});

