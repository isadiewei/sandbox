import { useEffect, useState } from 'react';
import './App.css';
import New from './todos/New';

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
                </tr>
            </thead>
            <tbody>
                {todos.map(todo =>
                    <tr key={todo.date}>
                        <td>{todo.name}</td>
                        <td>{todo.description}</td>
                    </tr>
                )}
            </tbody>
        </table>;

    return (
        <div>
            <h1 id="tableLabel">Todos</h1>
            <p>A list of tasks to complete.</p>
            <New updated={populate} />
            <hr />
            {contents}
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