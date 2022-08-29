import React, { useState, useEffect } from "react";
import "./index.scss";
import {
  faMobile,
  faMoneyBill,
  faShippingFast,
} from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import AnimatedLetters from "../../AnimatedLetters";
import { ScrollTrigger } from "gsap/ScrollTrigger";
import gsap from "gsap";
gsap.registerPlugin(ScrollTrigger);

const WhyUs = () => {
  const [letterClass, setLetterClass] = useState("text-animate");

  useEffect(() => {
    let timeoutId = setTimeout(() => {
      setLetterClass("text-animate-hover");
    }, 4000);

    gsap.fromTo(
      ".card",
      {
        autoAlpha: 0,
        y: -200,
      },
      {
        duration: 1.2,
        autoAlpha: 1,
        y: 0,
        x: 0,
        scrollTrigger: {
          trigger: ".card",
          toggleActions: "play none none reverse",
        },
      }
    );

    return () => {
      clearTimeout(timeoutId);
    };
  }, []);
  return (
    <div className="whyus">
      <div className="over-layout"></div>
      <h1 className=".anim-letters">
        <AnimatedLetters
          letterClass={letterClass}
          strArray={"Why Us".split("")}
          idx={10}
        />
      </h1>
      <div className="cards">
        <div className="card">
          <div className="face face1">
            <div className="content">
              <FontAwesomeIcon
                icon={faMoneyBill}
                width="100px"
                height="100px"
              />
              <h3>Price</h3>
            </div>
          </div>
          <div className="face face2">
            <div className="content">
              <p>
                There are many variations of passages of Lorem Ipsum available,
                but the majority have suffered alteration in some form, by
                injected humour, or randomised words which don't look even
                slightly believable. If you are going to use a passage of Lorem
                Ipsum, you need to be sure there isn't anything embarrassing
                hidden in the middle of text. All the Lorem Ipsum generators on
                the Internet tend to repeat predefined chunks as necessary,
                making this the first true generator on the Internet. It uses a
                dictionary of over 200 Latin words, combined with a handful of
                model sentence structures, to generate Lorem Ipsum which looks
                reasonable. The generated Lorem Ipsum is therefore always free
                from repetition, injected humour, or non-characteristic words
                etc.
              </p>
            </div>
          </div>
        </div>
        <div className="card">
          <div className="face face1">
            <div className="content">
              <FontAwesomeIcon icon={faMobile} />
              <h3>Mobile</h3>
            </div>
          </div>
          <div className="face face2">
            <div className="content">
              <p>
                Contrary to popular belief, Lorem Ipsum is not simply random
                text. It has roots in a piece of classical Latin literature from
                45 BC, making it over 2000 years old. Richard McClintock, a
                Latin professor at Hampden-Sydney College in Virginia, looked up
                one of the more obscure Latin words, consectetur, from a Lorem
                Ipsum passage, and going through the cites of the word in
                classical literature, discovered the undoubtable source. Lorem
                Ipsum comes from sections 1.10.32 and 1.10.33 of "de Finibus
                Bonorum et Malorum" (The Extremes of Good and Evil) by Cicero,
                written in 45 BC. This book is a treatise on the theory of
                ethics, very popular during the Renaissance. The first line of
                Lorem Ipsum, "Lorem ipsum dolor sit amet..", comes from a line
                in section 1.10.32.
              </p>
            </div>
          </div>
        </div>
        <div className="card">
          <div className="face face1">
            <div className="content">
              <FontAwesomeIcon icon={faShippingFast} />
              <h3>Fast Shipping</h3>
            </div>
          </div>
          <div className="face face2">
            <div className="content">
              <p>
                It is a long established fact that a reader will be distracted
                by the readable content of a page when looking at its layout.
                The point of using Lorem Ipsum is that it has a more-or-less
                normal distribution of letters, as opposed to using 'Content
                here, content here', making it look like readable English. Many
                desktop publishing packages and web page editors now use Lorem
                Ipsum as their default model text, and a search for 'lorem
                ipsum' will uncover many web sites still in their infancy.
                Various versions have evolved over the years, sometimes by
                accident, sometimes on purpose (injected humour and the like).
              </p>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default WhyUs;
