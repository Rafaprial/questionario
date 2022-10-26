import logo from './logo.svg';
import './App.css';
import Login from './Login';

import { BrowserRouter, Route, Routes } from 'react-router-dom';
import { useEffect, useState } from 'react';

function App() {

  const [isAuthenticated, setIsAuthenticated] = useState(false);
  function handleLogin(logged){
    sessionStorage.setItem('token', JSON.stringify(logged));
    console.log("from parent " + logged);
  }
  useEffect(()=>{

  },[])

  return (
    <Login parenthandleLogin={handleLogin}/>
  );
}


export default App;
