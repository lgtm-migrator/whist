import React from "react";
import { Hand } from "./Hand.js";
import "./Game.css";

export function Game(props) {
    return (<div className="game-background">
        <Hand cards={["C1", "D3", "SQ"]} />
        </div>);
}