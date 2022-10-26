import logo from './logo.svg';
import './App.css';
import Questionary from './Components/Questionary';

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
    <div className="App">
      <Questionary></Questionary>
    </div>
  );
}


export default App;
