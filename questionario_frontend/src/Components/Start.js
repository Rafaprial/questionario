import React from 'react'
import {useNavigate} from 'react-router-dom'


function Start(props) {
    var logged = false;
     
    const navigate  = useNavigate();
    return ( <>
        {!logged && <button onClick={() => navigate("/login")}>go to login</button>}
        {logged && <button onClick={() => navigate("/questionary")}>go to login</button>}
    </> );
}

export default Start;