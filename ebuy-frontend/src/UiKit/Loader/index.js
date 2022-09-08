import React from "react";
import ReactDOM from "react-dom";
import Loader from "react-loaders";

import "./index.scss"

const Prompt = () => {

  return (
    <>
      {ReactDOM.createPortal(
          <div className="load">
<Loader type="packman"  />
 </div>,
        document.getElementById("loader-root")
      )}
    </>
  );
};

export default Prompt;