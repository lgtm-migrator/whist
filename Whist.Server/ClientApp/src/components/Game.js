import React from "react";
import Hand from "./Hand.js";
import Cat from "./Cat.js";
import "./Game.css";

export function Game(props) {
    return (<div className="game-background">
        <Cat cards={["C2", "S5", "HQ"]} />
        <Hand cards={["C1", "D3", "SQ"]} />
        </div>);
}