import React, { Component } from 'react';
import UserLogin from './Login';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>       
        <UserLogin />
      </div>
    );
  }
}
