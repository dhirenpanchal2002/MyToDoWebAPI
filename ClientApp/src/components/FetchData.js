import React, { Component } from 'react';

export class FetchData extends Component {
  static displayName = FetchData.name;

  constructor(props) {
    super(props);
    this.state = { todoList: [], loading: true };
  }

  componentDidMount() {
    this.populateWeatherData();
  }

  static renderForecastsTable(todoList) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Date</th>
            <th>Temp. (C)</th>
            <th>Temp. (F)</th>
            <th>Summary</th>
          </tr>
        </thead>
        <tbody>
          {todoList.map(todoItem =>
            <tr key={todoItem.Id}>
              <td>{todoItem.name}</td>
              <td>{todoItem.description}</td>
              <td>{todoItem.priority}</td>
              <td>{todoItem.isactive}</td>
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
        <h1 id="tabelLabel" >Weather todoItem</h1>
        <p>This component demonstrates fetching data from the server.</p>
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
