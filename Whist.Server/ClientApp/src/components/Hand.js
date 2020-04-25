import React from "react";

function Card(props) {
    function clickCard() {
        // TODO(jorgen.fogh): Play the card!
    }
    return (<div className={"card " + props.name} onClick={clickCard}></div>);
}

export function Hand(props) {
    let cards = [];
    for (let i = 0; i < props.cards.length; i++)
        cards.push(<Card name={props.cards[i]}></Card>);
    return (<div className="hand">
        { cards }
        </div>);
}