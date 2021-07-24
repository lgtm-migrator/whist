import React, { useState, useEffect } from "react";
import { Route } from "react-router";
import { Layout } from "./components/Layout";
import { Home } from "./components/Home";
import { Lobby } from "./components/Lobby";
import { Game } from "./components/Game";
import { connect } from "./network";
import { useHistory } from "react-router-dom";

import "./custom.css"

export default function App(props) {
    const [connection, setConnection] = useState(null);
    const [listOfTables, setListOfTables] = useState([]);
    const [players, setPlayerNames] = useState([]);
    const history = useHistory();

    useEffect(() => {
        const newConnection = connect({
            updateListOfTables: setListOfTables,
            updatePlayersAtTable: setPlayerNames,
            receiveDealtCards: (cards) => { alert(cards); }
        });
        setConnection(newConnection);
    }, []);

    return (
      <Layout>
        <Route exact path="/">
            <Home
                listOfTables={listOfTables}
                selectTable={(table) => {
                    connection.send("SelectTable", table);
                    history.push(`/lobby/${table}`);
                }}
                saveTableName={(key, text) =>
                    connection.send("SaveTableName", key, text)
                } /></Route>
        <Route path="/lobby">
            <Lobby
                playerNames={players}
                savePlayerName={(key, text) => connection.send("SavePlayerName", key, text)}/></Route>
        <Route path="/game"><Game /></Route>
      </Layout>
    );
}
