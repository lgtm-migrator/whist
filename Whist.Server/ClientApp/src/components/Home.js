import { EditableText } from "./EditableText";

export function Home(props) {
    return (
      <div>
        <h1>Join a Table</h1>
          <ul className="list-group">
                {props.listOfTables.map(({ key, text: name }) => {
                    return <li className="list-group-item list-group-item-action" key={key}>
                        <EditableText text={name} saveEdit={text => props.saveTableName(key, text)} />
                        <button className="btn btn-primary float-right"
                            onClick={() => props.selectTable(key)}>Join Table!</button>
                    </li>;
                })}
            </ul>
      </div>
    );
}
