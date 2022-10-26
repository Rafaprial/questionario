import axios from 'axios';
import React, { useState, useEffect } from 'react';
import BooleanQuestion from './BooleanQuestion';


function Questionary(props) {
    const [Questions, setQuestions] = useState([])
    const [Current, setCurrent] = useState()
    
    const userLogged = 1;
   const [Loaded, setLoaded] = useState(false)
    

    useEffect(()=>{
        getQuestions();
    },[]);


    async function getQuestions(){
        const response = await axios.get("https://localhost:7264/api/question");
        console.log(response)
        response.data.map((dato) => Questions.push(dato));
        
        passQuestion();
        setLoaded(true);
    }

    function passQuestion(){
        setCurrent(Questions.pop());
    }
    
    return ( <>

        {   Loaded && 
            <BooleanQuestion pregunta={Current} userId={userLogged} nextQuestion={passQuestion}></BooleanQuestion>
        }
    </> );
}

export default Questionary;

