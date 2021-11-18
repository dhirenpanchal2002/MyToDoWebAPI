import React, { Component, useLayoutEffect, useState } from 'react';


const ListData = (props) => {

    const [todoList, SettodoList] = useState(() => { return []; });

    useLayoutEffect(() => {

        console.log(props);
        SettodoList([...props.todoList]);

    }, [props]);

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

export default ListData;