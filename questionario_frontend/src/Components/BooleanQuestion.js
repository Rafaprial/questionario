import React, { useState, useEffect } from 'react';

import { Select, MenuItem } from '@mui/material'

function BooleanQuestion(props) {
    const userId = props.userId;
    const question = props.pregunta;
   
    const responses = question.respuestas.split(":");
    console.log(responses)

    const [Respuesta, setRespuesta] = useState('');

    const submitAnswer = async () => {

        const user = {
            userId: userId,
            questionId: question.id,
            tipo: question.tipo,
            contenido: Respuesta
          };
        console.log(user)

        const response = await fetch("https://localhost:7264/api/respuesta",{
            
            method: 'POST',
            body: JSON.stringify(user),
            headers:{
                'Content-Type':'application/json'
            }
        });
        if(response.ok){
            props.nextQuestion()
        }
        console.log(response);
        
    }

    return ( <>
    <h3>{question.question}</h3>
    
        <Select value={Respuesta} onChange={(e) => setRespuesta(e.target.value)}>
            {responses.map(element => {
              return  <MenuItem value={element}> {element}</MenuItem> 
            })}
        </Select>
    <button onClick={submitAnswer}>save and next</button>
    </> );
}

export default BooleanQuestion;