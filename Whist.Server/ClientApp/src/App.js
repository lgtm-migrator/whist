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
    const [tableNames, setTableNames] = useState([]);
    const [players, setPlayerNames] = useState([]);
    const history = useHistory();

    useEffect(() => {
        const newConnection = connect({
            updateListOfTables: setTableNames,
            updatePlayersAtTable: setPlayerNames,
            receiveDealtCards: (cards) => { alert(cards); }
        });
        setConnection(newConnection);
    }, []);

    return (
      <Layout>
        <Route exact path="/"><Home tableNames={tableNames} selectTable={(table) => {
            connection.send("SelectTable", table);
            history.push(`/lobby/${table}`);
        }} /></Route>
        <Route path="/lobby"><Lobby playerNames={players}/></Route>
        <Route path="/game"><Game /></Route>
      </Layout>
    );
}
