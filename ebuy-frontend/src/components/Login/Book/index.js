import React, { useEffect, useRef } from "react";
import { Canvas, useLoader, useFrame } from "@react-three/fiber";
import { OrbitControls } from "@react-three/drei";
import { useTexture } from "@react-three/drei/core";
import BookCover from "../../../assets/images/Login/Side.png";
import BookBack from "../../../assets/images/Login/BookBack.svg";
import Welcome from "../../../assets/images/Login/Frame 4.svg";
import BookPageBG from "../../../assets/images/Login/BookPageBG.png";

import gsap from "gsap";
const Book = (props) => {
  const leftRef = useRef();
  const rightRef = useRef();
  const bookRef = useRef();
  const centerRef = useRef();
  const leftTextures = useTexture([
    BookBack,
    BookPageBG,
    BookBack,
    BookCover,
    BookCover,
    BookCover,
  ]);
  const rightTextures = useTexture([
    Welcome,
    BookBack,
    BookBack,
    BookCover,
    BookCover,
    BookCover,
  ]);
  useEffect(() => {
    if (!!bookRef.current) {
      console.log(bookRef.current);

      gsap.to(bookRef.current.rotation, { z: 3.1, duration: 1 });
      gsap.to(bookRef.current.rotation, { x: 89.4, duration: 1 });
      gsap.to(leftRef.current.rotation, { z: 1.5, duration: 1, delay: 1 });
      gsap.to(leftRef.current.position, { x: 1, duration: 1, delay: 1 });
      gsap.to(rightRef.current.rotation, { z: -1.5, duration: 1, delay: 1 });
      gsap.to(rightRef.current.position, { x: -1, duration: 1, delay: 1 });
      // gsap.to(centerRef.current, { visible: true, duration: 0, delay: 1 });
      // gsap.to(centerRef.current.scale, { y: 1.2, duration: 1, delay: 1 });
      gsap.to(bookRef.current.scale, { y: 0, duration: 1.5, delay: 3 });
      gsap.to(bookRef.current.scale, { x: 0, duration: 1.5, delay: 3 });
      gsap.to(bookRef.current.scale, { z: 0, duration: 1.5, delay: 3 });
    }
  }, [bookRef.current]);

  return (
    <>
      <group ref={bookRef} rotation={[90, 0, 0]} style={{ zIndex: "100" }}>
        <mesh position={[0.125, 0, 0]} ref={leftRef} castShadow>
          <boxBufferGeometry attach="geometry" args={[0.25, 2, 3]} />
          {leftTextures.map((texture, idx) => (
            <meshBasicMaterial
              key={texture.id}
              attach={`material-${idx}`}
              map={texture}
            />
          ))}
        </mesh>
        <mesh position={[-0.125, 0, 0]} ref={rightRef} castShadow>
          <boxBufferGeometry attach="geometry" args={[0.25, 2, 3]} />
          {rightTextures.map((texture, idx) => (
            <meshBasicMaterial
              key={texture.id}
              attach={`material-${idx}`}
              map={texture}
            />
          ))}
        </mesh>
      </group>
    </>
  );
};

export default Book;
