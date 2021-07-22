import React, { Component } from "react";

export class Home extends Component {
  render () {
    return (
      <div>
        <h1>Whist</h1>
          <ul className="list-group">
                {this.props.tableNames.map(table => 
                    <li className="list-group-item list-group-item-action" key={table}
                        onClick={() => this.props.selectTable(table)}>
                        { table }
                    </li>)}
            </ul>
      </div>
    );
  }
}
