import React from "react";
import Card from "./Card.js"

export default class Hand extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            selected: null
        };
    }

    clickCard(cardName)
    {
        if (this.state.selected === cardName)
            this.setState({ selected: null });
        else
            this.setState({ selected: cardName });
    }

    render() {
        const cardComponents = [];
        const cards = this.props.cards;
        for (let i = 0; i < cards.length; i++)
            cardComponents.push(<Card key={cards[i]} name={cards[i]} clickCard={(cardName) => this.clickCard(cardName)} selected={this.state.selected === cards[i]}></Card>);
        return (<div className="hand">
            { cardComponents }
            </div>);
    }
}