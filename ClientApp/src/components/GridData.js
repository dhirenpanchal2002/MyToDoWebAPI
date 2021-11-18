import { React, useEffect, useState } from 'react';
import  Card  from './UI/Card';
import Classes from './GridData.module.css';

const GridData = (props) => {

    const [Items, SetItems] = useState(() => { return []; })

    useEffect(() => {

        SetItems([...props.todoList]);

    }, [props])

    return (
        <div className={Classes.gridContainer} >
            {Items.map(todoItem =>
                <Card key={todoItem.Id} className={Classes.gridItem} >
                    <ul className={Classes.liItem}  key={todoItem.Id}>
                    <li className={Classes.liItem} ><b>{todoItem.name}</b></li><hr></hr>
                    <li className={Classes.liItem}>{"Summary: " + todoItem.description}</li>
                    <li className={Classes.liItem}>{"Priority: " + todoItem.priorityName}</li>
                    <li className={Classes.liItem}>{"Status: " + todoItem.statusName}</li>
                </ul></Card>
            )}
        </div>
        )
    
}

export default  GridData;

