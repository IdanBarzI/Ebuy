import React, { useState, useEffect, useRef } from "react";
import { Canvas, useLoader, useFrame } from "@react-three/fiber";
import Book from "./Book";
import gsap from "gsap";

import Form from "./Form";
import "./index.scss";

const Login = () => {
  const canvasRef = useRef();
  return (
    <div className="login-page">
      <Form />
      <Canvas ref={canvasRef} className="login-canvas" style={{ zIndex: "1" }}>
        <Book />
      </Canvas>
    </div>
  );
};

export default Login;
