import * as signalR from "@microsoft/signalr"

export function connect(client) {
    const connection = new signalR.HubConnectionBuilder()
        .configureLogging(signalR.LogLevel.Information)
        .withUrl("/WhistHub")
        .build();
    connection.on("UpdateListOfTables", (tables) => client.updateListOfTables(tables));
    connection.on("UpdatePlayersAtTable", (players) => client.updatePlayersAtTable(players));
    connection.on("ReceiveDealtCards", (cards) => client.receiveDealtCards(cards));
    connection.start().then(function() {
        // TODO(jrgfogh): Do something!
    }).catch(function(err) {
        // TODO(jrgfogh): Do something!
    });
    return connection;
}