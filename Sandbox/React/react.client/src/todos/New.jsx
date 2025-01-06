import { useState } from 'react';
//import './App.css';

export default function New({ updated }) {
    const [name, setName] = useState("");
    const [description, setDescription] = useState("");

    function handleNameChange(e) {
        setName(e.target.value);
    }

    function handleDescriptionChange(e) {
        setDescription(e.target.value);
    }

    function handleAddClick() {
        const body = JSON.stringify({
            name: name,
            description: description
        });

        fetch('task', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body
        });

        updated();
    }

    return (
        <div>
            <button type="btn" onClick={handleAddClick}>Add Task</button>
            <div>
                <input value={name} onChange={handleNameChange}></input>
                <input value={description} onChange={handleDescriptionChange}></input>
            </div>
        </div>
    );
}

