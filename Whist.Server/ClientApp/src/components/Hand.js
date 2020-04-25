import React from "react";

export function Hand(props) {
    let cards = [];
    for (let i = 0; i < props.cards.length; i++)
        cards.push(<div className={"card " + props.cards[i]}></div>);
    return (<div className="hand">
        { cards }
        </div>);
}