import React, { useState, useEffect } from "react";
import { Routes, Route } from "react-router";
import { Layout } from "./components/Layout";
import { Home } from "./components/Home";
import { Lobby } from "./components/Lobby";
import { Game } from "./components/Game";
import { connect } from "./network";
import { useNavigate } from "react-router-dom";

import "./custom.css"

export default function App(props) {
    const [connection, setConnection] = useState(null);
    const [listOfTables, setListOfTables] = useState([]);
    const [players, setPlayerNames] = useState([]);
    const navigate = useNavigate();

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
        <Routes>
            <Route exact path="/" element={
                <Home
                    listOfTables={listOfTables}
                    selectTable={(table) => {
                        connection.send("SelectTable", table);
                        navigate(`/lobby/${table}`);
                    }}
                    saveTableName={(key, text) =>
                        connection.send("SaveTableName", key, text)
                    } />} />
            <Route path="/lobby" element={
                <Lobby
                    playerNames={players}
                    savePlayerName={(key, text) => connection.send("SavePlayerName", key, text)}/>} />
            <Route path="/game" element={<Game />} />
        </Routes>
      </Layout>
    );
}
