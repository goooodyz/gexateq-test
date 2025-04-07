import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import AppComponent from './Components/AppComponent/AppComponent.js';

const root = ReactDOM.createRoot(document.getElementById('root'));

root.render(
  <React.StrictMode>
    <AppComponent />
  </React.StrictMode>
);
