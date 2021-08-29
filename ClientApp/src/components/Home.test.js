import React from 'react';
import Home from './Home';
import '@testing-library/jest-dom';
import { render, screen } from '@testing-library/react';


test('Home-Welcome text check', () => {
    render(<Home />);
    const linkElemnt = screen.getByText('Welcome', { exact: false });
    expect(linkElemnt).toBeInTheDocument();
});