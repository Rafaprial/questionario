import React, { useState, useEffect } from 'react';
import './BooleanQuestion.css';
import { Select, MenuItem, FormControl, Button } from '@mui/material'
import { Box } from '@mui/system';

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
     <Box
          sx={{
            marginTop: 8,
            display: 'flex',
            flexDirection: 'column',
            alignItems: 'center',
          }}
        >
        <FormControl >
        <h3>{question.question}</h3>
        <Select value={Respuesta} onChange={(e) => setRespuesta(e.target.value)}>
            {responses.map(element => {
              return  <MenuItem key={element} value={element}> {element}</MenuItem> 
            })}
        </Select>
        </FormControl>

    <Button variant="contained" onClick={submitAnswer}>Next</Button>
    </Box>
    </> );
}

export default BooleanQuestion;