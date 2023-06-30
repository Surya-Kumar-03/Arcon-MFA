import * as React from "react";
import Avatar from "@mui/material/Avatar";
import Button from "@mui/material/Button";
import CssBaseline from "@mui/material/CssBaseline";
import TextField from "@mui/material/TextField";
import Box from "@mui/material/Box";
import LockOutlinedIcon from "@mui/icons-material/LockOutlined";
import Typography from "@mui/material/Typography";
import Container from "@mui/material/Container";
import { createTheme, ThemeProvider } from "@mui/material/styles";

//Back-End Imports
import api from "../api";

const defaultTheme = createTheme();

function getUserDetails() {
  // Gets System Related Details
  const userAgent = navigator.userAgent;
  const os = userAgent.match(/(Windows|Linux|Mac|Android|iOS)/i)[0];
  const browser = userAgent.match(/(Chrome|Firefox|Safari|Edge|Opera)/i)[0];
  const version = userAgent.match(/\d+\.\d+\.\d+/)[0];

  // Gets User Location Details (Requires Permission from User)
  if (navigator.geolocation) {
    return new Promise((resolve, reject) => {
      navigator.geolocation.getCurrentPosition(
        (position) => {
          const { latitude, longitude } = position.coords;
          resolve({ os, browser, version, latitude, longitude });
        },
        (error) => {
          console.error("Error getting user location:", error);
          resolve({ os, browser, version }); // Returns without location details
        }
      );
    });
  }

  return Promise.resolve({ os, browser, version });
}

export default function SignIn() {
  const [data, setData] = React.useState();
  const [userDetails, setUserDetails] = React.useState(null);

  React.useEffect(() => {
    getUserDetails()
      .then((details) => {
        setUserDetails(details);
      })
      .catch((error) => {
        console.error("Error getting user details:", error);
      });
  }, []);

  const handleSubmit = (event) => {
    event.preventDefault();
    const data = new FormData(event.currentTarget);
    console.log({
      username: data.get("username"),
      password: data.get("password"),
    });

    //Make Call to Back-End
    api
      .post("/", userDetails)
      .then((response) => {
        setData(response.data);
        console.log(response.data);
      })
      .catch((error) => {
        console.error(error);
      });
  };

  return (
    <ThemeProvider theme={defaultTheme}>
      <Container component="main">
        <CssBaseline />
        <Box
          sx={{
            marginTop: 8,
            display: "flex",
            flexDirection: "column",
            alignItems: "center",
          }}
        >
          <Avatar sx={{ m: 1, bgcolor: "secondary.main" }}>
            <LockOutlinedIcon />
          </Avatar>
          <Typography component="h1" variant="h5">
            Adaptive MFA
          </Typography>
          <Box
            component="form"
            onSubmit={handleSubmit}
            noValidate
            sx={{ mt: 1 }}
          >
            <TextField
              margin="normal"
              required
              fullWidth
              id="username"
              label="Username"
              name="username"
              autoComplete="off"
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
          </Box>
        </Box>
      </Container>
    </ThemeProvider>
  );
}
