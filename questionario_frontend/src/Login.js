import { Avatar, Box, Button, Container, createTheme, CssBaseline, Grid, Link, TextField, ThemeProvider, Typography } from "@mui/material";
import axios from "axios";
import "./Login.css"
import { useEffect, useState } from "react";

function Login(){
    const [posts, setPosts] = useState(null);
     function handleSubmit(event){
      event.preventDefault()

        let emailRec = event.target.email.value;
        let passRec = event.target.password.value
        const user = {email: emailRec,pass: passRec}
        // const user = {email: "asdf", pass: "1234"}
        // debugger
        axios.post("https://localhost:7264/login",user).then((e)=>setPosts(e));
        // console.log(posts)
        // axios.get("https://localhost:7264/api/user").then((e)=>setPosts(e));
        // console.log(posts)
    }
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
            <Button
              type="submit"
              fullWidth
              variant="contained"
              sx={{ mt: 3, mb: 2 }}
            >
              Sign In
            </Button>
            <Grid container>
              <Grid item xs>
                <Link href="#" variant="body2">
                  Forgot password?
                </Link>
              </Grid>
              <Grid item>
                <Link href="#" variant="body2">
                  {"Don't have an account? Sign Up"}
                </Link>
              </Grid>
            </Grid>
          </Box>
        </Box>
      </Container>
    </ThemeProvider>
    );
}

export default Login;