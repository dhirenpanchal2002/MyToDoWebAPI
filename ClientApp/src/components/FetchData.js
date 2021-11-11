import React, { Component } from 'react';

export class FetchData extends Component {
  static displayName = FetchData.name;

  constructor(props) {
    super(props);
    this.state = { todoList: [], loading: true };
  }

    AddNewToDoItem = (event) =>{
    console.log("Add new ToDO item clicked");
    }
  componentDidMount() {
    this.populateWeatherData();
  }

  static renderForecastsTable(todoList) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Name</th>
            <th>Description</th>
            <th>Priority</th>
            <th>Status</th>
          </tr>
        </thead>
        <tbody>
          {todoList.map(todoItem =>
            <tr key={todoItem.Id}>
              <td>{todoItem.name}</td>
              <td>{todoItem.description}</td>
              <td>{todoItem.priorityName}</td>
              <td>{todoItem.statusName}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchData.renderForecastsTable(this.state.todoList);

    return (
      <div>
        <h1 id="tabelLabel" >Todo Items</h1>
        <p>List of active ToDo items.</p>
            <button className="btn btn-primary" onClick={this.AddNewToDoItem}>Add New</button>
        {contents}
      </div>
    );
  }

  async populateWeatherData() {
    const response = await fetch('ToDo');
    const data = await response.json();
    this.setState({ todoList: data.data, loading: false });
  }
}
