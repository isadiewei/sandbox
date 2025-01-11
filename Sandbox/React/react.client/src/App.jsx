import { useEffect, useState } from 'react';
import './App.css';
import New from './todos/New';
import Delete from './todos/Delete';
import Button from '@mui/material/Button';
import ButtonGroup from '@mui/material/ButtonGroup';
import DataTable from './todos/DataTable';

function App() {
    const [todos, setTodos] = useState();

    useEffect(() => {
        populate();
    }, []);

    const contents = todos === undefined
        ? <p><em>Loading...</em></p>
        : <table className="table table-striped" aria-labelledby="tableLabel">
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Description</th>
                    <th>Action</th>
                </tr>
            </thead>
            <tbody>
                {todos.map(todo =>
                    <tr key={todo.taskId}>
                        <td>{todo.name}</td>
                        <td>{todo.description}</td>
                        <td>
                            <ButtonGroup aria-label="Basic button group">
                                <Button>One</Button>
                                <Delete updated={populate} todoId={todo.todoId} />
                            </ButtonGroup>
                        </td>
                    </tr>
                )}
            </tbody>
        </table>;

    return (
        <div>
            <h1 id="tableLabel">Todos</h1>
            <p>A list of tasks to complete.</p>
            <div className="new-row">
                <New updated={populate} />
            </div>
            <DataTable rows={todos} update={populate} />
            <hr />
            {/*{contents}*/}
        </div>
    );

    async function populate() {
        const response = await fetch('task');
        if (response.ok) {
            const data = await response.json();
            setTodos(data);
        }
    }
}

export default App;