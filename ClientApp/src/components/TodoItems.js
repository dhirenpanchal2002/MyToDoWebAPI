﻿import React, {useEffect, useState } from 'react';
import ListData from './ListData';
import GridData from './GridData';
import listIcon from '.././Images/list.svg';
import gridIcon from '.././Images/grid.svg';
import searchIcon from '.././Images/search.svg';
import Classes from './TodoItems.module.css';
import { Button, Form, FormGroup, Label, Input, Alert } from 'reactstrap';

const TodoItems =(props) => {
    
    const [todoList, SettodoList] = useState(() => { return []; });
    const [loading, Setloading] = useState(() => { return true; });
    const [SearchText, SetSearchText] = useState(() => { return ''; });
    const [IsGridView, SetIsGridView] = useState(() => { return  false; });

    function SearchToDoItem (event) {
        console.log("SearchToDoItem ToDO item clicked");
    }

    function onSearchTextChangeHandler(event) {
        SetSearchText(event.target.value);
    }

    let gridViewClass = Classes.imgIcon;
    let listViewClass = Classes.imgIconSelected;

    function onDisplayViewChange(event) {
        if (event.target.id == "imgGrid")
        {
            gridViewClass = Classes.imgIconSelected;
            listViewClass = Classes.imgIcon;
            SetIsGridView(true);
            
        }
            
        else
        {
            gridViewClass = Classes.imgIcon;
            listViewClass = Classes.imgIconSelected;
                SetIsGridView(false);
                
            }
            
    }
    

    async function populateWeatherData()
    {
        const response = await fetch('ToDo');
        const data = await response.json();
        SettodoList(data.data)
        Setloading(false);    
    }

    useEffect(() => {
        populateWeatherData();

    }, []);
    
    //
    
    let contents = loading
        ? <p><em>Loading...</em></p>
        : IsGridView ? <GridData todoList={todoList}> </GridData> : <ListData todoList={todoList}> </ListData>

        return (
            <div >
                <div>
                    <h1 id="tabelLabel" >Todo Items</h1>
                    <p>List of active ToDo items.</p>
                </div>
                <div className={Classes.outerBox}>
                    <div className={Classes.leftBox}>
                        <img src={listIcon} className={listViewClass} alt="List" id="imgList" onClick={onDisplayViewChange} />
                        <img src={gridIcon} className={gridViewClass} alt="Grid" id="imgGrid" onClick={onDisplayViewChange} />
                    </div>
                    <div className={Classes.rightBox}>
                        <input className={Classes.Searchbox} type="text" name="SearchTextbox" id="SearchTextbox" value={SearchText}
                            autoComplete="true" onChange={onSearchTextChangeHandler} placeholder="Search text" />                    
                        <img src={searchIcon} alt="Search" onClick={SearchToDoItem} className={Classes.imgIconSelected} id="imgSearch" />
                    </div>
                    
                </div>
                {contents}
            </div >                
        );    
    
}

export default TodoItems;
