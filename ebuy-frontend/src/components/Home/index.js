import React, { useState, useEffect } from "react";
import AnimatedLetters from "../AnimatedLetters";
import { Canvas, useLoader, useFrame } from "@react-three/fiber";
import { faBoxOpen, faX } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import Book from "./Book";
import "./index.scss";
import WhyUs from "./WhyUs/index.js";

const Home = () => {
  const [letterClass, setLetterClass] = useState("text-animate");
  const [showVideo, setShowVideo] = useState(true);
  useEffect(() => {
    let timeoutId = setTimeout(() => {
      setLetterClass("text-animate-hover");
    }, 5100);

    return () => {
      clearTimeout(timeoutId);
    };
  }, []);
  return (
    <div className="home">
      <div className="opening">
        <div className="over-layout"></div>
        <section>
          <h1>
            <AnimatedLetters
              letterClass={letterClass}
              strArray={"Register,".split("")}
              idx={10}
            />
          </h1>
          <h2>
            <AnimatedLetters
              letterClass={letterClass}
              strArray={"And start reading everywhere.".split("")}
              idx={19}
            />
          </h2>
        </section>
        {/* <figure className={` ${showVideo ? "video" : "hide-video"} `}>
          <div className="sketchfab-embed-wrapper">
            <iframe
              title="Read more books"
              frameBorder="0"
              mozallowfullscreen="true"
              webkitallowfullscreen="true"
              allow="autoplay; fullscreen; xr-spatial-tracking"
              src="https://sketchfab.com/models/f55ba7a1eba34c68a799659eedbf4eeb/embed"
            ></iframe>
          </div>
          <FontAwesomeIcon
            icon={showVideo ? faX : faBoxOpen}
            onClick={() => setShowVideo((prevState) => !prevState)}
          />
        </figure> */}
      </div>
      <WhyUs />
    </div>
  );
};

export default Home;
