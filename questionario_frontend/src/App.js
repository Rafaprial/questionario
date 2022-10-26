import logo from './logo.svg';
import './App.css';
import Questionary from './Components/Questionary';

import { Switch ,BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import { useEffect, useState } from 'react';
import Login from './Components/Login';
import ButtonAppBar from './Components/ButtonAppBar';


function App() {
  return (
  <div>
    <ButtonAppBar/>
  <Router>
      <Routes>
        <Route exact path='/questions' element={<Questionary/>} />
        <Route exact path='/' element={<Login />} />
      </Routes>
   </Router>
   </div>
  );
}


export default App;
