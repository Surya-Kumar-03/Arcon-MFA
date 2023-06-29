import React from "react";
import { Routes, Route, Navigate } from "react-router-dom";
import SignIn from "./Login/login";

function App() {
  return (
    <Routes>
      <Route path="/">
        <Route index element={<SignIn />} />
        <Route path="/home" element={<div>Hello from Home!</div>} />
        <Route path="/mfa" element={<div>MFA Triggered!</div>} />
        <Route path="*" element={<Navigate to="/" />} />
      </Route>
    </Routes>
  );
}

export default App;
