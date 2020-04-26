import React from "react";
import Card from "./Card.js"

function clickCard(cardName)
{
    if (this.state.selected === cardName)
        this.setState({ selected: null });
    else
        this.setState({ selected: cardName });
}

export default function AcePicker(props) {
    return (<div className="ace-picker">
        {["C1", "D1", "S1", "H1"].map(cardName => <Card key={ cardName } name= { cardName } clickCard={ () => props.onChoice(cardName) } />)}
        </div>);
}