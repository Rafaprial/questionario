import { Avatar, Box, Button, Container, createTheme, CssBaseline, Grid, Link, TextField, ThemeProvider, Typography } from "@mui/material";
import axios from "axios";
import { useEffect, useState } from "react";
import { Router, useNavigate } from "react-router-dom";

function Login(){
    const [posts, setPosts] = useState(null);
    const [error, setError] = useState(false);
    const navigate = useNavigate();
    function handleSubmit(event){
      event.preventDefault()
      let emailRec = event.target.email.value;
      let passRec = event.target.password.value
      const user = {email: emailRec,pass: passRec}
      axios.post("https://localhost:7264/login",user).then((e)=>setPosts(e));
      if(posts){
        navigate("/questions");
      }else{
        setError(true);
      }
      
    }
    
    
    useEffect ((e)=>{
    },[posts])
    

    const theme = createTheme();
    

    return(
<ThemeProvider theme={theme}>
      <Container component="main" maxWidth="xs">
        <CssBaseline />
        <Box
          sx={{
            marginTop: 8,
            display: 'flex',
            flexDirection: 'column',
            alignItems: 'center',
          }}
        >
          <Avatar sx={{ m: 1, bgcolor: 'secondary.main' }}>

          </Avatar>
          <Typography component="h1" variant="h5">
            Sign in
          </Typography>
          <Box component="form" onSubmit={handleSubmit} noValidate sx={{ mt: 1 }}>
            <TextField
              margin="normal"
              required
              fullWidth
              id="email"
              label="Email Address"
              name="email"
              autoComplete="email"
              autoFocus
            />
            <TextField
              margin="normal"
              required
              fullWidth
              name="password"
              label="Password"
              type="password"
              id="password"
              autoComplete="current-password"
            />
            {error?<h3>Wrong mail or password</h3>:<h3></h3>}
            <Button
              type="submit"
              fullWidth
              variant="contained"
              sx={{ mt: 3, mb: 2 }}
            >
              Sign In
            </Button>

          </Box>
        </Box>
      </Container>
    </ThemeProvider>
    );
}

export default Login;