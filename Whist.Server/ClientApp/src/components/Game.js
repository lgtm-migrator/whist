import React from "react";
import AcePicker from "./AcePicker.js";
import "./Game.css";

export function Game(props) {
    return (<div className="game-background">
        <AcePicker onChoice={ace => alert(ace)} />
        </div>);
}