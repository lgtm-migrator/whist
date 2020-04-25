import React from "react";
import { Hand } from "./Hand.js";
import "./Game.css";

export function Game(props) {
    return (<div className="game-background">
        <div className="cat">
            <div className="card C2"></div>
            <div className="card S5"></div>
            <div className="card HQ"></div>
        </div>
        <Hand cards={["C1", "D3", "SQ"]} />
        </div>);
}