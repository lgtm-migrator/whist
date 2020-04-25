import React from "react";
import Card from "./Card.js";

function clickCard(cardName)
{
}

export default function Cat(props) {
    let cards = [];
    for (let i = 0; i < props.cards.length; i++)
        cards.push(<Card key={props.cards[i]} name={props.cards[i]} clickCard={clickCard}></Card>);
    return (<div className="cat">
        { cards }
        </div>);
}