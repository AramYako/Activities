import React from 'react';
import logo from './logo.svg';
import './App.css';
import { Header, Icon } from 'semantic-ui-react'

function App() {
  return (
    <div className="App">
          <Header as='h2'>
              <Icon name='plug' />
              <Header.Content>Uptime Guarantee</Header.Content>
          </Header>
    </div>
  );
}

export default App;
