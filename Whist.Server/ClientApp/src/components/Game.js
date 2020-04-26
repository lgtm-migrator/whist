import React from "react";
import Hand from "./Hand.js";
import Cat from "./Cat.js";
import AcePicker from "./AcePicker.js";
import "./Game.css";

export function Game(props) {
    return (<div className="game-background">
        <AcePicker onChoice={ace => alert(ace)} />
        </div>);
}